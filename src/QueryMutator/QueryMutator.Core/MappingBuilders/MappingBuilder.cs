using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace QueryMutator.Core
{
    internal class MappingBuilder<TSource, TTarget> : MappingBuilderBase, IMappingBuilder<TSource, TTarget>
    {
        public MapperConfigurationExpression Config { get; set; }

        public ParameterExpression SourceParameter { get; set; }

        public List<MemberBindingBase> Bindings { get; set; }

        public ValidationMode ValidationMode { get; set; }

        public MappingBuilder()
        {
            SourceType = typeof(TSource);
            TargetType = typeof(TTarget);

            Dependencies = new List<BuilderDescriptor>();

            SourceParameter = Expression.Parameter(SourceType);
            Bindings = new List<MemberBindingBase>();
            ValidationMode = ValidationMode.None;
        }

        public MappingBuilder(MapperConfigurationExpression config) : this()
        {
            Config = config;
            ValidationMode = config.ValidationMode;
        }

        public override IMapping Build(Dictionary<MappingKey, IMapping> dependencies)
        {
            UpdateDependentBindings(dependencies);

            var mapping = new Mapping<TSource, TTarget>();

            var bindings = Bindings
                    .Select(p => (p.TargetMember, Expression: p.GenerateExpression(SourceParameter)))
                    .Where(p => p.Expression != null)
                    .Select(p => Expression.Bind(p.TargetMember, p.Expression));

            var body = Expression.MemberInit(Expression.New(typeof(TTarget)), bindings);

            mapping.Expression = Expression.Lambda<Func<TSource, TTarget>>(body, SourceParameter);

            return mapping;
        }

        protected void UpdateDependentBindings(Dictionary<MappingKey, IMapping> dependencies)
        {
            if (dependencies.Any())
            {
                var listBindings = Bindings.OfType<DependentListMemberBinding>();

                foreach (var listBinding in listBindings)
                {
                    dependencies.TryGetValue(new MappingKey(listBinding.SourceType, listBinding.TargetType), out var dependentMapping);

                    var property = Expression.Property(SourceParameter, listBinding.SourceMember);
                    var selectExpression = Expression.Call(typeof(Enumerable), nameof(Enumerable.Select), new Type[] { listBinding.SourceType, listBinding.TargetType }, property, dependentMapping.Expression);
                    var expression = Expression.Call(typeof(Enumerable), nameof(Enumerable.ToList), new Type[] { listBinding.TargetType }, selectExpression);

                    listBinding.SourceExpression = expression;
                }

                var complexBindings = Bindings.OfType<DependentComplexMemberBinding>();

                foreach (var complexBinding in complexBindings)
                {
                    dependencies.TryGetValue(new MappingKey(complexBinding.SourceType, complexBinding.TargetType), out var dependentMapping);

                    complexBinding.SourceExpression = dependentMapping.Expression.Body as MemberInitExpression;
                }
            }
        }

        public void CreateDefaultBindings()
        {
            var sourceProperties = typeof(TSource).GetProperties();

            foreach (var targetProperty in typeof(TTarget).GetProperties())
            {
                if (!Bindings.Any(b => b.TargetMember.Name == targetProperty.Name))
                {
                    if (sourceProperties.Any(p => p.Name == targetProperty.Name))
                    {
                        var sourceProperty = sourceProperties.First(p => p.Name == targetProperty.Name);

                        if (sourceProperty.PropertyType == targetProperty.PropertyType)
                        {
                            Bindings.Add(new MemberBinding
                            {
                                SourceExpression = Expression.Property(SourceParameter, sourceProperty),
                                TargetMember = targetProperty
                            });
                        }
                        else if (sourceProperty.PropertyType.IsClass && sourceProperty.PropertyType != typeof(string))
                        {
                            AddDependency(sourceProperty.PropertyType, targetProperty.PropertyType);

                            Bindings.Add(new DependentComplexMemberBinding
                            {
                                SourceType = sourceProperty.PropertyType,
                                TargetType = targetProperty.PropertyType,
                                SourceExpression = null,
                                SourceMember = sourceProperty,
                                TargetMember = targetProperty
                            });
                        }
                        else if (sourceProperty.PropertyType.IsGenericType && typeof(ICollection<>).IsAssignableFrom(sourceProperty.PropertyType.GetGenericTypeDefinition()))
                        {
                            var sourceType = sourceProperty.PropertyType.GenericTypeArguments[0];
                            var targetType = targetProperty.PropertyType.GenericTypeArguments[0];

                            if (sourceType == targetType)
                            {
                                DefaultListMemberBinding(Expression.Property(SourceParameter, sourceProperty), targetProperty, targetType);
                            }
                            else
                            {
                                AddDependency(sourceType, targetType);

                                Bindings.Add(new DependentListMemberBinding
                                {
                                    SourceType = sourceType,
                                    TargetType = targetType,
                                    SourceExpression = null,
                                    SourceMember = sourceProperty,
                                    TargetMember = targetProperty
                                });
                            }

                            // TODO what if the type argument is another list?....
                        }
                        else if (Nullable.GetUnderlyingType(sourceProperty.PropertyType) != null)
                        {
                            Bindings.Add(new MemberBinding
                            {
                                SourceExpression = Expression.Coalesce(Expression.Property(SourceParameter, sourceProperty), Expression.Default(targetProperty.PropertyType)),
                                TargetMember = targetProperty
                            });
                        }
                        else if (Nullable.GetUnderlyingType(targetProperty.PropertyType) != null)
                        {
                            Bindings.Add(new MemberBinding
                            {
                                SourceExpression = Expression.Convert(Expression.Property(SourceParameter, sourceProperty), targetProperty.PropertyType),
                                TargetMember = targetProperty
                            });
                        }
                    }
                    else
                    {
                        // If flattened properties exist, map them (e.g. ChildName -> Child.Name)
                        CheckPropertyFlattening(sourceProperties, targetProperty, targetProperty.Name, SourceParameter);
                    }
                }
            }

            if (ValidationMode == ValidationMode.Source)
            {
                if (typeof(TSource).GetProperties().Any(p => !Bindings.Any(b => b.TargetMember.Name == p.Name)))
                {
                    throw new MappingValidationException("Not all source properties are mapped!");
                }
            }
            else if (ValidationMode == ValidationMode.Destination)
            {
                if (typeof(TTarget).GetProperties().Any(p => !Bindings.Any(b => b.TargetMember.Name == p.Name)))
                {
                    throw new MappingValidationException("Not all destination properties are mapped!");
                }
            }
        }

        private void CheckPropertyFlattening(IEnumerable<PropertyInfo> sourceProperties, PropertyInfo targetProperty, string currentName, Expression propertyChain)
        {
            if (sourceProperties.Any(p => p.Name == currentName))
            {
                var sourceProperty = sourceProperties.FirstOrDefault(p => p.Name == currentName && p.PropertyType == targetProperty.PropertyType);
                if (sourceProperty != null)
                {
                    Bindings.Add(new MemberBinding
                    {
                        SourceExpression = Expression.Property(propertyChain, sourceProperty),
                        TargetMember = targetProperty
                    });
                }
            }
            else if (sourceProperties.Any(p => currentName.StartsWith(p.Name)))
            {
                foreach (var property in sourceProperties.Where(p => currentName.StartsWith(p.Name)))
                {
                    var newName = currentName.Substring(property.Name.Length);
                    CheckPropertyFlattening(property.PropertyType.GetProperties(), targetProperty, newName, Expression.Property(propertyChain, property));
                }
            }
        }

        private void AddDependency(Type sourceType, Type targetType)
        {
            var dependency = new BuilderDescriptor(sourceType, targetType);

            Dependencies.Add(dependency);

            if (!Config.BuilderDescriptors.Any(d => d.SourceType == sourceType && d.TargetType == targetType))
            {
                Config.BuilderDescriptors.Add(dependency);
            }
        }

        private void DefaultListMemberBinding(MemberExpression sourceProperty, MemberInfo targetMember, Type targetMemberType)
        {
            var expression = Expression.Call(typeof(Enumerable), nameof(Enumerable.ToList), new Type[] { targetMemberType }, sourceProperty);

            Bindings.Add(new MemberBinding
            {
                SourceExpression = expression,
                TargetMember = targetMember
            });
        }

        public IMappingBuilder<TSource, TTarget> IgnoreMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector)
        {
            Bindings.Add(new MemberBinding
            {
                SourceExpression = null,
                TargetMember = (memberSelector.Body as MemberExpression).Member
            });

            return this;
        }

        public IMappingBuilder<TSource, TTarget> MapMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector, TMember constant)
        {
            Bindings.Add(new MemberBinding
            {
                SourceExpression = Expression.Constant(constant, typeof(TMember)), // Second parameter is required to handle nullable types
                TargetMember = (memberSelector.Body as MemberExpression).Member
            });

            return this;
        }

        public IMappingBuilder<TSource, TTarget> MapMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector, Expression<Func<TSource, TMember>> mappingExpression)
        {
            var targetMember = (memberSelector.Body as MemberExpression).Member;
            if (mappingExpression.Body.NodeType == ExpressionType.MemberAccess)
            {
                Bindings.Add(new MemberBinding
                {
                    SourceExpression = Expression.Property(SourceParameter, (mappingExpression.Body as MemberExpression).Member as PropertyInfo),
                    TargetMember = targetMember
                });
            }
            else if (mappingExpression.Body.NodeType == ExpressionType.MemberInit)
            {
                Bindings.Add(new ComplexMemberBinding
                {
                    SourceExpression = mappingExpression.Body as MemberInitExpression,
                    TargetMember = targetMember
                });
            }

            return this;
        }

        public IMappingBuilder<TSource, TTarget> MapMember<TMember>(Expression<Func<TTarget, TMember?>> memberSelector, Expression<Func<TSource, TMember>> mappingExpression) where TMember : struct
        {
            Bindings.Add(new MemberBinding
            {
                SourceExpression = Expression.Convert(Expression.Property(SourceParameter, (mappingExpression.Body as MemberExpression).Member as PropertyInfo), typeof(TMember?)),
                TargetMember = (memberSelector.Body as MemberExpression).Member
            });

            return this;
        }

        public IMappingBuilder<TSource, TTarget> MapMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector, Expression<Func<TSource, TMember?>> mappingExpression) where TMember : struct
        {
            Bindings.Add(new MemberBinding
            {
                SourceExpression = Expression.Coalesce(Expression.Property(SourceParameter, (mappingExpression.Body as MemberExpression).Member as PropertyInfo), Expression.Default(typeof(TMember))),
                TargetMember = (memberSelector.Body as MemberExpression).Member
            });
            return this;
        }

        public IMappingBuilder<TSource, TTarget> MapMemberList<TTargetMember, TSourceMember>(Expression<Func<TTarget, IEnumerable<TTargetMember>>> memberSelector, Expression<Func<TSource, IEnumerable<TSourceMember>>> mappingExpression)
        {
            var targetMember = (memberSelector.Body as MemberExpression).Member;
            var sourceMember = (mappingExpression.Body as MemberExpression).Member as PropertyInfo;

            if (typeof(TTargetMember) == typeof(TSourceMember))
            {
                DefaultListMemberBinding(Expression.Property(SourceParameter, sourceMember), targetMember, typeof(TTargetMember));
            }
            else
            {
                AddDependency(typeof(TSourceMember), typeof(TTargetMember));

                Bindings.Add(new DependentListMemberBinding
                {
                    SourceType = typeof(TSourceMember),
                    TargetType = typeof(TTargetMember),
                    SourceExpression = null,
                    SourceMember = sourceMember,
                    TargetMember = targetMember
                });
            }

            return this;
        }

        public IMappingBuilder<TSource, TTarget> ValidateMapping(ValidationMode mode)
        {
            ValidationMode = mode;

            return this;
        }
    }

    internal class MappingBuilder<TSource, TTarget, TParam> : MappingBuilder<TSource, TTarget>, IMappingBuilder<TSource, TTarget, TParam>
    {
        public List<MemberBindingBase<TParam>> ParametrizedBindings { get; set; }
        
        public Dictionary<MappingKey, IMapping> ParametrizedDependencies { get; set; }

        public MappingBuilder(MapperConfigurationExpression config) : base(config)
        {
            ParametrizedBindings = new List<MemberBindingBase<TParam>>();
            ParametrizedDependencies = new Dictionary<MappingKey, IMapping>();
        }

        public override IMapping Build(Dictionary<MappingKey, IMapping> dependencies)
        {
            ParametrizedDependencies = dependencies;

            return null;
        }

        public Expression<Func<TSource, TTarget>> ToExpression(TParam param)
        {
            UpdateDependentBindings(ParametrizedDependencies);

            IEnumerable<(MemberInfo TargetMember, Func<TParam, Expression> ExpressionFactory)> bindings = Bindings
                    .Select(m => (m.TargetMember, (Func<TParam, Expression>)(p => m.GenerateExpression(SourceParameter))))
                    .Concat(ParametrizedBindings.Select(m => (m.TargetMember, (Func<TParam, Expression>)(p => m.GenerateExpression(SourceParameter, p)))))
                    .GroupBy(m => m.TargetMember)
                    .Select(m => m.Last());

            var memberBindings = bindings
                    .Select(p => (p.TargetMember, Expression: p.ExpressionFactory(param)))
                    .Where(p => p.Expression != null)
                    .Select(p => Expression.Bind(p.TargetMember, p.Expression));

            var body = Expression.MemberInit(Expression.New(typeof(TTarget)), memberBindings);

            return Expression.Lambda<Func<TSource, TTarget>>(body, SourceParameter);
        }

        public IMappingBuilder<TSource, TTarget, TParam> MapMemberWithParameter<TMember>(Expression<Func<TTarget, TMember>> memberSelector, Func<TParam, Expression<Func<TSource, TMember>>> mappingExpression)
        {
            ParametrizedBindings.Add(new ParametrizedMemberBinding<TSource, TMember, TParam>
            {
                ExpressionFactory = mappingExpression,
                TargetMember = (memberSelector.Body as MemberExpression).Member
            });

            return this;
        }
    }

}

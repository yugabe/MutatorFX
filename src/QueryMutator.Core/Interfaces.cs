using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace QueryMutator.Core
{
    public interface IMappingBuilder<TSource, TTarget>
    {
        IMappingBuilder<TSource, TTarget> MapMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector, TMember constant);

        IMappingBuilder<TSource, TTarget> MapMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector, Expression<Func<TSource, TMember>> mappingExpression);

        IMappingBuilder<TSource, TTarget> MapMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector, Expression<Func<TSource, TMember?>> mappingExpression) where TMember : struct;

        IMappingBuilder<TSource, TTarget> MapMember<TMember>(Expression<Func<TTarget, TMember?>> memberSelector, Expression<Func<TSource, TMember>> mappingExpression) where TMember : struct;

        IMappingBuilder<TSource, TTarget> MapMemberList<TTargetMember, TSourceMember>(Expression<Func<TTarget, IEnumerable<TTargetMember>>> memberSelector, Expression<Func<TSource, IEnumerable<TSourceMember>>> mappingExpression);
        
        IMappingBuilder<TSource, TTarget> IgnoreMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector);

        IMappingBuilder<TSource, TTarget> ValidateMapping(ValidationMode mode);
    }

    public interface IMappingBuilder<TSource, TTarget, TParam>
    {
        IMappingBuilder<TSource, TTarget, TParam> MapMemberWithParameter<TMember>(Expression<Func<TTarget, TMember>> memberSelector, Func<TParam, Expression<Func<TSource, TMember>>> mappingExpression);
    }

    internal abstract class MappingBuilder
    {
        public Type SourceType { get; set; }

        public Type TargetType { get; set; }

        public IList<MappingBuilder> Dependencies { get; set; }

        public abstract IMapping Build(IEnumerable<MappingDescriptor> dependencies);
    }
    
    internal class MappingBuilderEqualityComparer : EqualityComparer<MappingBuilder>
    {
        public override bool Equals(MappingBuilder b1, MappingBuilder b2)
        {
            return (b1 == null && b2 == null) || (b1 != null && b2 != null && b1.SourceType == b2.SourceType && b1.TargetType == b2.TargetType);
        }

        public override int GetHashCode(MappingBuilder obj)
        {
            return obj == null ? 0 : obj.SourceType.GetHashCode() ^ obj.TargetType.GetHashCode();
        }
    }

    internal class MappingBuilder<TSource, TTarget, TParam> : MappingBuilder<TSource, TTarget>, IMappingBuilder<TSource, TTarget, TParam>
    {
        public List<MemberBindingBase<TParam>> ParametrizedBindings { get; set; }

        public List<MappingDescriptor> ParametrizedDependencies { get; set; }

        public MappingBuilder(MapperConfigurationExpression config): base(config)
        {
            ParametrizedBindings = new List<MemberBindingBase<TParam>>();
            ParametrizedDependencies = new List<MappingDescriptor>();
        }

        public override IMapping Build(IEnumerable<MappingDescriptor> dependencies)
        {
            ParametrizedDependencies = dependencies.ToList();

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

    internal class MappingBuilder<TSource, TTarget> : MappingBuilder, IMappingBuilder<TSource, TTarget>
    {
        public MapperConfigurationExpression Config { get; set; }

        public ParameterExpression SourceParameter { get; set; }

        public List<MemberBindingBase> Bindings { get; set; }

        public ValidationMode ValidationMode { get; set; }

        public MappingBuilder()
        {
            SourceType = typeof(TSource);
            TargetType = typeof(TTarget);

            Dependencies = new List<MappingBuilder>();
            
            SourceParameter = Expression.Parameter(SourceType);
            Bindings = new List<MemberBindingBase>();
        }

        public MappingBuilder(MapperConfigurationExpression config) : this()
        {
            Config = config;
        }

        public override IMapping Build(IEnumerable<MappingDescriptor> dependencies)
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

        protected void UpdateDependentBindings(IEnumerable<MappingDescriptor> dependencies)
        {
            if (dependencies.Any())
            {
                var listBindings = Bindings.OfType<DependentListMemberBinding>();

                foreach (var listBinding in listBindings)
                {
                    var dependentMapping = dependencies.First(m => m.SourceType == listBinding.SourceType && m.TargetType == listBinding.TargetType);

                    var property = Expression.Property(SourceParameter, listBinding.SourceMember);
                    var selectExpression = Expression.Call(typeof(Enumerable), "Select", new Type[] { listBinding.SourceType, listBinding.TargetType }, property, dependentMapping.Mapping.Expression);
                    var expression = Expression.Call(typeof(Enumerable), "ToList", new Type[] { listBinding.TargetType }, selectExpression);

                    listBinding.SourceExpression = expression;
                }

                var complexBindings = Bindings.OfType<DependentComplexMemberBinding>();

                foreach (var complexBinding in complexBindings)
                {
                    var dependentMapping = dependencies.First(m => m.SourceType == complexBinding.SourceType && m.TargetType == complexBinding.TargetType);

                    complexBinding.SourceExpression = dependentMapping.Mapping.Expression.Body as MemberInitExpression;
                }
            }
        }

        public void CreateDefaultBindings()
        {
            var sourceProperties = typeof(TSource).GetProperties();

            foreach(var targetProperty in typeof(TTarget).GetProperties())
            {
                if(!Bindings.Any(b => b.TargetMember.Name == targetProperty.Name))
                {
                    if(sourceProperties.Any(p => p.Name == targetProperty.Name))
                    {
                        var sourceProperty = sourceProperties.First(p => p.Name == targetProperty.Name);
                        
                        if(sourceProperty.PropertyType == targetProperty.PropertyType)
                        {
                            Bindings.Add(new MemberBinding
                            {
                                SourceExpression = Expression.Property(SourceParameter, sourceProperty),
                                TargetMember = targetProperty
                            });
                        }
                        else if (typeof(ICollection).IsAssignableFrom(sourceProperty.PropertyType))
                        {
                            var sourceType = sourceProperty.PropertyType.GenericTypeArguments[0];
                            var targetType = targetProperty.PropertyType.GenericTypeArguments[0];

                            if(sourceType == targetType)
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
                        else if(sourceProperty.PropertyType.IsClass && sourceProperty.PropertyType != typeof(string))
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
                    }
                }
            }
        }

        private void AddDependency(Type sourceType, Type targetType)
        {
            var dependency = Activator.CreateInstance(typeof(MappingBuilder<,>).MakeGenericType(new Type[] { sourceType, targetType })) as MappingBuilder;

            Dependencies.Add(dependency);

            if(!Config.DefaultBuilders.Any(d => d.SourceType == sourceType && d.TargetType == targetType))
            {
                Config.DefaultBuilders.Add(dependency);
            }
        }

        private void DefaultListMemberBinding(MemberExpression sourceProperty, MemberInfo targetMember, Type targetMemberType)
        {
            var expression = Expression.Call(typeof(Enumerable), "ToList", new Type[] { targetMemberType }, sourceProperty);

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
    
    public interface IMapperConfigurationExpression
    {
        void CreateMapping<TSource, TTarget>();

        void CreateMapping<TSource, TTarget>(Action<IMappingBuilder<TSource, TTarget>> mappingFactory);

        void CreateMapping<TSource, TTarget, TParam>(Action<IMappingBuilder<TSource, TTarget, TParam>> mappingFactory);
    }

    internal class ParametrizedBuilderDescriptor
    {
        public Type SourceType { get; set; }

        public Type TargetType { get; set; }

        public Type ParameterType { get; set; }

        public IMapping Mapping { get; set; }

        public MappingBuilder Builder { get; set; }
    }

    internal class MapperConfigurationExpression : IMapperConfigurationExpression
    {
        public List<MappingBuilder> Builders { get; set; }

        public List<MappingBuilder> DefaultBuilders { get; set; }

        public List<ParametrizedBuilderDescriptor> ParametrizedBuilders { get; set; }

        public MapperConfigurationExpression()
        {
            Builders = new List<MappingBuilder>();
            DefaultBuilders = new List<MappingBuilder>();
            ParametrizedBuilders = new List<ParametrizedBuilderDescriptor>();
        }

        public void CreateMapping<TSource, TTarget>()
        {
            // TODO throw if already exists

            var builder = new MappingBuilder<TSource, TTarget>(this);
            builder.CreateDefaultBindings();

            Builders.Add(builder);
        }

        public void CreateMapping<TSource, TTarget>(Action<IMappingBuilder<TSource, TTarget>> mappingFactory)
        {
            // TODO throw if already exists

            var builder = new MappingBuilder<TSource, TTarget>(this);
            mappingFactory(builder);
            builder.CreateDefaultBindings(); // Should be run after the explicit mappings

            Builders.Add(builder);
        }

        public void CreateMapping<TSource, TTarget, TParam>(Action<IMappingBuilder<TSource, TTarget, TParam>> mappingFactory)
        {
            // TODO throw if already exists

            var builder = new MappingBuilder<TSource, TTarget, TParam>(this);
            mappingFactory(builder);
            builder.CreateDefaultBindings(); // Should be run after the explicit mappings

            ParametrizedBuilders.Add(new ParametrizedBuilderDescriptor
            {
                SourceType = typeof(TSource),
                TargetType = typeof(TTarget),
                ParameterType = typeof(TParam),
                Mapping = new Mapping<TSource, TTarget, TParam> { Builder = builder },
                Builder = builder
            });
        }
    }

    // TODO multiple mapperconfigurations, single mapper instance?
    public class MapperConfiguration
    {
        private MapperConfigurationExpression Config { get; set; }

        public MapperConfiguration(Action<IMapperConfigurationExpression> expression)
        {
            Config = new MapperConfigurationExpression();
            expression(Config);
        }

        public IMapper CreateMapper()
        {
            var comparer = new MappingBuilderEqualityComparer();

            // Check for circular dependency
            Config.Builders.TopologicalSort(b => b.Dependencies, comparer);

            var mappings = new List<MappingDescriptor>();

            // Create all non-user defined mappings
            CreateDefaultBuilders();
            
            var sortedBuilders = Config.Builders
                .TopologicalSort(b => b.Dependencies, comparer)
                .Distinct(comparer)
                .ToList();
            
            foreach (var builder in sortedBuilders)
            {
                var dependencies = mappings.Where(m => builder.Dependencies.Any(d => d.SourceType == m.SourceType && d.TargetType == m.TargetType));

                var mapping = builder.Build(dependencies);

                mappings.Add(new MappingDescriptor
                {
                    SourceType = builder.SourceType,
                    TargetType = builder.TargetType,
                    ParameterType = null,
                    Mapping = mapping
                });
            }

            foreach(var parametrizedBuilder in Config.ParametrizedBuilders)
            {
                var dependencies = mappings.Where(m => parametrizedBuilder.Builder.Dependencies.Any(d => d.SourceType == m.SourceType && d.TargetType == m.TargetType));

                // This just stores the dependencies for later use
                parametrizedBuilder.Builder.Build(dependencies);

                mappings.Add(new MappingDescriptor
                {
                    SourceType = parametrizedBuilder.SourceType,
                    TargetType = parametrizedBuilder.TargetType,
                    ParameterType = parametrizedBuilder.ParameterType,
                    Mapping = parametrizedBuilder.Mapping,
                });
            }
            
            return new Mapper
            {
                Mappings = mappings
            };
        }

        private void CreateDefaultBuilders()
        {
            var comparer = new MappingBuilderEqualityComparer();

            Config.DefaultBuilders.RemoveAll(d => Config.Builders.Any(b => b.SourceType == d.SourceType && b.TargetType == d.TargetType));

            var defaultBuilders = Config.DefaultBuilders
                .Distinct(comparer)
                .ToList(); // Creating a new instance here is important

            foreach (var defaultBuilder in defaultBuilders)
            {
                var builderType = typeof(MappingBuilder<,>).MakeGenericType(new Type[] { defaultBuilder.SourceType, defaultBuilder.TargetType });
                var createDefaultBindingsMethod = builderType.GetMethod("CreateDefaultBindings");

                var builder = Activator.CreateInstance(builderType, new object[] { Config });
                createDefaultBindingsMethod.Invoke(builder, null);

                Config.Builders.Add(builder as MappingBuilder);

                Config.DefaultBuilders.Remove(defaultBuilder);

                // Replace the dummy dependency with the dynamically created one
                var dependentBuilders = Config.Builders.Where(b => b.Dependencies.Any(d => d.SourceType == defaultBuilder.SourceType && d.TargetType == defaultBuilder.TargetType));
                foreach (var dependentBuilder in dependentBuilders)
                {
                    var index = dependentBuilder.Dependencies.IndexOf(dependentBuilder.Dependencies.First(d => d.SourceType == defaultBuilder.SourceType && d.TargetType == defaultBuilder.TargetType));
                    dependentBuilder.Dependencies[index] = builder as MappingBuilder;
                }
            }

            // Check for circular dependency
            Config.Builders.TopologicalSort(b => b.Dependencies, comparer);

            if (Config.DefaultBuilders.Any())
            {
                CreateDefaultBuilders();
            }
        }
    }
}

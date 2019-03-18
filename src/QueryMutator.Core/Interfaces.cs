using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace QueryMutator.Core
{
    public interface IMappingBuilder<TSource, TTarget, TParam>
    {
        IMappingBuilder<TSource, TTarget, TParam> MapMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector, TMember constant);

        IMappingBuilder<TSource, TTarget, TParam> MapMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector, Expression<Func<TSource, TMember>> mappingExpression);

        IMappingBuilder<TSource, TTarget, TParam> MapMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector, Expression<Func<TSource, TMember?>> mappingExpression) where TMember : struct;

        IMappingBuilder<TSource, TTarget, TParam> MapMember<TMember>(Expression<Func<TTarget, TMember?>> memberSelector, Expression<Func<TSource, TMember>> mappingExpression) where TMember : struct;

        IMappingBuilder<TSource, TTarget, TParam> MapMemberList<TMember, TMapSource>(Expression<Func<TTarget, IEnumerable<TMember>>> memberSelector, Expression<Func<TSource, IEnumerable<TMapSource>>> mappingExpression);

        IMappingBuilder<TSource, TTarget, TParam> MapMemberUsing<TMember, TMapSource>(Expression<Func<TTarget, TMember>> memberSelector, Expression<Func<TSource, TMapSource>> sourceMemberSelector, IMapping<TMapSource, TMember> mapping);

        IMappingBuilder<TSource, TTarget, TParam> MapMemberWithParameter<TMember>(Expression<Func<TTarget, TMember>> memberSelector, Func<TParam, Expression<Func<TSource, TMember>>> mappingExpression);

        IMappingBuilder<TSource, TTarget, TParam> IgnoreMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector);

        IMappingBuilder<TSource, TTarget, TParam> ValidateMapping(ValidationMode mode);
    }

    public interface IMappingBuilder<TSource, TTarget>
    {
        IMappingBuilder<TSource, TTarget> MapMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector, TMember constant);

        IMappingBuilder<TSource, TTarget> MapMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector, Expression<Func<TSource, TMember>> mappingExpression);

        IMappingBuilder<TSource, TTarget> MapMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector, Expression<Func<TSource, TMember?>> mappingExpression) where TMember : struct;

        IMappingBuilder<TSource, TTarget> MapMember<TMember>(Expression<Func<TTarget, TMember?>> memberSelector, Expression<Func<TSource, TMember>> mappingExpression) where TMember : struct;

        IMappingBuilder<TSource, TTarget> MapMemberList<TMember, TMapSource>(Expression<Func<TTarget, IEnumerable<TMember>>> memberSelector, Expression<Func<TSource, IEnumerable<TMapSource>>> mappingExpression);
        
        IMappingBuilder<TSource, TTarget> MapMemberUsing<TMember, TMapSource>(Expression<Func<TTarget, TMember>> memberSelector, Expression<Func<TSource, TMapSource>> sourceMemberSelector, IMapping<TMapSource, TMember> mapping);

        IMappingBuilder<TSource, TTarget> IgnoreMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector);

        IMappingBuilder<TSource, TTarget> ValidateMapping(ValidationMode mode);

        IMapping<TSource, TTarget> Build();
    }

    internal class MappingBuilder<TSource, TTarget> : IMappingBuilder<TSource, TTarget>
    {
        public ParameterExpression SourceParameter { get; set; }

        public List<MemberBindingBase> Bindings { get; set; }

        public ValidationMode ValidationMode { get; set; }

        public MappingBuilder()
        {
            SourceParameter = Expression.Parameter(typeof(TSource));
            Bindings = new List<MemberBindingBase>();
        }

        public IMapping<TSource, TTarget> Build()
        {
            var mapping = new Mapping<TSource, TTarget>();
            
            var bindings = Bindings
                    .Select(p => (p.TargetMember, Expression: p.GenerateExpression(SourceParameter)))
                    .Where(p => p.Expression != null)
                    .Select(p => Expression.Bind(p.TargetMember, p.Expression));

            var body = Expression.MemberInit(Expression.New(typeof(TTarget)), bindings);

            mapping.Expression = Expression.Lambda<Func<TSource, TTarget>>(body, SourceParameter);

            return mapping;
        }

        public void CreateDefaultBindings()
        {
            var sourceProperties = typeof(TSource).GetProperties();

            foreach(var property in typeof(TTarget).GetProperties())
            {
                if(!Bindings.Any(b => b.TargetMember.Name == property.Name))
                {
                    if(sourceProperties.Any(p => p.Name == property.Name && p.PropertyType == property.PropertyType))
                    {
                        var sourceProperty = sourceProperties.First(p => p.Name == property.Name);
                        
                        Bindings.Add(new MemberBinding
                        {
                            SourceExpression = Expression.Property(SourceParameter, sourceProperty),
                            TargetMember = property
                        });
                    }
                }
            }
        }

        public IMappingBuilder<TSource, TTarget> IgnoreMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector)
        {
            Bindings.Add(new IgnoreMemberBinding
            {
                TargetMember = (memberSelector.Body as MemberExpression).Member
            });

            return this;
        }

        public IMappingBuilder<TSource, TTarget> MapMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector, TMember constant)
        {
            Bindings.Add(new ConstantMemberBinding
            {
                SourceExpression = Expression.Constant(constant, typeof(TMember)), // Second parameter is required to handle nullable types
                TargetMember = (memberSelector.Body as MemberExpression).Member
            });

            return this;
        }
        
        public IMappingBuilder<TSource, TTarget> MapMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector, Expression<Func<TSource, TMember>> mappingExpression)
        {
            Bindings.Add(new MemberBinding
            {
                SourceExpression = Expression.Property(SourceParameter, (mappingExpression.Body as MemberExpression).Member as PropertyInfo),
                TargetMember = (memberSelector.Body as MemberExpression).Member
            });

            return this;
        }

        public IMappingBuilder<TSource, TTarget> MapMember<TMember>(Expression<Func<TTarget, TMember?>> memberSelector, Expression<Func<TSource, TMember>> mappingExpression) where TMember : struct
        {
            Bindings.Add(new NullableMemberBinding
            {
                SourceExpression = Expression.Convert(Expression.Property(SourceParameter, (mappingExpression.Body as MemberExpression).Member as PropertyInfo), typeof(TMember?)),
                TargetMember = (memberSelector.Body as MemberExpression).Member
            });

            return this;
        }

        public IMappingBuilder<TSource, TTarget> MapMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector, Expression<Func<TSource, TMember?>> mappingExpression) where TMember : struct
        {
            Bindings.Add(new NullableMemberBinding
            {
                SourceExpression = Expression.Coalesce(Expression.Property(SourceParameter, (mappingExpression.Body as MemberExpression).Member as PropertyInfo), Expression.Default(typeof(TMember))),
                TargetMember = (memberSelector.Body as MemberExpression).Member
            });
            return this;
        }

        public IMappingBuilder<TSource, TTarget> MapMemberList<TMember, TMapSource>(Expression<Func<TTarget, IEnumerable<TMember>>> memberSelector, Expression<Func<TSource, IEnumerable<TMapSource>>> mappingExpression)
        {
            var property = Expression.Property(SourceParameter, (mappingExpression.Body as MemberExpression).Member as PropertyInfo);

            if (typeof(TMember) == typeof(TMapSource))
            {
                var expression = Expression.Call(typeof(Enumerable), "ToList", new Type[] { typeof(TMember) }, property);

                Bindings.Add(new MemberListBinding
                {
                    SourceExpression = expression,
                    TargetMember = (memberSelector.Body as MemberExpression).Member
                });
            }
            else
            {
                // TODO this has to be replaced later
                var builder = new MappingBuilder<TMapSource, TMember>();
                builder.CreateDefaultBindings();
                var mapping = builder.Build();
                
                var selectExpression = Expression.Call(typeof(Enumerable), "Select", new Type[] { typeof(TMapSource), typeof(TMember) }, property, mapping.Expression);
                var expression = Expression.Call(typeof(Enumerable), "ToList", new Type[] { typeof(TMember) }, selectExpression);

                Bindings.Add(new MemberListBinding
                {
                    SourceExpression = expression,
                    TargetMember = (memberSelector.Body as MemberExpression).Member
                });
            }

            return this;
        }

        public IMappingBuilder<TSource, TTarget> MapMemberUsing<TMember, TMapSource>(Expression<Func<TTarget, TMember>> memberSelector, Expression<Func<TSource, TMapSource>> sourceMemberSelector, IMapping<TMapSource, TMember> mapping)
        {
            Bindings.Add(new UsingMemberBinding
            {
                SourceExpression = ReplaceParameterChains(mapping.Expression.Body as MemberInitExpression, (sourceMemberSelector.Body as MemberExpression).Member as PropertyInfo),
                TargetMember = (memberSelector.Body as MemberExpression).Member
            });

            return this;
        }

        private MemberInitExpression ReplaceParameterChains(MemberInitExpression expression, PropertyInfo sourceMember)
        {
            var bindings = new List<MemberAssignment>();

            foreach (var binding in expression.Bindings.ToList())
            {
                var memberBinding = binding as MemberAssignment;
                if (memberBinding.Expression is MemberExpression memberExpression)
                {
                    var properties = new List<PropertyInfo>();

                    // Extract all of the nested properties from the expression
                    Expression normalExpression = memberExpression;
                    while (normalExpression.NodeType == ExpressionType.MemberAccess)
                    {
                        properties.Add((normalExpression as MemberExpression).Member as PropertyInfo);
                        normalExpression = (normalExpression as MemberExpression).Expression;
                    }

                    properties.Add(sourceMember as PropertyInfo);
                    properties.Reverse();

                    // Construct a new expression with the correct parameter and child properties
                    Expression body = SourceParameter;
                    foreach (var property in properties)
                    {
                        body = Expression.Property(body, property);
                    }

                    bindings.Add(Expression.Bind(binding.Member, body));
                }
                else if (memberBinding.Expression is MemberInitExpression memberInitExpression)
                {
                    var newMemberInitExpression = ReplaceParameterChains(memberInitExpression, sourceMember);
                    bindings.Add(Expression.Bind(binding.Member, newMemberInitExpression));
                }
            }

            return Expression.MemberInit(expression.NewExpression, bindings);
        }

        public IMappingBuilder<TSource, TTarget> ValidateMapping(ValidationMode mode)
        {
            ValidationMode = mode;

            return this;
        }
    }
    
    // TODO replace return values to void?
    public interface IMapperConfigurationExpression
    {
        IMapping<TSource, TTarget> CreateMapping<TSource, TTarget>();

        IMapping<TSource, TTarget> CreateMapping<TSource, TTarget>(Action<IMappingBuilder<TSource, TTarget>> mappingFactory);

        IMapping<TSource, TTarget, TParam> CreateMapping<TSource, TTarget, TParam>(Action<IMappingBuilder<TSource, TTarget, TParam>> mappingFactory);
    }

    internal class MapperConfigurationExpression : IMapperConfigurationExpression
    {
        public List<MappingDescriptor> Mappings { get; set; }

        public MapperConfigurationExpression()
        {
            Mappings = new List<MappingDescriptor>();
        }

        public IMapping<TSource, TTarget> CreateMapping<TSource, TTarget>()
        {
            var builder = new MappingBuilder<TSource, TTarget>();
            builder.CreateDefaultBindings();

            var mapping = builder.Build();

            Mappings.Add(new MappingDescriptor
            {
                SourceType = typeof(TSource),
                TargetType = typeof(TTarget),
                ParameterType = null,
                Mapping = mapping
            });

            return mapping;
        }

        public IMapping<TSource, TTarget> CreateMapping<TSource, TTarget>(Action<IMappingBuilder<TSource, TTarget>> mappingFactory)
        {
            var builder = new MappingBuilder<TSource, TTarget>();
            mappingFactory(builder);
            builder.CreateDefaultBindings(); // Should be run after the explicit mappings

            var mapping = builder.Build();

            Mappings.Add(new MappingDescriptor
            {
                SourceType = typeof(TSource),
                TargetType = typeof(TTarget),
                ParameterType = null,
                Mapping = mapping
            });

            return mapping;
        }

        public IMapping<TSource, TTarget, TParam> CreateMapping<TSource, TTarget, TParam>(Action<IMappingBuilder<TSource, TTarget, TParam>> mappingFactory)
        {
            throw new NotImplementedException();
        }
    }

    public class MapperConfiguration
    {
        private List<MappingDescriptor> Mappings { get; set; }

        public MapperConfiguration(Action<IMapperConfigurationExpression> expression)
        {
            var configurationExpression = new MapperConfigurationExpression();
            expression(configurationExpression);
            Mappings = configurationExpression.Mappings;
        }

        public IMapper CreateMapper()
        {
            return new Mapper { Mappings = Mappings };
        }
    }
}

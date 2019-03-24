using System;
using System.Collections.Generic;

namespace QueryMutator.Core
{
    internal class MapperConfigurationExpression : IMapperConfigurationExpression
    {
        public List<MappingBuilderBase> Builders { get; set; }

        public List<MappingBuilderBase> DefaultBuilders { get; set; }

        public List<ParametrizedBuilderDescriptor> ParametrizedBuilders { get; set; }

        public MapperConfigurationExpression()
        {
            Builders = new List<MappingBuilderBase>();
            DefaultBuilders = new List<MappingBuilderBase>();
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
}

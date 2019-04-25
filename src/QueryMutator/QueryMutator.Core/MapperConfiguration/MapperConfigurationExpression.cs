using System;
using System.Collections.Generic;
using System.Reflection;

namespace QueryMutator.Core
{
    internal class MapperConfigurationExpression : IMapperConfigurationExpression
    {
        public List<BuilderDescriptor> BuilderDescriptors { get; set; }
        
        public Dictionary<MappingKey, MappingBuilderBase> Builders { get; set; }
        
        public Dictionary<MappingKey, ParametrizedBuilderDescriptor> ParametrizedBuilders { get; set; }

        public IEnumerable<Assembly> AttributeAssemblies { get; set; }

        public ValidationMode ValidationMode { get; set; }

        public MapperConfigurationExpression()
        {
            BuilderDescriptors = new List<BuilderDescriptor>();
            Builders = new Dictionary<MappingKey, MappingBuilderBase>();
            ParametrizedBuilders = new Dictionary<MappingKey, ParametrizedBuilderDescriptor>();
            AttributeAssemblies = new List<Assembly>();
        }

        public void CreateMapping<TSource, TTarget>()
        {
            var key = new MappingKey(typeof(TSource), typeof(TTarget));
            if (Builders.ContainsKey(key))
            {
                throw new MappingAlreadyExistsException("Another mapping already exists with the supplied types");
            }

            var builder = new MappingBuilder<TSource, TTarget>(this);
            builder.CreateDefaultBindings();

            Builders.Add(key, builder);
            BuilderDescriptors.Add(new BuilderDescriptor(typeof(TSource), typeof(TTarget), builder.Dependencies, true));
        }

        public void CreateMapping<TSource, TTarget>(Action<IMappingBuilder<TSource, TTarget>> mappingFactory)
        {
            var key = new MappingKey(typeof(TSource), typeof(TTarget));
            if (Builders.ContainsKey(key))
            {
                throw new MappingAlreadyExistsException("Another mapping already exists with the supplied types");
            }

            var builder = new MappingBuilder<TSource, TTarget>(this);
            mappingFactory(builder);
            builder.CreateDefaultBindings(); // Should be run after the explicit mappings

            Builders.Add(key, builder);
            BuilderDescriptors.Add(new BuilderDescriptor(typeof(TSource), typeof(TTarget), builder.Dependencies, true));
        }

        public void CreateMapping<TSource, TTarget, TParam>(Action<IMappingBuilder<TSource, TTarget, TParam>> mappingFactory)
        {
            var key = new MappingKey(typeof(TSource), typeof(TTarget), typeof(TParam));
            if (ParametrizedBuilders.ContainsKey(key))
            {
                throw new MappingAlreadyExistsException("Another mapping already exists with the supplied types");
            }

            var builder = new MappingBuilder<TSource, TTarget, TParam>(this);
            mappingFactory(builder);
            builder.CreateDefaultBindings(); // Should be run after the explicit mappings

            ParametrizedBuilders.Add(key, new ParametrizedBuilderDescriptor
            {
                Mapping = new Mapping<TSource, TTarget, TParam> { Builder = builder },
                Builder = builder
            });
        }

        public void UseAttributeMapping(IEnumerable<Assembly> assemblies)
        {
            AttributeAssemblies = assemblies;
        }
    }
}

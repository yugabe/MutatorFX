using System;
using System.Collections.Generic;
using System.Linq;

namespace QueryMutator.Core
{
    /// <summary>
    /// Represents the object used for configuring and creating a new mapper instance. 
    /// </summary>
    public class MapperConfiguration
    {
        private MapperConfigurationExpression Config { get; set; }

        /// <summary>
        /// Represents the object used for configuring and creating a new mapper instance. 
        /// </summary>
        /// <param name="expression">The configuration expressions action to execute.</param>
        /// <param name="options">The additional options. Can be null.</param>
        public MapperConfiguration(Action<IMapperConfigurationExpression> expression, MapperConfigurationOptions options = null)
        {
            Config = new MapperConfigurationExpression
            {
                ValidationMode = options?.ValidationMode ?? ValidationMode.None
            };
            
            expression(Config);
        }

        /// <summary>
        /// Creates a new mapper object using the registered mappings or the default mappings where necessary.
        /// </summary>
        /// <returns>Returns a new <see cref="IMapper"/> object that contains the mappings.</returns>
        public IMapper CreateMapper()
        {
            CreateAttributeBuilders();

            var comparer = EqualityComparer<BuilderDescriptor>.Default;

            // Check for circular dependency
            Config.BuilderDescriptors.TopologicalSort(b => b.Dependencies, comparer);

            var mappings = new Dictionary<MappingKey, IMapping>();
            
            // Create all non-user defined mappings
            CreateDefaultBuilders();
            
            foreach (var builderDescriptor in Config.BuilderDescriptors.TopologicalSort(b => b.Dependencies, comparer))
            {
                var key = new MappingKey(builderDescriptor.SourceType, builderDescriptor.TargetType);
                Config.Builders.TryGetValue(key, out var builder);

                var dependencies = mappings.Where(m => builder.Dependencies.Any(d => d.SourceType == m.Key.SourceType && d.TargetType == m.Key.TargetType)).ToDictionary(i => i.Key, i => i.Value);

                var mapping = builder.Build(dependencies);

                mappings.Add(key, mapping);
            }

            foreach (var parametrizedBuilder in Config.ParametrizedBuilders)
            {
                var dependencies = mappings.Where(m => parametrizedBuilder.Value.Builder.Dependencies.Any(d => d.SourceType == m.Key.SourceType && d.TargetType == m.Key.TargetType)).ToDictionary(i => i.Key, i => i.Value);

                // This just stores the dependencies for later use
                parametrizedBuilder.Value.Builder.Build(dependencies);

                mappings.Add(parametrizedBuilder.Key, parametrizedBuilder.Value.Mapping);
            }
            
            return new Mapper
            {
                Mappings = mappings
            };
        }

        private void CreateAttributeBuilders()
        {
            foreach(var assembly in Config.AttributeAssemblies)
            {
                foreach (var type in assembly.GetTypes())
                {
                    var attribute = type.GetCustomAttributes(typeof(MapFromAttribute), false).FirstOrDefault();
                    if (attribute != null)
                    {
                        var sourceType = (attribute as MapFromAttribute).SourceType;

                        var key = new MappingKey(sourceType, type);
                        if (Config.Builders.ContainsKey(key))
                        {
                            throw new MappingAlreadyExistsException("Another mapping already exists with the supplied types");
                        }

                        var builder = CreateMappingBuilder(sourceType, type);

                        Config.Builders.Add(key, builder);

                        Config.BuilderDescriptors.Add(new BuilderDescriptor(builder.SourceType, builder.TargetType, builder.Dependencies, true));
                    }
                }
            }
        }

        private void CreateDefaultBuilders()
        {
            foreach (var defaultBuilder in Config.BuilderDescriptors.Where(b => !b.Built).ToList())
            {
                var builder = CreateMappingBuilder(defaultBuilder.SourceType, defaultBuilder.TargetType);

                Config.Builders.Add(new MappingKey(defaultBuilder.SourceType, defaultBuilder.TargetType), builder);

                defaultBuilder.Built = true;
                defaultBuilder.Dependencies = builder.Dependencies;
            }

            // Check for circular dependency
            Config.BuilderDescriptors.TopologicalSort(b => b.Dependencies, EqualityComparer<BuilderDescriptor>.Default);

            if (Config.BuilderDescriptors.Any(b => !b.Built))
            {
                CreateDefaultBuilders();
            }
        }

        private MappingBuilderBase CreateMappingBuilder(Type sourceType, Type targetType)
        {
            var builderType = typeof(MappingBuilder<,>).MakeGenericType(new Type[] { sourceType, targetType });
            var createDefaultBindingsMethod = builderType.GetMethod("CreateDefaultBindings");

            var builder = Activator.CreateInstance(builderType, new object[] { Config });
            createDefaultBindingsMethod.Invoke(builder, null);

            return builder as MappingBuilderBase;
        }
    }
}

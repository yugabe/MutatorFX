using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueryMutator.Core
{
    public class MapperConfiguration
    {
        private MapperConfigurationExpression Config { get; set; }

        private bool UseAttributeMapping { get; set; }

        public MapperConfiguration(Action<IMapperConfigurationExpression> expression, MapperConfigurationOptions options = null)
        {
            Config = new MapperConfigurationExpression
            {
                ValidationMode = options?.ValidationMode ?? ValidationMode.None
            };

            UseAttributeMapping = options?.UseAttributeMapping ?? false;

            expression(Config);
        }

        public IMapper CreateMapper()
        {
            if (UseAttributeMapping)
            {
                CreateAttributeBuilders();
            }

            var comparer = EqualityComparer<MappingBuilderBase>.Default;

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

            foreach (var parametrizedBuilder in Config.ParametrizedBuilders)
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

        private void CreateAttributeBuilders()
        {
            var definingAssemblyName = typeof(MapFromAttribute).Assembly.GetName().Name;

            // Check assemblies that aren't system dlls and reference this assembly
            // Note: parallel query can be implemented if this is slow
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.GlobalAssemblyCache && a.GetReferencedAssemblies().Any(r => r.Name == definingAssemblyName)))
            {
                foreach (var type in assembly.GetTypes())
                {
                    var attribute = type.GetCustomAttributes(typeof(MapFromAttribute), false).FirstOrDefault();
                    if (attribute != null)
                    {
                        var sourceType = (attribute as MapFromAttribute).SourceType;
                        if (Config.Builders.Any(b => b.SourceType == sourceType && b.TargetType == type))
                        {
                            throw new MappingAlreadyExistsException("Another mapping already exists with the supplied types");
                        }

                        var builder = CreateMappingBuilder(sourceType, type);

                        Config.Builders.Add(builder);
                    }
                }
            }
        }

        private void CreateDefaultBuilders()
        {
            var comparer = EqualityComparer<MappingBuilderBase>.Default;

            Config.DefaultBuilders.RemoveAll(d => Config.Builders.Any(b => b.Equals(d)));

            var defaultBuilders = Config.DefaultBuilders
                .Distinct(comparer)
                .ToList(); // Creating a new instance here is important

            foreach (var defaultBuilder in defaultBuilders)
            {
                var builder = CreateMappingBuilder(defaultBuilder.SourceType, defaultBuilder.TargetType);

                Config.Builders.Add(builder);

                Config.DefaultBuilders.Remove(defaultBuilder);

                // Replace the dummy dependency with the dynamically created one
                var dependentBuilders = Config.Builders.Where(b => b.Dependencies.Any(d => d.Equals(defaultBuilder)));
                foreach (var dependentBuilder in dependentBuilders)
                {
                    var index = dependentBuilder.Dependencies.IndexOf(dependentBuilder.Dependencies.First(d => d.Equals(defaultBuilder)));
                    dependentBuilder.Dependencies[index] = builder;
                }
            }

            // Check for circular dependency
            Config.Builders.TopologicalSort(b => b.Dependencies, comparer);

            if (Config.DefaultBuilders.Any())
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

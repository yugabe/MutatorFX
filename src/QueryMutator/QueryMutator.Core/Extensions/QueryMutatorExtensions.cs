using System;
using Microsoft.Extensions.DependencyInjection;

namespace QueryMutator.Core
{
    /// <summary>
    /// Globally usable extensions for configuration purposes.
    /// </summary>
    public static class QueryMutatorExtensions
    {
        /// <summary>
        /// Creates the mapper instance using the supplied configuration <paramref name="config"/>, then handles 
        /// registering the mapper and the individual mappings to the service container <paramref name="services"/>.
        /// </summary>
        /// <param name="config">The object that contains the mappings and options necessary to create the mapper.</param>
        /// <param name="registerIndividualMappings">Specifies if individual mappings should be registered to the DI container.</param>
        /// <returns></returns>
        public static IServiceCollection UseQueryMutator(this IServiceCollection services, MapperConfiguration config, bool registerIndividualMappings = false)
        {
            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);
            
            if (registerIndividualMappings)
            {
                foreach (var mapping in (mapper as Mapper).Mappings)
                {
                    Type mappingType = null;
                    if (mapping.Key.ParameterType != null)
                    {
                        mappingType = typeof(IMapping<,,>).MakeGenericType(new[] { mapping.Key.SourceType, mapping.Key.TargetType, mapping.Key.ParameterType });
                    }
                    else
                    {
                        mappingType = typeof(IMapping<,>).MakeGenericType(new[] { mapping.Key.SourceType, mapping.Key.TargetType });
                    }
                    services.AddSingleton(mappingType, mapping.Value);
                }
            }
            
            return services;
        }
    }
}

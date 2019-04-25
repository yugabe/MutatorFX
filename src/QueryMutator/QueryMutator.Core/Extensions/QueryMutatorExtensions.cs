using System;
using Microsoft.Extensions.DependencyInjection;

namespace QueryMutator.Core
{
    public static class QueryMutatorExtensions
    {
        public static IServiceCollection UseQueryMutator(this IServiceCollection services, MapperConfiguration config)
        {
            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);
            
            // TODO maybe add config option whether to register individual mappings or not?
            foreach(var mapping in (mapper as Mapper).Mappings)
            {
                Type mappingType = null;
                if(mapping.Key.ParameterType != null)
                {
                    mappingType = typeof(IMapping<,,>).MakeGenericType(new[] { mapping.Key.SourceType, mapping.Key.TargetType, mapping.Key.ParameterType });
                }
                else
                {
                    mappingType = typeof(IMapping<,>).MakeGenericType(new[] { mapping.Key.SourceType, mapping.Key.TargetType });
                }
                services.AddSingleton(mappingType, mapping.Value);
            }
            
            return services;
        }
    }
}

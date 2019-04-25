using System;
using System.Collections.Generic;
using System.Reflection;

namespace QueryMutator.Core
{
    public interface IMapperConfigurationExpression
    {
        void CreateMapping<TSource, TTarget>();

        void CreateMapping<TSource, TTarget>(Action<IMappingBuilder<TSource, TTarget>> mappingFactory);

        void CreateMapping<TSource, TTarget, TParam>(Action<IMappingBuilder<TSource, TTarget, TParam>> mappingFactory);

        void UseAttributeMapping(IEnumerable<Assembly> assemblies);
    }
}

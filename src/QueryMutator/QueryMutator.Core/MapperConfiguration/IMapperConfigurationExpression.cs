using System;
using System.Collections.Generic;
using System.Reflection;

namespace QueryMutator.Core
{
    /// <summary>
    /// Represents an object which can be used to define mappings.
    /// </summary>
    public interface IMapperConfigurationExpression
    {
        /// <summary>
        /// Creates a new default mapping between the <typeparamref name="TSource"/> and <typeparamref name="TTarget"/> types.
        /// </summary>
        /// <typeparam name="TSource">The source type of the mapping.</typeparam>
        /// <typeparam name="TTarget">The target type of the mapping.</typeparam>
        /// <exception cref="MappingAlreadyExistsException">Thrown when another mapping with the same generic parameters already exists.</exception>
        void CreateMapping<TSource, TTarget>();

        /// <summary>
        /// Creates a new mapping between the <typeparamref name="TSource"/> and <typeparamref name="TTarget"/> types,
        /// using the supplied <paramref name="mappingFactory"/> options.
        /// </summary>
        /// <typeparam name="TSource">The source type of the mapping.</typeparam>
        /// <typeparam name="TTarget">The target type of the mapping.</typeparam>
        /// <exception cref="MappingAlreadyExistsException">Thrown when another mapping with the same generic parameters already exists.</exception>
        void CreateMapping<TSource, TTarget>(Action<IMappingBuilder<TSource, TTarget>> mappingFactory);

        /// <summary>
        /// Creates a new mapping between the <typeparamref name="TSource"/>, <typeparamref name="TTarget"/> and <typeparamref name="TParam"/> types,
        /// using the supplied <paramref name="mappingFactory"/> options.
        /// </summary>
        /// <typeparam name="TSource">The source type of the mapping.</typeparam>
        /// <typeparam name="TTarget">The target type of the mapping.</typeparam>
        /// <typeparam name="TParam">The parameter type of the mapping.</typeparam>
        /// <exception cref="MappingAlreadyExistsException">Thrown when another mapping with the same generic parameters already exists.</exception>
        void CreateMapping<TSource, TTarget, TParam>(Action<IMappingBuilder<TSource, TTarget, TParam>> mappingFactory);

        /// <summary>
        /// Enable scanning the supplied <paramref name="assemblies"/> for objects decorated with the <see cref="MapFromAttribute"/> attribute.
        /// </summary>
        /// <param name="assemblies">The list of assemblies to be scanned.</param>
        void UseAttributeMapping(IEnumerable<Assembly> assemblies);
    }
}

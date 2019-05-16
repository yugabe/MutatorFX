using System.Collections.Generic;

namespace QueryMutator.Core
{
    /// <summary>
    /// Represents an object that contains mappings.
    /// </summary>
    public interface IMapper
    {
        /// <summary>
        /// Return a mapping specified by the <typeparamref name="TSource"/> and <typeparamref name="TTarget"/> types.
        /// </summary>
        /// <typeparam name="TSource">The source type of the mapping.</typeparam>
        /// <typeparam name="TTarget">The target type of the mapping.</typeparam>
        /// <exception cref="MappingNotFoundException">Thrown when the mapping is not found.</exception>
        /// <returns>The specified mapping.</returns>
        IMapping<TSource, TTarget> GetMapping<TSource, TTarget>();

        /// <summary>
        /// Return a mapping specified by the <typeparamref name="TSource"/>, <typeparamref name="TTarget"/> and <typeparamref name="TParam"/> types.
        /// </summary>
        /// <typeparam name="TSource">The source type of the mapping.</typeparam>
        /// <typeparam name="TTarget">The target type of the mapping.</typeparam>
        /// <typeparam name="TParam">The parameter type of the mapping.</typeparam>
        /// <exception cref="MappingNotFoundException">Thrown when the mapping is not found.</exception>
        /// <returns>The specified mapping.</returns>
        IMapping<TSource, TTarget, TParam> GetMapping<TSource, TTarget, TParam>();
    }

    internal class Mapper : IMapper
    {
        public Dictionary<MappingKey, IMapping> Mappings { get; set; }

        public IMapping<TSource, TTarget> GetMapping<TSource, TTarget>()
        {
            if (Mappings.TryGetValue(new MappingKey(typeof(TSource), typeof(TTarget)), out var mapping))
            {
                return mapping as Mapping<TSource, TTarget>;
            }
            else
            {
                throw new MappingNotFoundException("Specified mapping was not found");
            }
        }

        public IMapping<TSource, TTarget, TParam> GetMapping<TSource, TTarget, TParam>()
        {
            if (Mappings.TryGetValue(new MappingKey(typeof(TSource), typeof(TTarget), typeof(TParam)), out var mapping))
            {
                return mapping as Mapping<TSource, TTarget, TParam>;
            }
            else
            {
                throw new MappingNotFoundException("Specified mapping was not found");
            }
        }
    }
}

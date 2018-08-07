using System.Linq;

namespace MutatorFX.FilterMutator
{
    /// <summary>
    /// Represents an object that can provide an <see cref="IQueryable{TSource}"/> datasource.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source dataset.</typeparam>
    public interface ISourceAccessor<out TSource>
    {
        /// <summary>
        /// The <typeparamref name="TSource"/> elements, represented by a queryable object.
        /// </summary>
        IQueryable<TSource> Source { get; }
    }
}

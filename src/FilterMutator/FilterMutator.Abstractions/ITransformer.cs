using System.Linq;

namespace MutatorFX.FilterMutator
{
    /// <summary>
    /// Represents a transformation between the types <typeparamref name="TSource"/> and <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TSource">The source type to transform objects from.</typeparam>
    /// <typeparam name="TResult">The result type to transform objects to.</typeparam>
    public interface ITransformer<in TSource, out TResult>
    {
        /// <summary>
        /// Apply a transformation to a queryable of source objects, which produce a queryable of result objects.
        /// </summary>
        /// <param name="source">The source queryable to transform.</param>
        /// <returns>The transformed elements of <typeparamref name="TSource"/>.</returns>
        IQueryable<TResult> Transform(IQueryable<TSource> source);
    }
}

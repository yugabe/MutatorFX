using System.Linq;

namespace MutatorFX.FilterMutator
{
    /// <summary>
    /// Represents an implementation of a sorting algorithm based on a typed enum.
    /// </summary>
    /// <typeparam name="TSource">The source item type to sort.</typeparam>
    /// <typeparam name="TSort"></typeparam>
    public interface ISorter<TSource, in TSort>
    {
        /// <summary>
        /// Sort a given dataset by the provided sort enum value and order.
        /// </summary>
        /// <param name="filtered">The filtered dataset to sort.</param>
        /// <param name="sort">The sort value to sort the dataset by.</param>
        /// <param name="sortDescending">Whether to order the resultset in descending or ascending order.</param>
        /// <returns>The sorted queryable object.</returns>
        IQueryable<TSource> Sort(IQueryable<TSource> filtered, TSort sort, bool sortDescending);
    }
}

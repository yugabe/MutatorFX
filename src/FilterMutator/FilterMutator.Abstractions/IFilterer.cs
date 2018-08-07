using System.Linq;

namespace MutatorFX.FilterMutator
{
    /// <summary>
    /// The interface which represents an object that can apply filtering to a dataset.
    /// </summary>
    /// <typeparam name="TSource">The source type to apply filtering to.</typeparam>
    /// <typeparam name="TFilter">The filter type to use when filtering.</typeparam>
    public interface IFilterer<TSource, in TFilter>
    {
        /// <summary>
        /// Filter a given dataset with a given filter object.
        /// </summary>
        /// <param name="source">The source to apply filtering to.</param>
        /// <param name="filter">The filter to use for filtering.</param>
        /// <returns>The filtered dataset, represented by a queryable object.</returns>
        IQueryable<TSource> Filter(IQueryable<TSource> source, TFilter filter);
    }
}

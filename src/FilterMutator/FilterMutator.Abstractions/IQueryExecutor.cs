using System;

namespace MutatorFX.FilterMutator
{
    /// <summary>
    /// Represents an object which can filter, page and sort a dataset.
    /// </summary>
    /// <typeparam name="TFilter">The filter object type to use for filtering.</typeparam>
    /// <typeparam name="TSort">The sorting enum type to use when ordering the resultset.</typeparam>
    /// <typeparam name="TResult">The type of the objects included in the paged result object.</typeparam>
    public interface IQueryExecutor<in TFilter, in TSort, out TResult>
        where TSort : Enum
    {
        /// <summary>
        /// Executes filtering on a source dataset with the given parameters.
        /// </summary>
        /// <param name="filter">The filter object used to filter the source dataset.</param>
        /// <param name="page">The 1-based page number to use for paging the results.</param>
        /// <param name="pageSize">The size of the page to use for paging the results.</param>
        /// <param name="sorting">The sorting value to use when querying the source dataset.</param>
        /// <param name="sortDescending">The order of sorting to use when querying the source dataset.</param>
        /// <returns>The filtered, sorted and paged resultset and paging metadata.</returns>
        IPagedResult<TResult> ExecuteQuery(TFilter filter, int page, int pageSize, TSort sorting, bool sortDescending);
    }
}

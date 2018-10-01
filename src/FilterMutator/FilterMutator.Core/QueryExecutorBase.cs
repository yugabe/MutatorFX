using System;
using System.Linq;

namespace MutatorFX.FilterMutator
{
    /// <summary>A base implementation that provides a paging mechanism and composes the query to a resultset.</summary>
    /// <typeparam name="TSource">The type of the elements in the source dataset.</typeparam>
    /// <typeparam name="TResult">The type of the elements in the result dataset.</typeparam>
    /// <typeparam name="TFilter">The type of the filter used in filtering the dataset.</typeparam>
    /// <typeparam name="TSort">The enum type that is used to sort the dataset before paging is applied.</typeparam>
    public abstract class QueryExecutorBase<TSource, TResult, TFilter, TSort> : IQueryExecutor<TFilter, TSort, TResult>, ISourceAccessor<TSource>, IFilterer<TSource, TFilter>, ITransformer<TSource, TResult>, ISorter<TSource, TSort>, IPager<TResult>
        where TSort : Enum
    {
        /// <summary>
        /// Executes the query with the given filtering, paging and sorting parameters on the source dataset.
        /// </summary>
        /// <param name="filter">The filter object to use when filtering the queryable source dataset.</param>
        /// <param name="page">The page requested for the query.</param>
        /// <param name="pageSize">The page size requested for the query.</param>
        /// <param name="sorting">The sorting used when querying the dataset.</param>
        /// <param name="sortDescending">Whether to use descending ordering of the results in the dataset.</param>
        /// <returns></returns>
        public virtual PagedResult<TResult> ExecuteQuery(TFilter filter, int page, int pageSize, TSort sorting, bool sortDescending)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter), "The provided filter must not be null.");

            var results = Filter(Source, filter);
            return new PagedResult<TResult>(Page(Transform(Sort(results, sorting, sortDescending)), page, pageSize).ToList(), page, pageSize, results.Count());
        }

        /// <summary>
        /// The accessor for the queryable datasource.
        /// </summary>
        public abstract IQueryable<TSource> Source { get; }

        /// <summary>
        /// Filters the given queryable datasource with the given filter.
        /// </summary>
        /// <param name="source">The source to filter.</param>
        /// <param name="filter">The filter object to use when filtering the source.</param>
        /// <returns>The filtered datasource queryable.</returns>
        public abstract IQueryable<TSource> Filter(IQueryable<TSource> source, TFilter filter);

        /// <summary>
        /// Transforms the given <typeparamref name="TSource"/> datasource to a set of <typeparamref name="TResult"/> results.
        /// </summary>
        /// <param name="source">The source to transform.</param>
        /// <returns>The transformed queryable datasource.</returns>
        public abstract IQueryable<TResult> Transform(IQueryable<TSource> source);

        /// <summary>
        /// Sorts the queryable datasource with the given sorting options.
        /// </summary>
        /// <param name="filtered">The dataset to sort.</param>
        /// <param name="sort">The sorting enum used to parameterize the sorting.</param>
        /// <param name="sortDescending">Whether to use descending ordering for sorting.</param>
        /// <returns>The sorted queryable dataset.</returns>
        public abstract IQueryable<TSource> Sort(IQueryable<TSource> filtered, TSort sort, bool sortDescending);

        /// <summary>
        /// Apply paging to a resultset queryable.
        /// </summary>
        /// <param name="results">The results to apply paging to.</param>
        /// <param name="page">The page requested.</param>
        /// <param name="pageSize">The page size requested.</param>
        /// <returns>The elements in the queryable corresponding to the requested page.</returns>
        public abstract IQueryable<TResult> Page(IQueryable<TResult> results, int page, int pageSize);
    }
}

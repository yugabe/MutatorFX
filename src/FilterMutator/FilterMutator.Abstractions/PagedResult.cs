using System.Collections.Generic;
using System.Linq;

namespace MutatorFX.FilterMutator
{
    /// <summary>
    /// An encapsulating object, which can provide a set of results and paging metadata.
    /// </summary>
    /// <typeparam name="TResult">The type of the objects in the result dataset.</typeparam>
    public sealed class PagedResult<TResult>
    {
        /// <summary>
        /// Create a PagedResult object, which sets all relevant paging metadata for the given resultset.
        /// </summary>
        /// <param name="results">The results to contain with this paging object.</param>
        /// <param name="page">The page the relevant results are listed for.</param>
        /// <param name="pageSize">The size of the page for which the relevant results are listed for.</param>
        /// <param name="totalItems">The number of total items for which this object contains one page of.</param>
        public PagedResult(IReadOnlyList<TResult> results, int page, int pageSize, int totalItems)
        {
            Results = results.ToList();
            Page = page;
            PageSize = pageSize;
            TotalItems = totalItems;
        }

        /// <summary>
        /// The results contained on the page represented by this object.
        /// </summary>
        public IReadOnlyList<TResult> Results { get; }

        /// <summary>
        /// The total number of source items regarding the current objects paging metadata.
        /// </summary>
        public int TotalItems { get; }

        /// <summary>
        /// The page of results this object represents.
        /// </summary>
        public int Page { get; }

        /// <summary>
        /// The size of the page for the results this object represents.
        /// </summary>
        public int PageSize { get; }
    }
}

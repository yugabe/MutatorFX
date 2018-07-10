using System.Collections.Generic;
using System.Linq;

namespace MutatorFX.FilterMutator
{
    internal sealed class PagedResult<TResult> : IPagedResult<TResult>
    {
        public PagedResult(IEnumerable<TResult> results, int page, int pageSize, int totalItems)
        {
            Results = results.ToList();
            Page = page;
            PageSize = pageSize;
            TotalItems = totalItems;
        }
        public IReadOnlyList<TResult> Results { get; }
        public int TotalItems { get; }
        public int Page { get; }
        public int PageSize { get; }
    }
}

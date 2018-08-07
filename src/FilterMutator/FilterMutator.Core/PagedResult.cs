using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MutatorFX.FilterMutator
{
    /// <summary>
    /// Internal, trivial <see cref="IPagedResult{TResult}"/> implementation. 
    /// All objects aquired as constructor parameters are provided via properties.
    /// </summary>
    /// <typeparam name="TResult">The type of the objects in the result dataset.</typeparam>
    internal sealed class PagedResult<TResult> : IPagedResult<TResult>
    {
        public PagedResult(IQueryable<TResult> results, int page, int pageSize, int totalItems)
        {
            Results = results.ToList();
            Page = page;
            PageSize = pageSize;
            TotalItems = totalItems;
        }

        public TResult this[int index] => Results[index];

        public IReadOnlyList<TResult> Results { get; }
        public int TotalItems { get; }
        public int Page { get; }
        public int PageSize { get; }

        public int Count => Results.Count;

        public IEnumerator<TResult> GetEnumerator() => Results.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

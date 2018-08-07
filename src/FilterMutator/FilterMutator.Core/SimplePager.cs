using System;
using System.Linq;

namespace MutatorFX.FilterMutator
{
    /// <summary>
    /// A simple paging implementation that uses <see cref="Queryable.Skip{TSource}(IQueryable{TSource}, int)"/> and <see cref="Queryable.Take{TSource}(IQueryable{TSource}, int)"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of the elements in the dataset to page.</typeparam>
    public sealed class SimplePager<TResult> : IPager<TResult>
    {
        /// <summary>
        /// Get the paged results based on the input parameters.
        /// </summary>
        /// <param name="results">The results to page.</param>
        /// <param name="page">The value of the page. Should be positive.</param>
        /// <param name="pageSize">The page size to apply when paging. Should be positive.</param>
        /// <returns></returns>
        public IQueryable<TResult> Page(IQueryable<TResult> results, int page, int pageSize) =>
            page < 1 ? throw new ArgumentOutOfRangeException(nameof(page), "The value must be at least 1.")
                : pageSize < 1 ? throw new ArgumentOutOfRangeException(nameof(pageSize), "The value must be at least 1.")
                : results.Skip(page - 1 * pageSize).Take(pageSize);
    }
}

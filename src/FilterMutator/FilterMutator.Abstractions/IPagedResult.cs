using System.Collections.Generic;

namespace MutatorFX.FilterMutator
{
    /// <summary>
    /// An encapsulating object, which can provide a set of results and paging metadata.
    /// </summary>
    /// <typeparam name="TResult">The result of the object type.</typeparam>
    public interface IPagedResult<out TResult> : IReadOnlyList<TResult>
    {
        /// <summary>
        /// The immutable collection of result objects materialized.
        /// </summary>
        IReadOnlyList<TResult> Results { get; }

        /// <summary>
        /// The number of total items before paging was applied.
        /// </summary>
        int TotalItems { get; }

        /// <summary>
        /// The page this object contains results for.
        /// </summary>
        int Page { get; }

        /// <summary>
        /// The size of the page this object contains results for.
        /// </summary>
        int PageSize { get; }
    }
}

using System.Linq;

namespace MutatorFX.FilterMutator
{
    /// <summary>
    /// Represents an object which can create a paged result in the form of a queryable object.
    /// </summary>
    /// <typeparam name="TResult">The type of the elements in the resultset.</typeparam>
    public interface IPager<TResult>
    {
        /// <summary>
        /// Apply paging to a queryable object. The source should refer to the full dataset to be paged.
        /// </summary>
        /// <param name="source">The source objects represented in the form of a queryable object.</param>
        /// <param name="page">The 1-based page number requested. Should be positive.</param>
        /// <param name="pageSize">The size of the page requested. Should be positive.</param>
        /// <returns></returns>
        IQueryable<TResult> Page(IQueryable<TResult> source, int page, int pageSize);
    }
}

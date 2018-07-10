using System.Collections.Generic;

namespace MutatorFX.FilterMutator
{
    public interface IPagedResult<out TResult>
    {
        IReadOnlyList<TResult> Results { get; }
        int TotalItems { get; }
        int Page { get; }
        int PageSize { get; }
    }
}

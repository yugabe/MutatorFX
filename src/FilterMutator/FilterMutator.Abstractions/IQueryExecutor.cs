using System;

namespace MutatorFX.FilterMutator
{
    public interface IQueryExecutor<in TFilter, in TSort, out TResult>
        where TSort : Enum
    {
        IPagedResult<TResult> ExecuteQuery(TFilter filter, int page, int pageSize, TSort sorting, bool sortDescending);
    }
}

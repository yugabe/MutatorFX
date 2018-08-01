using System;
using System.Linq;
using System.Linq.Expressions;

namespace MutatorFX.FilterMutator
{
    public interface IFilterClause<TSource, in TFilter>
    {
        object GetClause(TFilter filter);
        bool IsClauseEnabled(TFilter filter);
        Expression<Func<TSource, bool>> GetFilterPredicate(TFilter filter);
        Expression<Func<TSource, bool>> GetOnDisabledFilterPredicate();
        IQueryable<TSource> Execute(IQueryable<TSource> source, TFilter filter);
    }
}

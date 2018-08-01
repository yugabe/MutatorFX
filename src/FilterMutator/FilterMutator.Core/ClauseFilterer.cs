using System.Collections.Generic;
using System.Linq;

namespace MutatorFX.FilterMutator
{
    public abstract class ClauseFilterer<TSource, TFilter> : IFilterer<TSource, TFilter>
    {
        public abstract IEnumerable<IFilterClause<TSource, TFilter>> GetClauses();
        public virtual IQueryable<TSource> Filter(IQueryable<TSource> source, TFilter filter)
            => GetClauses().Aggregate(source, (s, c) => c.Execute(s, filter));

        public static ClauseCollection<TSource, TFilter> CreateClauses() => new ClauseCollection<TSource, TFilter>();
    }
}

using MutatorFX.FluentExtensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MutatorFX.FilterMutator
{
    public sealed class ClauseCollection<TSource, TFilter> : IEnumerable<IFilterClause<TSource, TFilter>>
    {
        private ICollection<IFilterClause<TSource, TFilter>> FilterClauses { get; } = new List<IFilterClause<TSource, TFilter>>();
        public IEnumerable<IFilterClause<TSource, TFilter>> Clauses => FilterClauses;
        public static ClauseCollection<TSource, TFilter> Create() => new ClauseCollection<TSource, TFilter>();

        public ClauseCollection<TSource, TFilter> AddClause<TClause>(Expression<Func<TFilter, TClause>> filterClauseSelector,
            Func<TClause, Expression<Func<TSource, bool>>> filterPredicate,
            Expression<Func<TSource, bool>> onDisabledFilterPredicate = null,
            Func<TFilter, bool> isClauseEnabled = null)
        => this.Do(c => c.FilterClauses.Add(new FilterClause<TSource, TFilter, TClause>(filterClauseSelector, filterPredicate, onDisabledFilterPredicate, isClauseEnabled)));

        public IEnumerator<IFilterClause<TSource, TFilter>> GetEnumerator() => Clauses.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Clauses.GetEnumerator();
    }
}

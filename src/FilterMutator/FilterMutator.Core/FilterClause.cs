using MutatorFX.FluentExtensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MutatorFX.FilterMutator
{
    public class FilterClause<TSource, TFilter, TClause> : IFilterClause<TSource, TFilter>
    {
        public FilterClause(
            Expression<Func<TFilter, TClause>> filterClauseSelector,
            Func<TClause, Expression<Func<TSource, bool>>> filterPredicate = null,
            Expression<Func<TSource, bool>> onDisabledFilterPredicate = null,
            Func<TFilter, bool> isClauseEnabled = null,
            Dictionary<string, object> options = null)
        {
            ClauseExpression = filterClauseSelector;
            FilterClauseSelectorFunc = filterClauseSelector.Compile();
            FilterPredicate = filterPredicate;
            OnDisabledFilterPredicate = onDisabledFilterPredicate;
            IsClauseEnabledFunc = isClauseEnabled;
            Options = options;
        }

        public Func<TFilter, bool> IsClauseEnabledFunc { get; }
        public IReadOnlyDictionary<string, object> Options { get; }
        public Func<TFilter, TClause> FilterClauseSelectorFunc { get; }
        public Func<TClause, Expression<Func<TSource, bool>>> FilterPredicate { get; }
        public Expression<Func<TSource, bool>> OnDisabledFilterPredicate { get; }
        public Expression ClauseExpression { get; }

        object IFilterClause<TSource, TFilter>.GetClause(TFilter filter) => GetClause(filter);

        public virtual TClause GetClause(TFilter filter) => FilterClauseSelectorFunc(filter);

        public Expression<Func<TSource, bool>> GetFilterPredicate(TFilter filter) => FilterPredicate?.Invoke(GetClause(filter));

        public Expression<Func<TSource, bool>> GetOnDisabledFilterPredicate() => OnDisabledFilterPredicate ?? (s => true);

        public bool IsClauseEnabled(TFilter filter)
            => IsClauseEnabledFunc?.Invoke(filter) ?? EqualityComparer<TClause>.Default.Equals(GetClause(filter), default);

        public virtual IQueryable<TSource> Execute(IQueryable<TSource> source, TFilter filter)
            => source.Where(IsClauseEnabled(filter) ? GetFilterPredicate(filter) ?? (s => true) : GetOnDisabledFilterPredicate());
    }
}

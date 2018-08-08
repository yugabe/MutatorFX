using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MutatorFX.FilterMutator
{
    /// <summary>
    /// Represents the default implementation of a clause used for filtering. Provides a way to select 
    /// a clause from a filter object, execute the clause on a given dataset, or fallback to a default
    /// filtering mechanism when the clause is considered disabled.
    /// </summary>
    /// <typeparam name="TSource">The type of the source objects in the dataset to be filtered.</typeparam>
    /// <typeparam name="TFilter">The filter type to select the clause from to apply to the dataset.</typeparam>
    /// <typeparam name="TClause">The type of the selected clause.</typeparam>
    public class FilterClause<TSource, TFilter, TClause> : IFilterClause<TSource, TFilter>
    {
        /// <summary>
        /// Create a new clause used for filtering.
        /// </summary>
        /// <param name="filterClauseSelector">
        /// A selector that can be used to aquire the clause value from a given filter. As 
        /// it is an Expression, it can be used to rationalize about a collection of clauses.
        /// </param>
        /// <param name="filterPredicate">
        /// The predicate factory to use when building the filtering expressions. Can be a lambda,
        /// that gets the selected clause value from the filter as parameter, that returns another lamdbda
        /// that uses closure on the outer clause parameter to apply dynamically parametered filtering.
        /// <para/>Example:
        /// <code lang="csharp">
        /// (clause: Clause) => (source: TSource) => source.Name.Contains(clause); 
        /// <para/> // shorter version: <para/> c => s => s.Name.Contains(c);
        /// </code>
        /// </param>
        /// <param name="onDisabledFilterPredicate">A predicate that gets used instead of 
        /// <paramref name="filterPredicate"/> when the clause is considered disabled.</param>
        /// <param name="isClauseEnabled">A predicate that indicates whether the clause is to be
        /// considered enabled.</param>
        /// <param name="options">Additional untyped options. Can be used for extensibility to add 
        /// state or configuration to the clause via extensions.</param>
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

        private Func<TFilter, bool> IsClauseEnabledFunc { get; }
        private Func<TFilter, TClause> FilterClauseSelectorFunc { get; }
        private Func<TClause, Expression<Func<TSource, bool>>> FilterPredicate { get; }
        private Expression<Func<TSource, bool>> OnDisabledFilterPredicate { get; }
        
        /// <summary>
        /// The options passed to this clause instance used to apply additional logic 
        /// based on state via extensions.
        /// </summary>
        public IReadOnlyDictionary<string, object> Options { get; }

        /// <summary>
        /// The expression that represents the clause selector. Can be used to rationalize
        /// about this clause in regards to other clauses (i.e. to check whether all filter
        /// properties are matched in a collection of clauses).
        /// </summary>
        public Expression ClauseExpression { get; }

        /// <summary>
        /// Gets the clause object's value by applying the clause selector to the filter.
        /// </summary>
        /// <param name="filter">The filter object to apply the selector to.</param>
        /// <returns>The clause value in the given object.</returns>
        object IFilterClause<TSource, TFilter>.GetClause(TFilter filter) => GetClause(filter);

        /// <summary>
        /// Gets the clause object's value by applying the clause selector to the filter.
        /// </summary>
        /// <param name="filter">The filter object to apply the selector to.</param>
        /// <returns>The clause value in the given object.</returns>
        public virtual TClause GetClause(TFilter filter) => FilterClauseSelectorFunc(filter);

        /// <summary>
        /// Get the predicate expression for a given source item by a given filter, which
        /// indicates whether the given source item should be in the filtered resultset or not.
        /// </summary>
        /// <param name="filter">The filter object to get the predicate clause from.</param>
        /// <returns>The expression that represents a predicate delegate, that can be used to
        /// filter the source dataset by the clause value. Returns null if the 
        /// <see cref="FilterPredicate"/> is null.</returns>
        public Expression<Func<TSource, bool>> GetFilterPredicate(TFilter filter) => FilterPredicate?.Invoke(GetClause(filter));

        /// <summary>
        /// Gets the predicate that should be applied when the filter is considered disabled.
        /// If no custom predicate was supplied, the default is an always truthy predicate.
        /// </summary>
        /// <returns>The predicate to use for filtering, or a truthy predicate if none was supplied.</returns>
        public Expression<Func<TSource, bool>> GetOnDisabledFilterPredicate() => OnDisabledFilterPredicate ?? (s => true);

        /// <summary>
        /// Determine whether the clause is enabled for the given filter.
        /// Uses the <typeparamref name="TClause"/> type's default <see cref="EqualityComparer{T}"/> if none was supplied.
        /// </summary>
        /// <param name="filter">The filter to use when checking the clause's disabled state.</param>
        /// <returns>True if the filter is considered enabled.</returns>
        public bool IsClauseEnabled(TFilter filter)
            => IsClauseEnabledFunc?.Invoke(filter) ?? !EqualityComparer<TClause>.Default.Equals(GetClause(filter), default);

        /// <summary>
        /// Executes a filtering by applying one of provided predicates to filter the given datasource.
        /// </summary>
        /// <param name="source">The source to filter by this clause's value.</param>
        /// <param name="filter">The filter to get the clause value from.</param>
        /// <returns>The dataset filtered by the predicate described by this clause.</returns>
        public virtual IQueryable<TSource> Execute(IQueryable<TSource> source, TFilter filter)
            => source.Where(IsClauseEnabled(filter) ? GetFilterPredicate(filter) ?? (s => true) : GetOnDisabledFilterPredicate());
    }
}

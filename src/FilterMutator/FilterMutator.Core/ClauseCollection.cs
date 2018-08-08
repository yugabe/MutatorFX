using MutatorFX.Coding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MutatorFX.FilterMutator
{
    /// <summary>
    /// A collection of filtering clause objects.
    /// </summary>
    /// <typeparam name="TSource">The source type to use when filtering.</typeparam>
    /// <typeparam name="TFilter">The filter type to apply when filtering.</typeparam>
    public sealed class ClauseCollection<TSource, TFilter> : IEnumerable<IFilterClause<TSource, TFilter>>
    {
        private ICollection<IFilterClause<TSource, TFilter>> FilterClauses { get; } = new List<IFilterClause<TSource, TFilter>>();

        /// <summary>
        /// The clauses contained in this collection.
        /// </summary>
        public IEnumerable<IFilterClause<TSource, TFilter>> Clauses => FilterClauses;

        /// <summary>
        /// Adds an <see cref="IFilterClause{TSource, TFilter}"/> instance to the current collection. 
        /// This method can be used for applying extensions for custom filtering clause implementations.
        /// </summary>
        /// <typeparam name="TClause">The type of the selected clause from <typeparamref name="TFilter"/>. Should be inferred.</typeparam>
        /// <param name="filterClauseSelector">The accessor used to get the clause value from a filter.</param>
        /// <param name="filterPredicate">The predicate factory that's used to generate the filtering expression based on the current clause value.</param>
        /// <param name="onDisabledFilterPredicate">A predicate that is used when the clause is considered disabled for a given filter. The default returns a constant true value for each item in the collection.</param>
        /// <param name="isClauseEnabled">A function that determines whether the current clause is enabled for a given filter.</param>
        /// <param name="options">Additional options that can be passed to the clause. Will be converted to a <see cref="string"/>-<see cref="string"/> <see cref="Dictionary{TKey, TValue}"/>, so the keys should be unique amongst the parameters.</param>
        /// <returns>The current collection after that clause was added to it.</returns>
        public ClauseCollection<TSource, TFilter> AddClause<TClause>(Expression<Func<TFilter, TClause>> filterClauseSelector,
            Func<TClause, Expression<Func<TSource, bool>>> filterPredicate,
            Expression<Func<TSource, bool>> onDisabledFilterPredicate = null,
            Func<TFilter, bool> isClauseEnabled = null,
            params (string key, object value)[] options)
        => this.Do(c => c.FilterClauses.Add(new FilterClause<TSource, TFilter, TClause>(filterClauseSelector, filterPredicate, onDisabledFilterPredicate, isClauseEnabled, options.ToDictionary(kv => kv.key, kv => kv.value))));

        /// <summary>Returns the enumerator for the <see cref="Clauses"/> in the collection.</summary>
        public IEnumerator<IFilterClause<TSource, TFilter>> GetEnumerator() => Clauses.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Clauses.GetEnumerator();
    }
}

using System;
using System.Linq;
using System.Linq.Expressions;

namespace MutatorFX.FilterMutator
{
    /// <summary>
    /// The common interface for clauses that can describe elements in a filter object.
    /// </summary>
    /// <typeparam name="TSource">The source object type which filtering occurs on.</typeparam>
    /// <typeparam name="TFilter">The type of the filter used for filtering.</typeparam>
    public interface IFilterClause<TSource, in TFilter>
    {
        /// <summary>
        /// The expression which selects the clause. It is usually a <see cref="LambdaExpression"/>, which encapsulates a <see cref="Func{T, bool}"/> delegate.
        /// </summary>
        Expression ClauseExpression { get; }

        /// <summary>
        /// The value of the clause selected from the filter by the <see cref="ClauseExpression"/>.
        /// </summary>
        /// <param name="filter">The filter to get the clause from.</param>
        /// <returns>The value of the clause, as returned by the clause selector (<see cref="ClauseExpression"/>).</returns>
        object GetClause(TFilter filter);

        /// <summary>
        /// Indicates whether the clause is enabled or not on a given filter.
        /// </summary>
        /// <param name="filter">The filter to check to determine whether the clause is enabled or not.</param>
        /// <returns>True if the clause is enabled and should be evaluated.</returns>
        bool IsClauseEnabled(TFilter filter);

        /// <summary>
        /// The predicate that can be passed to the filtering function.
        /// </summary>
        /// <param name="filter">The filter to use the values from. Can also use the clause selector expression 
        /// to get the clause value and check whether the clause is enabled.</param>
        /// <returns>An expression encapsulating a predicate typed delegate, which determines whether an element
        /// matches the given clause for the given filter values or not.</returns>
        Expression<Func<TSource, bool>> GetFilterPredicate(TFilter filter);

        /// <summary>
        /// A fallback expression that should be used when a cluase is disabled. A good default can be a function
        /// that returns the constant true value, thus not filtering the input set of data.
        /// </summary>
        /// <returns>The fallback expression to use when the clause is disabled.</returns>
        Expression<Func<TSource, bool>> GetOnDisabledFilterPredicate();

        /// <summary>
        /// Executes the clause on the given IQueryable datasource.
        /// </summary>
        /// <param name="source">The source dataset to filter.</param>
        /// <param name="filter">The filter to apply to the dataset for this clause.</param>
        /// <returns>The filtered dataset, represented by a queryable object.</returns>
        IQueryable<TSource> Execute(IQueryable<TSource> source, TFilter filter);
    }
}

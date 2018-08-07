using System.Collections.Generic;
using System.Linq;

namespace MutatorFX.FilterMutator
{
    /// <summary>
    /// A simple <see cref="IFilterer{TSource, TFilter}"/> implementation base class for creating a clause-based filtering mechanism.
    /// </summary>
    /// <typeparam name="TSource">The type of the source dataset items.</typeparam>
    /// <typeparam name="TFilter">The type of the input filter used for filtering and creating clauses.</typeparam>
    public abstract class ClauseFilterer<TSource, TFilter> : IFilterer<TSource, TFilter>
    {
        /// <summary>
        /// Get the clauses, which will be used to filter the input datasource with a given filter.
        /// You can use the shorthand static method <see cref="CreateClauses"/> to create a static collection and refer it from here,
        /// so that instantiations of the clauses don't happen every time. Take caution not to create the collection every time this 
        /// method gets called unless you intend to generate them at runtime, because it can have performance repercussions.
        /// </summary>
        /// <returns>The clauses used for aggregating over the source dataset.</returns>
        public abstract IEnumerable<IFilterClause<TSource, TFilter>> GetClauses();

        /// <summary>
        /// Executes all the available clauses over the given <paramref name="source"/> with values obtained for the clauses from the <paramref name="filter"/>.
        /// </summary>
        /// <param name="source">The source to filter with the clauses.</param>
        /// <param name="filter">The filter to use when filtering <paramref name="source"/> with the clauses provided by <see cref="GetClauses"/>.</param>
        /// <returns>The filtered elements from the <paramref name="source"/>.</returns>
        public virtual IQueryable<TSource> Filter(IQueryable<TSource> source, TFilter filter)
            => GetClauses().Aggregate(source, (s, c) => c.Execute(s, filter));

        /// <summary>
        /// Factory method to create a generic <see cref="ClauseCollection{TSource, TFilter}"/> for the current type.
        /// Can be used in non-static context to infer the generic type arguments for the collection.
        /// </summary>
        /// <returns>An empty collection of clauses, which can be used to build the individual filter clauses.</returns>
        public static ClauseCollection<TSource, TFilter> CreateClauses() => new ClauseCollection<TSource, TFilter>();
    }
}

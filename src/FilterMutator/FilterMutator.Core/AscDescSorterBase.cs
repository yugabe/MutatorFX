using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MutatorFX.FilterMutator
{
    /// <summary>
    /// A simple abstract base class for sorting a datasource in ascending or descending order.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source dataset.</typeparam>
    /// <typeparam name="TSort">The type of the enum that reprensents the sorting types.</typeparam>
    public abstract class AscDescSorterBase<TSource, TSort> : ISorter<TSource, TSort>
    {
        /// <summary>
        /// Get the expression to select the key for ordering a source dataset.
        /// </summary>
        /// <param name="sort">The value of the sorting enum.</param>
        /// <returns>The Expression used by <see cref="Queryable.OrderBy{TSource, TKey}(IQueryable{TSource}, Expression{Func{TSource, TKey}})"/> or <see cref="Queryable.OrderByDescending{TSource, TKey}(IQueryable{TSource}, Expression{Func{TSource, TKey}})"/> (based on the value of ascending or descending ordering).</returns>
        public abstract Expression<Func<TSource, object>> KeySelector(TSort sort);

        /// <summary>
        /// Sorts the <paramref name="filtered"/> dataset using the <paramref name="sort"/> value to get the key via <see cref="KeySelector(TSort)"/>, and calls either 
        /// <see cref="Queryable.OrderBy{TSource, TKey}(IQueryable{TSource}, Expression{Func{TSource, TKey}})"/> or <see cref="Queryable.OrderByDescending{TSource, TKey}(IQueryable{TSource}, Expression{Func{TSource, TKey}})"/> 
        /// based on the value of <paramref name="sortDescending"/>.
        /// </summary>
        /// <param name="filtered">The dataset to sort.</param>
        /// <param name="sort">The value of the sorting enum to be passed to the <see cref="KeySelector(TSort)"/> method to get the sorting expression.</param>
        /// <param name="sortDescending">True indicates the resultset should be in descending order.</param>
        /// <returns>The sorted dataset, repesented as a queryable of <typeparamref name="TSource"/> objects.</returns>
        public IQueryable<TSource> Sort(IQueryable<TSource> filtered, TSort sort, bool sortDescending)
            => sortDescending ? filtered.OrderByDescending(KeySelector(sort)) : filtered.OrderBy(KeySelector(sort));
    }
}

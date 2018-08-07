using System;
using System.Linq.Expressions;

namespace MutatorFX.FilterMutator
{
    /// <summary>
    /// A simple <see cref="AscDescSorterBase{TSource, TSort}"/> implementation, which accepts the implementation details in constructor.
    /// </summary>
    /// <typeparam name="TSource">The source types to sort.</typeparam>
    /// <typeparam name="TSort">The sort enum type to use for sorting.</typeparam>
    public class ExpressionSorter<TSource, TSort> : AscDescSorterBase<TSource, TSort>
    {
        /// <summary>
        /// Create a simple sorter which accepts the implementation details to use for sorting.
        /// </summary>
        /// <param name="keySelector">The factory method used to get the keySelector <see cref="Expression"/> for a given <typeparamref name="TSort"/> value.</param>
        public ExpressionSorter(Func<TSort, Expression<Func<TSource, object>>> keySelector) 
            => KeySelectorFunc = keySelector ?? throw new ArgumentNullException(nameof(keySelector));

        private Func<TSort, Expression<Func<TSource, object>>> KeySelectorFunc { get; }

        /// <summary>
        /// Use the aquired factory function to get the selector for the sorting function.
        /// </summary>
        /// <param name="sort">The value of the sorting enum used to aquire the keySelector for.</param>
        /// <returns>The expression used to select the key from a <typeparamref name="TSource"/> object.</returns>
        public override Expression<Func<TSource, object>> KeySelector(TSort sort) => KeySelectorFunc(sort);
    }
}

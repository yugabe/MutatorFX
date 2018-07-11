using System;
using System.Linq.Expressions;

namespace MutatorFX.FilterMutator
{
    public class ExpressionSorter<TSource, TSort> : AscDescSorterBase<TSource, TSort>
    {
        public ExpressionSorter(Func<TSort, Expression<Func<TSource, object>>> keySelector) 
            => KeySelectorFunc = keySelector ?? throw new ArgumentNullException(nameof(keySelector));

        public Func<TSort, Expression<Func<TSource, object>>> KeySelectorFunc { get; }

        public override Expression<Func<TSource, object>> KeySelector(TSort sort) => KeySelectorFunc(sort);
    }
}

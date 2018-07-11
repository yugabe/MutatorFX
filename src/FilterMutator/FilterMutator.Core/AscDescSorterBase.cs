using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MutatorFX.FilterMutator
{
    public abstract class AscDescSorterBase<TSource, TSort> : ISorter<TSource, TSort>
    {
        public abstract Expression<Func<TSource, object>> KeySelector(TSort sort);

        public IQueryable<TSource> Sort(IQueryable<TSource> filtered, TSort sort, bool sortDescending)
            => sortDescending ? filtered.OrderByDescending(KeySelector(sort)) : filtered.OrderBy(KeySelector(sort));
    }
}

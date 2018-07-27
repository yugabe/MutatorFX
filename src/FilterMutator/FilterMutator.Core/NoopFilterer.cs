using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MutatorFX.FilterMutator
{
    public class NoopFilterer<TSource, TFilter> : IFilterer<TSource, TFilter>
    {
        public IQueryable<TSource> Filter(IQueryable<TSource> source, TFilter filter) => source;
    }
}

using System;
using System.Linq;

namespace MutatorFX.FilterMutator
{
    public class ClosureSourceAccessor<TSource>: ISourceAccessor<TSource>
    {
        public ClosureSourceAccessor(Func<IQueryable<TSource>> sourceAccessor) =>
            SourceAccessor = sourceAccessor;

        public Func<IQueryable<TSource>> SourceAccessor { get; }

        public IQueryable<TSource> Source => SourceAccessor();
    }
}

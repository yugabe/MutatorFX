using System.Linq;

namespace MutatorFX.FilterMutator
{
    public interface IFilterer<TSource, in TFilter>
    {
        IQueryable<TSource> Filter(IQueryable<TSource> source, TFilter filter);
    }
}

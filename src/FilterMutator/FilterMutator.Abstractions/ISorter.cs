using System.Linq;

namespace MutatorFX.FilterMutator
{
    public interface ISorter<TSource, in TSort>
    {
        IQueryable<TSource> Sort(IQueryable<TSource> filtered, TSort sort, bool sortDescending);
    }
}

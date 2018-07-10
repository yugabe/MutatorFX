using System.Linq;

namespace MutatorFX.FilterMutator
{
    public interface ISourceAccessor<out TSource>
    {
        IQueryable<TSource> Source { get; }
    }
}

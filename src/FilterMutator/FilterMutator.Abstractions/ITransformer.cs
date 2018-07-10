using System.Linq;

namespace MutatorFX.FilterMutator
{
    public interface ITransformer<in TSource, out TResult>
    {
        IQueryable<TResult> Transform(IQueryable<TSource> source);
    }
}

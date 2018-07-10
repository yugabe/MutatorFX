using System.Linq;

namespace MutatorFX.FilterMutator
{
    public interface IPager<TResult>
    {
        IQueryable<TResult> Page(IQueryable<TResult> results, int page, int pageSize);
    }
}

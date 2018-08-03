using System;
using System.Linq;

namespace MutatorFX.FilterMutator
{
    public sealed class SimplePager<TResult> : IPager<TResult>
    {
        public IQueryable<TResult> Page(IQueryable<TResult> results, int page, int pageSize) =>
            page < 1 ? throw new ArgumentOutOfRangeException(nameof(page), "The value must be at least 1.")
                : pageSize < 1 ? throw new ArgumentOutOfRangeException(nameof(pageSize), "The value must be at least 1.")
                : results.Skip(page - 1 * pageSize).Take(pageSize);
    }
}

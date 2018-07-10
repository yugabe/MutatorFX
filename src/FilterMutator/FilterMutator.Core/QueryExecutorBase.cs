using System;
using System.Linq;

namespace MutatorFX.FilterMutator
{
    public abstract class QueryExecutorBase<TSource, TResult, TFilter, TSort> : IQueryExecutor<TFilter, TSort, TResult>, ISourceAccessor<TSource>, IFilterer<TSource, TFilter>, ITransformer<TSource, TResult>, ISorter<TSource, TSort>, IPager<TResult>
        where TSort : Enum
    {
        public virtual IPagedResult<TResult> ExecuteQuery(TFilter filter, int page, int pageSize, TSort sorting, bool sortDescending)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter), "The provided filter must not be null.");

            var results = Filter(Source, filter);
            return new PagedResult<TResult>(Page(Transform(Sort(results, sorting, sortDescending)), page, pageSize), page, pageSize, results.Count());
        }

        public abstract IQueryable<TSource> Source { get; }
        public abstract IQueryable<TSource> Filter(IQueryable<TSource> source, TFilter filter);
        public abstract IQueryable<TResult> Transform(IQueryable<TSource> source);
        public abstract IQueryable<TSource> Sort(IQueryable<TSource> filtered, TSort sort, bool sortDescending);
        public abstract IQueryable<TResult> Page(IQueryable<TResult> results, int page, int pageSize);
    }
}

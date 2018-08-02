using System;
using System.Linq;

namespace MutatorFX.FilterMutator
{
    public class CompositeQueryExecutor<TSource, TResult, TFilter, TSort> : QueryExecutorBase<TSource, TResult, TFilter, TSort>
        where TSort : Enum
    {
        public CompositeQueryExecutor(ISourceAccessor<TSource> sourceAccessor, IFilterer<TSource, TFilter> filterer, ITransformer<TSource, TResult> transformer, ISorter<TSource, TSort> sorter, IPager<TResult> pager)
        {
            SourceAccessor = sourceAccessor;
            Filterer = filterer;
            Transformer = transformer;
            Sorter = sorter;
            Pager = pager;
        }

        public virtual ISourceAccessor<TSource> SourceAccessor { get; }
        public virtual IFilterer<TSource, TFilter> Filterer { get; }
        public virtual ITransformer<TSource, TResult> Transformer { get; }
        public virtual ISorter<TSource, TSort> Sorter { get; }
        public virtual IPager<TResult> Pager { get; }

        public override IQueryable<TSource> Source => SourceAccessor.Source;
        public override IQueryable<TSource> Filter(IQueryable<TSource> source, TFilter filter) => Filterer.Filter(source, filter);
        public override IQueryable<TSource> Sort(IQueryable<TSource> filtered, TSort sorting, bool sortDescending) => Sorter.Sort(filtered, sorting, sortDescending);
        public override IQueryable<TResult> Transform(IQueryable<TSource> source) => Transformer.Transform(source);
        public override IQueryable<TResult> Page(IQueryable<TResult> results, int page, int pageSize) => Pager.Page(results, page, pageSize);
    }
}

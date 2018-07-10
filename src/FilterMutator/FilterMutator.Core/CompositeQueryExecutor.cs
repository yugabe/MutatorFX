using System;
using System.Linq;

namespace MutatorFX.FilterMutator
{
    public sealed class CompositeQueryExecutor<TSource, TResult, TFilter, TSort, TSourceAccessor, TFilterer, TTransformer, TSorter, TPager>
        : QueryExecutorBase<TSource, TResult, TFilter, TSort>
        where TSort : Enum
        where TSourceAccessor : ISourceAccessor<TSource>
        where TFilterer : IFilterer<TSource, TFilter>
        where TTransformer : ITransformer<TSource, TResult>
        where TSorter : ISorter<TSource, TSort>
        where TPager : IPager<TResult>
    {
        public CompositeQueryExecutor(TSourceAccessor sourceAccessor, TFilterer filterer, TTransformer transformer, TSorter sorter, TPager pager)
        {
            SourceAccessor = sourceAccessor;
            Filterer = filterer;
            Transformer = transformer;
            Sorter = sorter;
            Pager = pager;
        }

        public TSourceAccessor SourceAccessor { get; }
        public TFilterer Filterer { get; }
        public TTransformer Transformer { get; }
        public TSorter Sorter { get; }
        public TPager Pager { get; }

        public override IQueryable<TSource> Source => SourceAccessor.Source;
        public override IQueryable<TSource> Filter(IQueryable<TSource> source, TFilter filter) => Filterer.Filter(source, filter);
        public override IQueryable<TSource> Sort(IQueryable<TSource> filtered, TSort sorting, bool sortDescending) => Sorter.Sort(filtered, sorting, sortDescending);
        public override IQueryable<TResult> Transform(IQueryable<TSource> source) => Transformer.Transform(source);
        public override IQueryable<TResult> Page(IQueryable<TResult> results, int page, int pageSize) => Pager.Page(results, page, pageSize);
    }
}

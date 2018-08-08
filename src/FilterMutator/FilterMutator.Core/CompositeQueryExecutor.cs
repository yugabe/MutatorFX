using System;
using System.Linq;

namespace MutatorFX.FilterMutator
{
    /// <summary>
    /// A queryexecutor implementation that accepts all its implementation details via its constructor.
    /// Can be used via DI if all parameters can be trivially resolved.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source dataset.</typeparam>
    /// <typeparam name="TResult">The type of the elements in the result dataset.</typeparam>
    /// <typeparam name="TFilter">The type of the filter that is used when filtering the source dataset.</typeparam>
    /// <typeparam name="TSort">The enum type that is used when sorting the dataset.</typeparam>
    public class CompositeQueryExecutor<TSource, TResult, TFilter, TSort> : QueryExecutorBase<TSource, TResult, TFilter, TSort>
        where TSort : Enum
    {
        /// <summary>
        /// Create a new instance of the <see cref="CompositeQueryExecutor{TSource, TResult, TFilter, TSort}"/> with all its implementation details injected via constructor.
        /// </summary>
        /// <param name="sourceAccessor">The source accessor used to acces the <typeparamref name="TSource"/> elements.</param>
        /// <param name="filterer">The filterer implementation used to filter the dataset.</param>
        /// <param name="transformer">The transformation object that can transform the <typeparamref name="TSource"/> types to <typeparamref name="TResult"/> types.</param>
        /// <param name="sorter"></param>
        /// <param name="pager"></param>
        public CompositeQueryExecutor(ISourceAccessor<TSource> sourceAccessor, IFilterer<TSource, TFilter> filterer, ITransformer<TSource, TResult> transformer, ISorter<TSource, TSort> sorter, IPager<TResult> pager)
        {
            SourceAccessor = sourceAccessor;
            Filterer = filterer;
            Transformer = transformer;
            Sorter = sorter;
            Pager = pager;
        }

        /// <summary>
        /// The accessor used to access the source dataset.
        /// </summary>
        public virtual ISourceAccessor<TSource> SourceAccessor { get; }

        /// <summary>
        /// The filterer used to filter the source dataset with a given <typeparamref name="TFilter"/>.
        /// </summary>
        public virtual IFilterer<TSource, TFilter> Filterer { get; }

        /// <summary>
        /// An <see cref="ITransformer{TSource, TResult}"/> that can transform a source queryable to a result queryable dataset.
        /// </summary>
        public virtual ITransformer<TSource, TResult> Transformer { get; }

        /// <summary>
        /// A sorter object that sorts a given <typeparamref name="TSource"/> object based on a sorting enum parameter.
        /// </summary>
        public virtual ISorter<TSource, TSort> Sorter { get; }

        /// <summary>
        /// A pager object that generates paging results for a given <typeparamref name="TResult"/> dataset.
        /// </summary>
        public virtual IPager<TResult> Pager { get; }

        /// <summary>
        /// The default source accessor implementation uses the injected <see cref="SourceAccessor"/> to access the source dataset.
        /// </summary>
        public override IQueryable<TSource> Source => SourceAccessor.Source;

        /// <summary>
        /// The default filtering implementation uses the injected <see cref="Filterer"/> object to filter the given datasource with the provided filter.
        /// </summary>
        /// <param name="source">The datasource to apply filtering to.</param>
        /// <param name="filter">The filter to apply to the datasource.</param>
        /// <returns>The filtered dataset.</returns>
        public override IQueryable<TSource> Filter(IQueryable<TSource> source, TFilter filter) => Filterer.Filter(source, filter);

        /// <summary>
        /// The default sorting implementation uses the injected <see cref="Sorter"/> object to sort the given source dataset.
        /// </summary>
        /// <param name="filtered">The filtered, unsorted dataset to apply sorting to.</param>
        /// <param name="sorting">The sorting value to determine the kind of sorting to use.</param>
        /// <param name="sortDescending">The order of sorting.</param>
        /// <returns>The sorted dataset.</returns>
        public override IQueryable<TSource> Sort(IQueryable<TSource> filtered, TSort sorting, bool sortDescending) => Sorter.Sort(filtered, sorting, sortDescending);

        /// <summary>
        /// The default transformation implementation uses the injected <see cref="Transformer"/> object to transform the source dataset to the result dataset.
        /// </summary>
        /// <param name="source">The source objects to transform to <typeparamref name="TResult"/>.</param>
        /// <returns>The transformed objects.</returns>
        public override IQueryable<TResult> Transform(IQueryable<TSource> source) => Transformer.Transform(source);

        /// <summary>
        /// The default implementation uses the injected <see cref="Pager"/> to apply paging to the result dataset.
        /// </summary>
        /// <param name="results">The results to apply paging to.</param>
        /// <param name="page">The page (1-based) requested.</param>
        /// <param name="pageSize">The page size requested.</param>
        /// <returns>The paged entries.</returns>
        public override IQueryable<TResult> Page(IQueryable<TResult> results, int page, int pageSize) => Pager.Page(results, page, pageSize);
    }
}

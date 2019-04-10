using System.Linq;

namespace QueryMutator.Core
{
    public static class QueryableExtensions
    {
        public static IQueryable<TTarget> Select<TSource, TTarget>(this IQueryable<TSource> source, IMapping<TSource, TTarget> mapping)
        {
            return source.Select(mapping.Expression);
        }
        
        public static IQueryable<TTarget> Select<TSource, TTarget, TParameter>(this IQueryable<TSource> source, IMapping<TSource, TTarget, TParameter> mapping, TParameter parameter)
        {
            return source.Select((mapping as Mapping<TSource, TTarget, TParameter>).Builder.ToExpression(parameter));
        }
    }
}

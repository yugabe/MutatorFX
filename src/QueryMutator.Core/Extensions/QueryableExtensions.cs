using System;
using System.Linq;

namespace QueryMutator.Core
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Select<TSource, T>(this IQueryable source, IMapping<TSource, T> mapping)
        {
            throw new NotImplementedException();
        }

        public static IQueryable<T> Select<TSource, T>(this IQueryable<TSource> source, IMapping<TSource, T> mapping)
        {
            return source.Select(mapping.Expression);
        }

        public static IQueryable<T> Select<TSource, T, TParameter>(this IQueryable source, IMapping<TSource, T, TParameter> mapping, TParameter parameter)
        {
            throw new NotImplementedException();
        }

        public static IQueryable<T> Select<TSource, T, TParameter>(this IQueryable<TSource> source, IMapping<TSource, T, TParameter> mapping, TParameter parameter)
        {
            throw new NotImplementedException();
        }
    }
}

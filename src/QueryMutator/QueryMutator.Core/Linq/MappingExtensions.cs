using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MutatorFX.QueryMutator.Linq
{
    public static class MappingExtensions
    {
        public static IQueryable<T> Select<TSource, T>(this IQueryable<TSource> source, IMapping<TSource, T> mapping)
            => source.Select(mapping.ToExpression());

        public static IEnumerable<T> Select<TSource, T>(this IEnumerable<TSource> source, IMapping<TSource, T> mapping)
            => source.Select(mapping.ToExpression().Compile());
    }
}

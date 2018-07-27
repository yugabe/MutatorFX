using MutatorFX.FluentExtensions;
using MutatorFX.ReflectionExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using static System.Linq.Expressions.Expression;

namespace MutatorFX.FilterMutator
{
    public class PropertyChainNameSorter<TSource, TSort> : AscDescSorterBase<TSource, TSort>
    {
        public static IReadOnlyDictionary<TSort, Expression<Func<TSource, object>>> Lookup { get; } =
            Enum.GetNames(typeof(TSort)).ToDictionary(n => (TSort)Enum.Parse(typeof(TSort), n), n =>
                 Parameter(typeof(TSource), char.ToLower(typeof(TSource).Name.First()).ToString()).Pipe(parameter =>
                     Lambda<Func<TSource, object>>(Convert(typeof(TSource).GetPropertyChain(n).Aggregate((Expression)parameter, (a, p) => MakeMemberAccess(a, p)), typeof(object)), parameter)));

        public override Expression<Func<TSource, object>> KeySelector(TSort sort) =>
            Lookup.TryGetValue(sort, out var expression) ? expression : throw new KeyNotFoundException($"The expression for sorting key {sort} was not found in the expression lookup.");
    }
}
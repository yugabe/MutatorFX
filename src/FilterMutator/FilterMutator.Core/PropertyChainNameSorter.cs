using MutatorFX.FluentExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using static System.Linq.Expressions.Expression;

namespace MutatorFX.FilterMutator
{
    public class PropertyChainNameSorter<TSource, TSort> : AscDescSorterBase<TSource, TSort>
    {
        public PropertyChainNameSorter()
        {
            var currentType = typeof(TSource);
            Lookup = Enum.GetNames(typeof(TSort)).ToDictionary(n => (TSort)Enum.Parse(typeof(TSort), n), n =>
                Parameter(typeof(TSource), char.ToLower(typeof(TSource).Name.First()).ToString()).Pipe(parameter =>
                {
                    var propertyChain = new List<PropertyInfo>();

                    throw new NotImplementedException();

                    return Lambda<Func<TSource, object>>(propertyChain.Aggregate((Expression)parameter, MakeMemberAccess), parameter);
                })
            );
        }

        public IReadOnlyDictionary<TSort, Expression<Func<TSource, object>>> Lookup { get; }

        public override Expression<Func<TSource, object>> KeySelector(TSort sort) =>
            Lookup.TryGetValue(sort, out var expression) ? expression : throw new KeyNotFoundException($"The expression for sorting key {sort} was not found in the expression lookup.");
    }
}

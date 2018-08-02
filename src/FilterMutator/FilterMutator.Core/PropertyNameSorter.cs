using MutatorFX.Coding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using static System.Linq.Expressions.Expression;

namespace MutatorFX.FilterMutator
{
    public class PropertyNameSorter<TSource, TSort> : AscDescSorterBase<TSource, TSort>
    {
        public PropertyNameSorter() =>
            new HashSet<string>(typeof(TSource).GetProperties().Select(p => p.Name))
                .Pipe(names => Enum.GetNames(typeof(TSort)).Where(s => !names.Contains(s)))
                .DoWhen(nonMatches => nonMatches.Any(), nonMatches => throw new InvalidOperationException($"The enum value names in type {typeof(TSort).FullName} cannot be matched to the public property names in type {typeof(TSource).FullName}. The missing values are: {string.Join(", ", nonMatches)}."));

        public override Expression<Func<TSource, object>> KeySelector(TSort sort) =>
            typeof(TSource).GetProperty(Enum.GetName(typeof(TSort), sort)).Branch(p => p == null,
                funcIf: p => throw new InvalidOperationException($"The enum value name {Enum.GetName(typeof(TSort), sort)} for type {typeof(TSort).FullName} was not found as a public property name for sorting in {typeof(TSource).FullName}."), 
                funcElse: property => Parameter(typeof(TSource), char.ToLower(typeof(TSource).Name.First()).ToString()).Pipe(parameter => Lambda<Func<TSource, object>>(MakeMemberAccess(parameter, property), parameter)));
    }
}

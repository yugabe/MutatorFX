using MutatorFX.Coding;
using MutatorFX.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using static System.Linq.Expressions.Expression;

namespace MutatorFX.FilterMutator
{
    /// <summary>
    /// A sorter object that can be used to apply sorting to a given source dataset.
    /// This implementation instantiates a static cache for any given <typeparamref name="TSort"/> parameter,
    /// which can throw if no matching property chains are found for any name in the given <typeparamref name="TSort"/> enum.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source dataset.</typeparam>
    /// <typeparam name="TSort">The enum type. This enum should only contain names that can be resolved to property chains 
    /// without the separating dot, otherwise the static cache will throw.</typeparam>
    public class PropertyChainNameSorter<TSource, TSort> : AscDescSorterBase<TSource, TSort>
    {
        /// <summary>
        /// The global cache lookup for any given <typeparamref name="TSort"/> type.
        /// </summary>
        public static IReadOnlyDictionary<TSort, Expression<Func<TSource, object>>> Lookup { get; } =
            Enum.GetNames(typeof(TSort)).ToDictionary(n => (TSort)Enum.Parse(typeof(TSort), n), n =>
                 Parameter(typeof(TSource), char.ToLower(typeof(TSource).Name.First()).ToString()).Pipe(parameter =>
                     Lambda<Func<TSource, object>>(Convert(typeof(TSource).GetPropertyChain(n).Aggregate((Expression)parameter, (a, p) => MakeMemberAccess(a, p)), typeof(object)), parameter)));

        /// <summary>
        /// Uses the static cache <see cref="Lookup"/> to get the sorter property based on the <typeparamref name="TSort"/> enum value provided.
        /// Throws if the given key was not found in the lookup.
        /// </summary>
        /// <param name="sort">The value to look for in the lookup and use. </param>
        /// <returns>The expression used to aquire the key to apply sorting for.</returns>
        public override Expression<Func<TSource, object>> KeySelector(TSort sort) =>
            Lookup.TryGetValue(sort, out var expression) ? expression : throw new KeyNotFoundException($"The expression for sorting key {sort} was not found in the expression lookup.");
    }
}
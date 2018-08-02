using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MutatorFX.Reflection
{
    public static class TypeReflectionExtensions
    {
        /// <summary>
        /// Gets the first available property chain that matches the start of the given text. The text should be the concatenation of the property names. 
        /// In case of multiple matches, the first match is selected by ordering the properties by ascending order of the length of their names.
        /// </summary>
        /// <remarks> This method uses recursion, and calls <see cref="GetPropertyChains(Type, string, BindingFlags)"/> internally.</remarks>
        /// <param name="type">The type that should contain the properties described by the <paramref name="text"/>.</param>
        /// <param name="text">The string containing the exact names of the chained properties (without separators).</param>
        /// <param name="bindingFlags">The <seealso cref="BindingFlags"/> to use when looking for matching properties.</param>
        /// <returns>The property chain in order.</returns>
        public static IEnumerable<PropertyInfo> GetPropertyChain(this Type type, string text, BindingFlags? bindingFlags = null)
            => type.GetPropertyChains(text, bindingFlags).First();

        /// <summary>
        /// Gets all the available property chains that matches the given text. The text should be the concatenation of the property names. 
        /// The matches are ordered by ascending order of the length of their propertynames.
        /// </summary>
        /// <param name="type">The type that should contain the properties described by the <paramref name="text"/>.</param>
        /// <param name="text">The string containing the exact names of the chained properties (without separators).</param>
        /// <param name="bindingFlags">The <seealso cref="BindingFlags"/> to use when looking for matching properties.</param>
        /// <returns>The matching property chains.</returns>
        public static IEnumerable<IEnumerable<PropertyInfo>> GetPropertyChains(this Type type, string text, BindingFlags? bindingFlags = null)
            => (bindingFlags == null ? type.GetProperties() : type.GetProperties((BindingFlags)bindingFlags)).Where(p => text.StartsWith(p.Name)).OrderByDescending(p => p.Name.Length)
                .Select(p => new[] { p }.Concat(GetPropertyChains(p.PropertyType, text.Substring(p.Name.Length), bindingFlags).SelectMany(ip => ip)));
    }
}

using MutatorFX.Coding;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace MutatorFX.ExcelMutator
{
    /// <summary>
    /// Use this attribute to annotate the properties in a <see cref="RowModelBase"/> class 
    /// with metadata for the parsing and extraction of cell values.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ColumnAttribute : Attribute
    {
        /// <summary>
        /// Use this attribute to annotate the properties in a <see cref="RowModelBase"/> class 
        /// with metadata for the parsing and extraction of cell values.
        /// </summary>
        /// <param name="name">The name of the header row to match the cell contents againts. Not case sensitive.</param>
        public ColumnAttribute(string name) => Name = name;

        /// <summary>
        /// The name of the header row to match the cell contents againts. Not case sensitive.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The order value to use when extracting data from a <see cref="RowModelBase"/> datasource.
        /// </summary>
        public int OutputOrder { get; set; }

        /// <summary>
        /// In case of strings and string collections, indicates whether to trim the string value or not.
        /// Defaults to true.
        /// </summary>
        public bool Trim { get; set; } = true;

        /// <summary>
        /// In case of strings and string collections, indicates the separator values to use.
        /// Default is a single comma: ","
        /// </summary>
        public string[] SplitSeparators { get; set; } = new[] { "," };

        /// <summary>
        /// In case of strings and string collections, indicates whether the splitting options should remove empty entries.
        /// Defaults to <see cref="StringSplitOptions.None"/>
        /// </summary>
        public StringSplitOptions StringSplitOptions { get; set; } = StringSplitOptions.None;

        /// <summary>
        /// Indicates whether the omission of the column can be overlooked. 
        /// Defaults to false.
        /// </summary>
        public bool Optional { get; set; }

        private static readonly ConcurrentDictionary<Type, MethodInfo> _enumTryParseMethodLookup
            = new ConcurrentDictionary<Type, MethodInfo>();

        private static readonly MethodInfo _enumTryParseMethod 
            = typeof(Enum).GetMethods().First(m => m.Name == nameof(Enum.TryParse) && m.GetGenericArguments().Length == 1 && m.GetParameters().Length == 2 && m.GetParameters()[0].ParameterType == typeof(string) && m.GetParameters()[1].IsOut);

        /// <summary>
        /// The default parser will try and parse a single value from a cell with regards to the target property.
        /// Enum parsing matches the names or <see cref="DisplayAttribute.Name"/> values case insensitively.
        /// If the target property is assignable from a string <see cref="IEnumerable{T}"/>, splitting occurs.
        /// If you want more control over parsing, subclass this attribute and override the default functionality.
        /// </summary>
        /// <param name="value">The value to parse from the cell.</param>
        /// <param name="property">The type of the target property to populate.</param>
        /// <returns>The parsed value to set to the target property of the row object.</returns>
        public virtual object Parse(object value, PropertyInfo property)
        {
            if (property.PropertyType.IsEnum)
            {
                if (value == null)
                    return null;
                var parameters = new object[] { value?.ToString(), null };
                return (bool)_enumTryParseMethodLookup
                    .GetOrAdd(property.PropertyType, t => _enumTryParseMethod.MakeGenericMethod(t))
                    .Invoke(null, parameters)
                    ? parameters[1]
                    : property.PropertyType.GetFields().FirstOrDefault(f => f.GetCustomAttribute<DisplayAttribute>()?.Name.ToLower() == value.ToString().ToLower())?.GetRawConstantValue();
            }
            else if (property.PropertyType.IsAssignableFrom(typeof(IEnumerable<string>)))
                return value?.ToString().Split(SplitSeparators, StringSplitOptions.None).Branch(e => Trim, e => e.Select(l => l.Trim())).ToList();
            return value;
        }
    }
}

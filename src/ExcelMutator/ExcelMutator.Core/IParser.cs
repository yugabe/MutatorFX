using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MutatorFX.ExcelMutator
{
    /// <summary>
    /// Represents a parser that can parse a single value to a property of a cell.
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Parse an object from the datasouce's single cell, with regards to the target property to populate.
        /// </summary>
        /// <param name="value">The value in the datasource's cell.</param>
        /// <param name="targetProperty">The property to populate.</param>
        /// <returns>The parsed value.</returns>
        object Parse(object value, PropertyInfo targetProperty);
    }
}

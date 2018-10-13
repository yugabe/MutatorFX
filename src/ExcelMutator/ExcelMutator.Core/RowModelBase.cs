using System.Linq;
using System.Reflection;

namespace MutatorFX.ExcelMutator
{
    /// <summary>
    /// The base class used in row parsing. Holds the number of the row which it is constructed from.
    /// </summary>
    public abstract class RowModelBase
    {
        /// <summary>
        /// The source number of the row in the worksheet the model is constructed from.
        /// </summary>
        public int RowNumber { get; set; }

        /// <summary>
        /// Get the friendly formatted string name of the model, ordered by the corresponding <see cref="ColumnAttribute.OutputOrder"/> property.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{GetType().Name}: {string.Join(" | ", GetType().GetProperties().OrderBy(p => p.GetCustomAttribute<ColumnAttribute>()?.OutputOrder).Select(p => $"{p.Name}:{p.GetValue(this)?.ToString()}"))}";
    }
}

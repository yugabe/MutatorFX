using System;

namespace MutatorFX.ExcelMutator
{
    /// <summary>
    /// Use this attribute to annotate the properties of a model type with metadata that is used
    /// to identify the worksheets to parse for model extraction.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class SheetAttribute : Attribute
    {
        /// <summary>
        /// Use this attribute to annotate the properties of a model type with metadata that is used
        /// to identify the worksheets to parse for model extraction.
        /// </summary>
        /// <param name="name">The name of the worksheet to use.</param>
        public SheetAttribute(string name) => Name = name;

        /// <summary>
        /// The name of the worksheet to use.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The order value to use when extracting data from a datasource.
        /// </summary>
        public int OutputOrder { get; set; }

        /// <summary>
        /// Indicates whether the omission of the worksheet can be overlooked. 
        /// Defaults to false.
        /// </summary>
        public bool Optional { get; set; }
    }
}

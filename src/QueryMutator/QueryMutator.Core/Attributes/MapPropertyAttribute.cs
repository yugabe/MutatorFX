using System;

namespace QueryMutator.Core
{
    /// <summary>
    /// Specifies a property mapping from the supplied property to the attribute target.
    /// The defining class of the attribute target must be decorated with a <see cref="MapFromAttribute"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class MapPropertyAttribute : Attribute
    {
        /// <summary>
        /// The name of the property to map from.
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        /// Specifies a property mapping from the supplied property <paramref name="propertyName"/> to the attribute target.
        /// The defining class of the attribute target must be decorated with a <see cref="MapFromAttribute"/>.
        /// </summary>
        /// <param name="propertyName">The name of the source property to map from.</param>
        /// <exception cref="InvalidPropertyNameException">Thrown when the property name does not exist on the source target.</exception>
        public MapPropertyAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}

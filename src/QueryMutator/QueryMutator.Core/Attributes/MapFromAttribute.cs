using System;

namespace QueryMutator.Core
{
    /// <summary>
    /// Specifies a mapping from the supplied type to the attribute target.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class MapFromAttribute : Attribute
    {
        /// <summary>
        /// The type of the source class to map from.
        /// </summary>
        public Type SourceType { get; }

        /// <summary>
        /// Specifies a mapping from the supplied type <paramref name="sourceType"/> to the attribute target.
        /// </summary>
        /// <param name="sourceType">The type of the source class to map from.</param>
        public MapFromAttribute(Type sourceType)
        {
            SourceType = sourceType;
        }
    }
}

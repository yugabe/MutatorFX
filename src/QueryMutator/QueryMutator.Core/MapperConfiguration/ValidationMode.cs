
namespace QueryMutator.Core
{
    /// <summary>
    /// Determines the validation mode when mapping objects.
    /// </summary>
    public enum ValidationMode
    {
        /// <summary>
        /// All destination properties have to be mapped.
        /// </summary>
        Destination = 0,
        /// <summary>
        /// All source properties have to be mapped.
        /// </summary>
        Source = 1,
        /// <summary>
        /// No validation is used.
        /// </summary>
        None = 2
    }
}

namespace QueryMutator.Core
{
    /// <summary>
    /// A configuration object containing settings, that can be passed when creating a new instance of 
    /// <see cref="MapperConfiguration"/>.
    /// </summary>
    public class MapperConfigurationOptions
    {
        /// <summary>
        /// Specifies the validation mode to be used when creating the mappings.
        /// </summary>
        public ValidationMode ValidationMode { get; set; }
    }
}

using System;

namespace QueryMutator.Core
{
    /// <summary>
    /// Thrown when a mapping validation error occurs.
    /// </summary>
    public class MappingValidationException : Exception
    {
        public MappingValidationException(): base() { }

        public MappingValidationException(string message): base(message) { }
    }
}

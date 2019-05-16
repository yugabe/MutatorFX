using System;

namespace QueryMutator.Core
{
    /// <summary>
    /// Thrown when another mapping with the same generic parameters already exists.
    /// </summary>
    public class MappingAlreadyExistsException : Exception
    {
        public MappingAlreadyExistsException() : base() { }

        public MappingAlreadyExistsException(string message) : base(message) { }
    }
}

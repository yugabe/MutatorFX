using System;

namespace QueryMutator.Core
{
    /// <summary>
    /// Thrown when the mapping with the supplied generic arguments does not exist.
    /// </summary>
    public class MappingNotFoundException : Exception
    {
        public MappingNotFoundException() : base() { }

        public MappingNotFoundException(string message) : base(message) { }
    }
}

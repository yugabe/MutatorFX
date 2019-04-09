using System;

namespace QueryMutator.Core
{
    public class MappingAlreadyExistsException : Exception
    {
        public MappingAlreadyExistsException() : base() { }

        public MappingAlreadyExistsException(string message) : base(message) { }
    }
}

using System;

namespace QueryMutator.Core
{
    public class MappingNotFoundException : Exception
    {
        public MappingNotFoundException() : base() { }

        public MappingNotFoundException(string message) : base(message) { }
    }
}

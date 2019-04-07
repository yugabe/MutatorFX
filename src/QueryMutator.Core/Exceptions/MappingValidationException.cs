using System;

namespace QueryMutator.Core
{
    public class MappingValidationException : Exception
    {
        public MappingValidationException(): base() { }

        public MappingValidationException(string message): base(message) { }
    }
}

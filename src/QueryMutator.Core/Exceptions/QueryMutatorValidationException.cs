using System;

namespace QueryMutator.Core
{
    public class QueryMutatorValidationException : Exception
    {
        public QueryMutatorValidationException(): base() { }

        public QueryMutatorValidationException(string message): base(message) { }
    }
}

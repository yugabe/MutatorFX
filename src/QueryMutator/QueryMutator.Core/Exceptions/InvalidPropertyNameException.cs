using System;

namespace QueryMutator.Core
{
    public class InvalidPropertyNameException : Exception
    {
        public InvalidPropertyNameException() : base() { }

        public InvalidPropertyNameException(string message) : base(message) { }
    }
}

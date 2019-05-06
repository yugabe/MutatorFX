using System;

namespace QueryMutator.Core
{
    /// <summary>
    /// Thrown when the property does not exist on the source type.
    /// </summary>
    public class InvalidPropertyNameException : Exception
    {
        public InvalidPropertyNameException() : base() { }

        public InvalidPropertyNameException(string message) : base(message) { }
    }
}

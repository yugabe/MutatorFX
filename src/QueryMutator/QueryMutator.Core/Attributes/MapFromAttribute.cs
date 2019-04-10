using System;

namespace QueryMutator.Core
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class MapFromAttribute : Attribute
    {
        public Type SourceType { get; }

        public MapFromAttribute(Type sourceType)
        {
            SourceType = sourceType;
        }
    }
}

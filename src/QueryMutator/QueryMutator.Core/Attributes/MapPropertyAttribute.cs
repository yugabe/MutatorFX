using System;

namespace QueryMutator.Core
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class MapPropertyAttribute : Attribute
    {
        public string PropertyName { get; }

        public MapPropertyAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}

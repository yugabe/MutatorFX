using System;

namespace QueryMutator.Core
{
    internal class MappingDescriptor
    {
        public Type SourceType { get; set; }

        public Type TargetType { get; set; }

        public Type ParameterType { get; set; }

        public object Mapping { get; set; }
    }
}

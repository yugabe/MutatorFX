using System;

namespace QueryMutator.Core
{
    internal class ParametrizedBuilderDescriptor
    {
        public Type SourceType { get; set; }

        public Type TargetType { get; set; }

        public Type ParameterType { get; set; }

        public IMapping Mapping { get; set; }

        public MappingBuilderBase Builder { get; set; }
    }

}

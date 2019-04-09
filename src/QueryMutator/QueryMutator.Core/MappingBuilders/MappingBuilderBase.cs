using System;
using System.Collections.Generic;

namespace QueryMutator.Core
{
    internal abstract class MappingBuilderBase : IEquatable<MappingBuilderBase>
    {
        public Type SourceType { get; set; }

        public Type TargetType { get; set; }

        public IList<MappingBuilderBase> Dependencies { get; set; }

        public abstract IMapping Build(Dictionary<MappingKey, IMapping> dependencies);

        public bool Equals(MappingBuilderBase other)
        {
            return other != null && SourceType == other.SourceType && TargetType == other.TargetType;
        }
    }
}

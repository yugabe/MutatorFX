using System;
using System.Collections.Generic;

namespace QueryMutator.Core
{
    internal abstract class MappingBuilderBase
    {
        public Type SourceType { get; set; }

        public Type TargetType { get; set; }

        public IList<MappingBuilderBase> Dependencies { get; set; }

        public abstract IMapping Build(IEnumerable<MappingDescriptor> dependencies);
    }

    internal class MappingBuilderEqualityComparer : EqualityComparer<MappingBuilderBase>
    {
        public override bool Equals(MappingBuilderBase b1, MappingBuilderBase b2)
        {
            return (b1 == null && b2 == null) || (b1 != null && b2 != null && b1.SourceType == b2.SourceType && b1.TargetType == b2.TargetType);
        }

        public override int GetHashCode(MappingBuilderBase obj)
        {
            return obj == null ? 0 : obj.SourceType.GetHashCode() ^ obj.TargetType.GetHashCode();
        }
    }

}

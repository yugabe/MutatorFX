using System;
using System.Collections.Generic;

namespace QueryMutator.Core
{
    internal class BuilderDescriptor : IEquatable<BuilderDescriptor>
    {
        public Type SourceType { get; set; }

        public Type TargetType { get; set; }
        
        public IList<BuilderDescriptor> Dependencies { get; set; }

        public bool Built { get; set; }

        protected BuilderDescriptor() { }

        public BuilderDescriptor(Type sourceType, Type targetType): this(sourceType, targetType, null, false) { }

        public BuilderDescriptor(Type sourceType, Type targetType, IList<BuilderDescriptor> dependencies, bool built)
        {
            SourceType = sourceType;
            TargetType = targetType;
            Dependencies = dependencies;
            Built = built;
        }
        
        public bool Equals(BuilderDescriptor other)
        {
            return other != null && SourceType == other.SourceType && TargetType == other.TargetType;
        }

        public override bool Equals(object obj)
        {
            if(obj == null || !(obj is BuilderDescriptor b))
            {
                return false;
            }

            return Equals(b);
        }

        public override int GetHashCode() => Built.GetHashCode() + SourceType.GetHashCode() + TargetType.GetHashCode() + (Dependencies?.GetHashCode() ?? 0);
    }
}

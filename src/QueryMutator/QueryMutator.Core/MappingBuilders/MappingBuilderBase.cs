using System;
using System.Collections.Generic;

namespace QueryMutator.Core
{
    internal abstract class MappingBuilderBase
    {
        public Type SourceType { get; set; }

        public Type TargetType { get; set; }

        public IList<BuilderDescriptor> Dependencies { get; set; }

        public abstract IMapping Build(Dictionary<MappingKey, IMapping> dependencies);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace QueryMutator.Core
{
    internal class MappingKey
    {
        public Type SourceType { get; set; }

        public Type TargetType { get; set; }

        public Type ParameterType { get; set; }

        protected MappingKey() { }

        public MappingKey(Type sourceType, Type targetType) : this(sourceType, targetType, null) { }

        public MappingKey(Type sourceType, Type targetType, Type parameterType)
        {
            SourceType = sourceType;
            TargetType = targetType;
            ParameterType = parameterType;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is MappingKey m))
            {
                return false;
            }

            return SourceType == m.SourceType && TargetType == m.TargetType && ParameterType == m.ParameterType;
        }

        public override int GetHashCode() => HashCode.Combine(SourceType.GetHashCode(), TargetType.GetHashCode(), ParameterType?.GetHashCode());
    }
}

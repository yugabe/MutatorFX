using System;
using System.Linq.Expressions;
using System.Reflection;

namespace MutatorFX.QueryMutator
{
    public class IgnoredPropertyMapping : IPropertyMapping
    {
        public IgnoredPropertyMapping(PropertyInfo targetProperty)
            => TargetProperty = targetProperty ?? throw new ArgumentNullException(nameof(TargetProperty));

        public PropertyInfo TargetProperty { get; }
        public Expression GetExpressionBody()
            => throw new InvalidOperationException($"The given property on \"{TargetProperty.Name}\" is ignored, no mapping expression is available.");
    }
}

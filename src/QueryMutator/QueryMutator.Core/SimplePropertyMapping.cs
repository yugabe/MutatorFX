using System;
using System.Linq.Expressions;
using System.Reflection;

namespace MutatorFX.QueryMutator
{
    public class SimplePropertyMapping : IPropertyMapping
    {
        public SimplePropertyMapping(PropertyInfo targetProperty, Expression expression)
        {
            TargetProperty = targetProperty ?? throw new ArgumentNullException(nameof(targetProperty));
            if (!targetProperty.CanWrite)
                throw new ArgumentException("Target property cannot be set.", nameof(targetProperty));
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
            if (!expression.Type.IsAssignableFrom(targetProperty.PropertyType))
                throw new InvalidOperationException($"The provided Expression {expression} cannot be assigned to property {targetProperty}.");
        }
        public Expression Expression { get; }
        public PropertyInfo TargetProperty { get; }
        public Expression GetExpressionBody() => Expression;
    }
}

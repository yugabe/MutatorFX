using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using static System.Linq.Expressions.Expression;

namespace MutatorFX.QueryMutator
{
    public class ComplexPropertyMapping : IPropertyMapping
    {
        private readonly object _syncRoot = new object();
        public ComplexPropertyMapping(PropertyInfo targetProperty, List<IPropertyMapping> propertyMappings = null, bool canCache = false)
        {
            TargetProperty = targetProperty;
            PropertyMappings = propertyMappings ?? new List<IPropertyMapping>();
            New = New(TargetProperty.PropertyType);
            if (canCache)
                CachedExpression = GenerateExpressionBody();
        }
        public PropertyInfo TargetProperty { get; }
        public List<IPropertyMapping> PropertyMappings { get; }
        private NewExpression New { get; }
        private Expression CachedExpression { get; }
        private Expression GenerateExpressionBody()
            => MemberInit(New, PropertyMappings.Select(p => Bind(p.TargetProperty, p.GetExpressionBody())));
        public Expression GetExpressionBody() => CachedExpression ?? GenerateExpressionBody();
    }
}

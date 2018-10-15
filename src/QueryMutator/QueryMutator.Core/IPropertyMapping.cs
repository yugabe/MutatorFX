using System.Linq.Expressions;
using System.Reflection;

namespace MutatorFX.QueryMutator
{
    public interface IPropertyMapping
    {
        PropertyInfo TargetProperty { get; }

        Expression GetExpressionBody();
    }
}
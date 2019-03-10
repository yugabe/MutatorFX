using System.Linq.Expressions;
using System.Reflection;

namespace QueryMutator.Core
{
    public static class ExpressionExtensions
    {
        public static MemberExpression ReplaceParameter(this MemberExpression expression, ParameterExpression target)
        {
            return Expression.Property(target, expression.Member as PropertyInfo); // ?
        }
    }
}

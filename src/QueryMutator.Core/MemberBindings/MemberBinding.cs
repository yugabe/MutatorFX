using System.Linq.Expressions;
using System.Reflection;

namespace QueryMutator.Core
{
    public class MemberBinding : MemberBindingBase
    {
        public new MemberExpression SourceExpression { get; set; }

        public override Expression GenerateExpression(ParameterExpression parameter)
        {
            return ReplaceMemberParameter(SourceExpression, parameter);
        }
        
        protected MemberExpression ReplaceMemberParameter(MemberExpression expression, ParameterExpression target)
        {
            return Expression.Property(target, expression.Member as PropertyInfo); // ?
        }
    }
}

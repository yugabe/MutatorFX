using System.Linq.Expressions;
using System.Reflection;

namespace QueryMutator.Core
{
    public class NullableMemberBinding : MemberBindingBase
    {
        public override Expression GenerateExpression(ParameterExpression parameter)
        {
            if(SourceExpression.NodeType == ExpressionType.Convert)
            {
                return ReplaceUnaryParameter(SourceExpression as UnaryExpression, parameter);
            }
            else
            {
                return ReplaceBinaryParameter(SourceExpression as BinaryExpression, parameter);
            }
        }

        protected UnaryExpression ReplaceUnaryParameter(UnaryExpression expression, ParameterExpression target)
        {
            return Expression.Convert(Expression.Property(target, (expression.Operand as MemberExpression).Member as PropertyInfo), expression.Type);
        }

        protected BinaryExpression ReplaceBinaryParameter(BinaryExpression expression, ParameterExpression target)
        {
            return Expression.Coalesce(Expression.Property(target, (expression.Left as MemberExpression).Member as PropertyInfo), expression.Right);
        }
    }
}

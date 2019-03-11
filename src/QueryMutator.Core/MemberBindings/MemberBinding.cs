using System.Linq.Expressions;

namespace QueryMutator.Core
{
    public class MemberBinding : MemberBindingBase
    {
        public new MemberExpression SourceExpression { get; set; }

        public override Expression GenerateExpression(ParameterExpression parameter)
        {
            return SourceExpression.ReplaceParameter(parameter);
        }
    }
}

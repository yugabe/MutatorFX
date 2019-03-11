using System.Linq.Expressions;

namespace QueryMutator.Core
{
    public class ConstantMemberBinding : MemberBindingBase
    {
        public new ConstantExpression SourceExpression { get; set; }

        public override Expression GenerateExpression(ParameterExpression parameter)
        {
            return SourceExpression;
        }
    }
}

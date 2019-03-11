using System.Linq.Expressions;

namespace QueryMutator.Core
{
    public class UsingMemberBinding : MemberBindingBase
    {
        public new MemberInitExpression SourceExpression { get; set; }

        public override Expression GenerateExpression(ParameterExpression parameter)
        {
            //return SourceExpression.ReplaceParameter(parameter);
            return null;
        }
    }
}

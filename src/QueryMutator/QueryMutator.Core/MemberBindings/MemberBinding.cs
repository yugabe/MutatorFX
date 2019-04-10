using System.Linq.Expressions;

namespace QueryMutator.Core
{
    public class MemberBinding : MemberBindingBase
    {
        public override Expression GenerateExpression(ParameterExpression parameter)
        {
            return SourceExpression;
        }
    }
}

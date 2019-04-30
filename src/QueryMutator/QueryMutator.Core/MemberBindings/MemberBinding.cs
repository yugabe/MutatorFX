using System.Linq.Expressions;

namespace QueryMutator.Core
{
    internal class MemberBinding : MemberBindingBase
    {
        public override Expression GenerateExpression(ParameterExpression parameter)
        {
            return SourceExpression;
        }
    }
}

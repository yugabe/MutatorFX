using System.Linq.Expressions;

namespace QueryMutator.Core
{
    public class IgnoreMemberBinding : MemberBindingBase
    {
        public override Expression GenerateExpression(ParameterExpression parameter)
        {
            return null;
        }
    }
}

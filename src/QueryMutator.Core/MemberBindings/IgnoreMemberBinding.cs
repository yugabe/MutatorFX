using System.Linq.Expressions;

namespace QueryMutator.Core
{
    public class IgnoreMemberBinding : MemberBindingBase
    {
        public override Expression GenerateExpression()
        {
            return null;
        }
    }
}

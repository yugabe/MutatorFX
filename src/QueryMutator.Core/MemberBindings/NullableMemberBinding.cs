using System.Linq.Expressions;
using System.Reflection;

namespace QueryMutator.Core
{
    public class NullableMemberBinding : MemberBindingBase
    {
        public override Expression GenerateExpression()
        {
            return SourceExpression;
        }
    }
}

using System.Linq.Expressions;
using System.Reflection;

namespace QueryMutator.Core
{
    public class MemberListBinding : MemberBindingBase
    {
        public new MethodCallExpression SourceExpression { get; set; }

        public override Expression GenerateExpression()
        {
            return SourceExpression;
        }
    }
}

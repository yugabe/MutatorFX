using System.Linq.Expressions;
using System.Reflection;

namespace QueryMutator.Core
{
    public class MemberBinding : MemberBindingBase
    {
        public new MemberExpression SourceExpression { get; set; }

        public override Expression GenerateExpression()
        {
            return SourceExpression;
        }
    }
}

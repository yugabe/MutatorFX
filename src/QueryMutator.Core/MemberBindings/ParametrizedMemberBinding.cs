using System.Linq.Expressions;
using System.Reflection;

namespace QueryMutator.Core
{
    public class ParametrizedMemberBinding : MemberBindingBase
    {
        public override Expression GenerateExpression(ParameterExpression parameter)
        {
            return SourceExpression;
        }
    }
}

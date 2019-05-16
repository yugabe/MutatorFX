using System;
using System.Linq.Expressions;
using System.Reflection;

namespace QueryMutator.Core
{
    internal class DependentListMemberBinding : MemberBindingBase
    {
        public Type SourceType { get; set; }

        public Type TargetType { get; set; }

        public PropertyInfo SourceMember { get; set; }

        public new MethodCallExpression SourceExpression { get; set; }

        public override Expression GenerateExpression(ParameterExpression parameter)
        {
            return SourceExpression;
        }
    }
}

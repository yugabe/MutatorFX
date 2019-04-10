using System.Linq.Expressions;
using System.Reflection;

namespace QueryMutator.Core
{
    public abstract class MemberBindingBase
    {
        public Expression SourceExpression { get; set; }

        public MemberInfo TargetMember { get; set; }

        public abstract Expression GenerateExpression(ParameterExpression target);
    }

    public abstract class MemberBindingBase<TParam>
    {
        public Expression SourceExpression { get; set; }

        public MemberInfo TargetMember { get; set; }

        public abstract Expression GenerateExpression(ParameterExpression target, TParam param);
    }
}

using System.Linq.Expressions;
using System.Reflection;

namespace QueryMutator.Core
{
    internal abstract class MemberBindingBase
    {
        public Expression SourceExpression { get; set; }

        public MemberInfo TargetMember { get; set; }

        public abstract Expression GenerateExpression(ParameterExpression target);
    }

    internal abstract class MemberBindingBase<TParam>
    {
        public Expression SourceExpression { get; set; }

        public MemberInfo TargetMember { get; set; }

        public abstract Expression GenerateExpression(ParameterExpression target, TParam param);
    }
}

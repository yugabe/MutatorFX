using System;
using System.Linq.Expressions;

namespace QueryMutator.Core
{
    internal class ParametrizedMemberBinding<TSource, TMember, TParam> : MemberBindingBase<TParam>
    {
        public Func<TParam, Expression<Func<TSource, TMember>>> ExpressionFactory { get; set; }
        
        public override Expression GenerateExpression(ParameterExpression target, TParam param)
        {
            return ExpressionFactory(param).ReplaceParameter(target).Body;
        }
    }
}

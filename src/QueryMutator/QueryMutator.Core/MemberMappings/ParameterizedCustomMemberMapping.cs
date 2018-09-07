using MutatorFX.QueryMutator.Expressions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MutatorFX.QueryMutator.MemberMappings
{
    public class ParameterizedCustomMemberMapping<TSource, TTarget, TMember, TParameter> : MemberMapping<TSource, TTarget>
    {
        public ParameterizedCustomMemberMapping(ParameterExpression sourceParameter, Expression<Func<TTarget, TMember>> memberSelector, Func<TParameter, Expression<Func<TSource, TMember>>> mappingExpressionFactory) : base(sourceParameter, null)
        {
            TargetMember = (memberSelector.Body as MemberExpression).Member;
            MemberSelector = memberSelector;
            ExpressionFactory = mappingExpressionFactory;
        }

        public Expression<Func<TTarget, TMember>> MemberSelector { get; }
        public Func<TParameter, Expression<Func<TSource, TMember>>> ExpressionFactory { get; }

        //Expression MemberMapping<TSource, TTarget>.GenerateExpression() => throw new InvalidOperationException();
        //public override Expression GenerateExpression() => ExpressionFactory(Parameter).ReplaceParameter(SourceParameter);
    }
}

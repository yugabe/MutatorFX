using MutatorFX.QueryMutator.Expressions;
using System;
using System.Linq.Expressions;

namespace MutatorFX.QueryMutator.MemberMappings
{
    public class ParameterizedCustomMemberMapping<TSource, TTarget, TMember, TParameter> : MemberMapping<TSource, TTarget, TParameter>
    {
        public ParameterizedCustomMemberMapping(ParameterExpression sourceParameter, Expression<Func<TTarget, TMember>> memberSelector, Func<TParameter, Expression<Func<TSource, TMember>>> mappingExpressionFactory) : base(sourceParameter, (memberSelector.Body as MemberExpression).Member)
        {
            MemberSelector = memberSelector;
            ExpressionFactory = mappingExpressionFactory;
        }

        public Expression<Func<TTarget, TMember>> MemberSelector { get; }
        public Func<TParameter, Expression<Func<TSource, TMember>>> ExpressionFactory { get; }
        public override Expression GenerateExpression(TParameter parameter) => ExpressionFactory(parameter).ReplaceParameter(SourceParameter);
    }
}

using MutatorFX.QueryMutator.Expressions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MutatorFX.QueryMutator.MemberMappings
{
    public class CustomMemberMapping<TSource, TTarget, TProperty> : MemberMapping<TSource, TTarget>
    {
        public CustomMemberMapping(ParameterExpression sourceParameter, Expression<Func<TTarget, TProperty>> memberSelector, Expression<Func<TSource, TProperty>> mappingExpression) : base(sourceParameter, null)
        {
            TargetMember = (memberSelector.Body as MemberExpression).Member;
            MemberSelector = memberSelector;
            Expression = mappingExpression;
        }

        public Expression<Func<TTarget, TProperty>> MemberSelector { get; }
        public Expression<Func<TSource, TProperty>> Expression { get; }

        public override Expression GenerateExpression() => Expression.ReplaceParameter(SourceParameter);
    }
}

using MutatorFX.QueryMutator.Expressions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace MutatorFX.QueryMutator.MemberMappings
{
    public class CustomMemberMapping<TSource, TTarget, TMember> : MemberMapping<TSource, TTarget>
    {
        public CustomMemberMapping(ParameterExpression sourceParameter, Expression<Func<TTarget, TMember>> memberSelector, Expression<Func<TSource, TMember>> mappingExpression) : base(sourceParameter, (memberSelector.Body as MemberExpression).Member)
        {
            MemberSelector = memberSelector;
            Expression = mappingExpression;
        }

        public Expression<Func<TTarget, TMember>> MemberSelector { get; }
        public Expression<Func<TSource, TMember>> Expression { get; }

        public override Expression GenerateExpression() => Expression.ReplaceParameter(SourceParameter).Body;
    }

    //public class CustomMemberMapping<TSource, TTarget, TMember, TParameter> : MemberMapping<TSource, TTarget, TParameter>
    //{
    //    public CustomMemberMapping(ParameterExpression sourceParameter, MemberInfo targetMember) : base(sourceParameter, targetMember)
    //    {
    //    }
    //}
}

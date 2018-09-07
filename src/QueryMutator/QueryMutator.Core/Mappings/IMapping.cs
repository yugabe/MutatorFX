using MutatorFX.QueryMutator.MemberMappings;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MutatorFX.QueryMutator
{
    public interface ISimpleMapping<TSource, TTarget>
    {
        ParameterExpression SourceParameter { get; }
    }
    public interface IMapping<TSource, TTarget> : ISimpleMapping<TSource, TTarget>
    {
        Expression<Func<TSource, TTarget>> ToExpression();
    }

    public interface IMapping<TSource, TTarget, TParameter> : ISimpleMapping<TSource, TTarget>
    {
        Expression<Func<TSource, TTarget>> ToExpression(TParameter parameter);
    }
}

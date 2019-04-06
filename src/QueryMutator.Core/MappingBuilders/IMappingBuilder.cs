using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace QueryMutator.Core
{
    public interface IMappingBuilder<TSource, TTarget>
    {
        IMappingBuilder<TSource, TTarget> MapMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector, TMember constant);

        IMappingBuilder<TSource, TTarget> MapMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector, Expression<Func<TSource, TMember>> mappingExpression);

        IMappingBuilder<TSource, TTarget> MapMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector, Expression<Func<TSource, TMember?>> mappingExpression) where TMember : struct;

        IMappingBuilder<TSource, TTarget> MapMember<TMember>(Expression<Func<TTarget, TMember?>> memberSelector, Expression<Func<TSource, TMember>> mappingExpression) where TMember : struct;

        IMappingBuilder<TSource, TTarget> MapMemberList<TTargetMember, TSourceMember>(Expression<Func<TTarget, IEnumerable<TTargetMember>>> memberSelector, Expression<Func<TSource, IEnumerable<TSourceMember>>> mappingExpression);

        IMappingBuilder<TSource, TTarget> IgnoreMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector);

        IMappingBuilder<TSource, TTarget> ValidateMapping(ValidationMode mode);
    }

    public interface IMappingBuilder<TSource, TTarget, TParam> : IMappingBuilder<TSource, TTarget>
    {
        IMappingBuilder<TSource, TTarget, TParam> MapMemberWithParameter<TMember>(Expression<Func<TTarget, TMember>> memberSelector, Func<TParam, Expression<Func<TSource, TMember>>> mappingExpression);
    }
}

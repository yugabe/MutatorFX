using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MutatorFX.QueryMutator.MemberMappings;

namespace MutatorFX.QueryMutator
{
    public interface IMappingBuilder<TSource, TTarget>
    {
        ParameterExpression SourceParameter { get; }
        IEnumerable<MemberMapping<TSource, TTarget>> MemberMappings { get; }
        IMappingBuilder<TSource, TTarget> Add(MemberMapping<TSource, TTarget> mapping);
        Mapping<TSource, TTarget> Build();
    }

    public interface IMappingBuilder<TSource, TTarget, TParameter> : IMappingBuilder<TSource, TTarget>
    {
        IEnumerable<MemberMapping<TSource, TTarget, TParameter>> ParameterizedMemberMappings { get; }
        IMappingBuilder<TSource, TTarget, TParameter> Add(MemberMapping<TSource, TTarget, TParameter> mapping);
        Mapping<TSource, TTarget, TParameter> Build();
    }
}

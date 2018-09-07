using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MutatorFX.QueryMutator.MappingBuilders;
using MutatorFX.QueryMutator.MemberMappings;

namespace MutatorFX.QueryMutator
{
    public interface IMappingBuilder<TSource, TTarget>
    {
        IEnumerable<MemberMapping<TSource, TTarget>> MemberMappings { get; }
        ParameterExpression SourceParameter { get; }

        IMappingBuilder<TSource, TTarget> Add(MemberMapping<TSource, TTarget> mapping);
        Mapping<TSource, TTarget> Build();
    }

    public interface IMappingBuilder<TSource, TTarget, TParameter> : IMappingBuilder<TSource, TTarget>
    {
        Mapping<TSource, TTarget, TParameter> Build();
    }
}

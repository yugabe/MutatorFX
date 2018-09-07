using System.Collections.Generic;
using System.Linq.Expressions;
using MutatorFX.QueryMutator.Mappings;
using MutatorFX.QueryMutator.MemberMappings;

namespace MutatorFX.QueryMutator
{
    public interface IParameterizedMappingBuilder<TSource, TTarget, TParameter> 
        : IMappingBuilder<TSource, TTarget>
    {
        IMappingBuilder<TSource, TTarget> BaseMappingBuilder { get; }

        ParameterizedMapping<TSource, TTarget, TParameter> Build();
    }
}

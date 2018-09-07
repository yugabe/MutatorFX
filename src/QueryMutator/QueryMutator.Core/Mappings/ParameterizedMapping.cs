using MutatorFX.QueryMutator.MemberMappings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MutatorFX.QueryMutator.Mappings
{
    public class ParameterizedMapping<TSource, TTarget, TParameter> : ParameterizableMappingBase<TSource, TTarget, TParameter>
    {
        public ParameterizedMapping(IMapping<TSource, TTarget> baseMapping, ICollection<Func<TParameter, MemberMapping<TSource, TTarget>>> parameterizationMappings) : base(baseMapping) => ParameterizationMappings = parameterizationMappings;

        public ICollection<Func<TParameter, MemberMapping<TSource, TTarget>>> ParameterizationMappings { get; }

        protected override IEnumerable<MemberMapping<TSource, TTarget>> Parameterize(TParameter parameter) => ParameterizationMappings.Select(m => m(parameter));
    }
}

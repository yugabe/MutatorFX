using MutatorFX.QueryMutator.MemberMappings;
using System.Collections.Generic;
using System.Linq;

namespace MutatorFX.QueryMutator
{
    public abstract class ParameterizableMappingBase<TSource, TTarget, TParameter>
    {
        public ParameterizableMappingBase(IMapping<TSource, TTarget> baseMapping) => BaseMapping = baseMapping;
        public IMapping<TSource, TTarget> BaseMapping { get; }
        public IMapping<TSource, TTarget> With(TParameter parameter) => new Mapping<TSource, TTarget>(BaseMapping.SourceParameter, BaseMapping.MemberMappings.Concat(Parameterize(parameter)));
        protected abstract IEnumerable<MemberMapping<TSource, TTarget>> Parameterize(TParameter parameter);
    }
}

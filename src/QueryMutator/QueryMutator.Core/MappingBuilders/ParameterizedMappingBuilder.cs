using MutatorFX.Coding;
using MutatorFX.QueryMutator.Mappings;
using MutatorFX.QueryMutator.MemberMappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MutatorFX.QueryMutator.MappingBuilders
{
    public class ParameterizedMappingBuilder<TSource, TTarget, TParameter>
        : IMappingBuilder<TSource, TTarget>, IParameterizedMappingBuilder<TSource, TTarget, TParameter>
    {
        public ParameterizedMappingBuilder(IMappingBuilder<TSource, TTarget> baseMappingBuilder) => BaseMappingBuilder = baseMappingBuilder;

        protected ICollection<Func<TParameter, MemberMapping<TSource, TTarget>>> AdditionalMemberMappings { get; } = new List<Func<TParameter, MemberMapping<TSource, TTarget>>>();

        public ParameterExpression SourceParameter => BaseMappingBuilder.SourceParameter;

        public IMappingBuilder<TSource, TTarget> BaseMappingBuilder { get; }

        public IParameterizedMappingBuilder<TSource, TTarget, TParameter> Add(Func<TParameter, MemberMapping<TSource, TTarget>> memberMapping)
            => this.Do(b => b.AdditionalMemberMappings.Add(memberMapping));

        public ParameterizedMapping<TSource, TTarget, TParameter> Build()
        {
            return new ParameterizedMapping<TSource, TTarget, TParameter>(BaseMappingBuilder.Build(), AdditionalMemberMappings);
        }

        IEnumerable<MemberMapping<TSource, TTarget>> IMappingBuilder<TSource, TTarget>.MemberMappings => BaseMappingBuilder.MemberMappings;
        IMappingBuilder<TSource, TTarget> IMappingBuilder<TSource, TTarget>.Add(MemberMapping<TSource, TTarget> mapping) => this.Do(b => BaseMappingBuilder.Add(mapping));
        Mapping<TSource, TTarget> IMappingBuilder<TSource, TTarget>.Build() => throw new InvalidOperationException();

        IParameterizedMappingBuilder<TSource, TTarget, TParameter> IMappingBuilder<TSource, TTarget>.WithParameter<TParameter>(Action<IParameterizedMappingBuilder<TSource, TTarget, TParameter>> builderAction)
        
    }
}

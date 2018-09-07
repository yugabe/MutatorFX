using MutatorFX.Coding;
using MutatorFX.QueryMutator.MappingBuilders;
using MutatorFX.QueryMutator.Mappings;
using MutatorFX.QueryMutator.MemberMappings;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using static System.Linq.Expressions.Expression;

namespace MutatorFX.QueryMutator
{
    public class MappingBuilder<TSource, TTarget> : IMappingBuilder<TSource, TTarget>
    {
        public MappingBuilder() => SourceParameter = Parameter(typeof(TSource), typeof(TSource).Name.ToLower());

        public ParameterExpression SourceParameter { get; }
        protected ICollection<MemberMapping<TSource, TTarget>> MemberMappingCollection { get; } = new List<MemberMapping<TSource, TTarget>>();
        public IEnumerable<MemberMapping<TSource, TTarget>> MemberMappings { get; }
        public Mapping<TSource, TTarget> Build() => new Mapping<TSource, TTarget>(SourceParameter, MemberMappings);
        public IMappingBuilder<TSource, TTarget> Add(MemberMapping<TSource, TTarget> mapping) => this.Do(m => MemberMappingCollection.Add(mapping));

        public IParameterizedMappingBuilder<TSource, TTarget, TParameter> WithParameter<TParameter>(Action<IParameterizedMappingBuilder<TSource, TTarget, TParameter>> builderAction) => new ParameterizedMappingBuilder<TSource, TTarget, TParameter>(this).Do(builderAction);
    }
}

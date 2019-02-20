using MutatorFX.Coding;
using MutatorFX.QueryMutator.MemberMappings;
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
        public Mapping<TSource, TTarget> Build() => new Mapping<TSource, TTarget>(SourceParameter, MemberMappingCollection);
        public IMappingBuilder<TSource, TTarget> Add(MemberMapping<TSource, TTarget> mapping)
            => this.Do(m => MemberMappingCollection.Add(mapping));
    }

    public class MappingBuilder<TSource, TTarget, TParameter> : MappingBuilder<TSource, TTarget>, IMappingBuilder<TSource, TTarget>, IMappingBuilder<TSource, TTarget, TParameter>
    {
        protected ICollection<MemberMapping<TSource, TTarget, TParameter>> ParameterizedMemberMappingCollection { get; } = new List<MemberMapping<TSource, TTarget, TParameter>>();
        public IEnumerable<MemberMapping<TSource, TTarget, TParameter>> ParameterizedMemberMappings => throw new System.NotImplementedException();
        public new Mapping<TSource, TTarget, TParameter> Build() => new Mapping<TSource, TTarget, TParameter>(SourceParameter, MemberMappings, ParameterizedMemberMappingCollection);
        public IMappingBuilder<TSource, TTarget,TParameter> Add(MemberMapping<TSource, TTarget, TParameter> mapping)
            => this.Do(b => ParameterizedMemberMappingCollection.Add(mapping));

    }
}

using MutatorFX.Coding;
using MutatorFX.QueryMutator.MemberMappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using static System.Linq.Expressions.Expression;

namespace MutatorFX.QueryMutator
{
    public class Mapping<TSource, TTarget> : IMapping<TSource, TTarget>
    {
        public Mapping(ParameterExpression sourceParameter, IEnumerable<MemberMapping<TSource, TTarget>> memberMappings)
        {
            SourceParameter = sourceParameter;
            MemberMappings = memberMappings;
        }

        public static Mapping<TSource, TTarget> Create(Action<MappingBuilder<TSource, TTarget>> mappingFactory) => new MappingBuilder<TSource, TTarget>().Do(mappingFactory).Build();

        protected NewExpression New { get; } = New(typeof(TTarget));
        public ParameterExpression SourceParameter { get; }
        public IEnumerable<MemberMapping<TSource, TTarget>> MemberMappings { get; }
        public virtual Expression<Func<TSource, TTarget>> ToExpression() => Lambda<Func<TSource, TTarget>>(
            MemberInit(New,
            MemberMappings.GroupBy(p => p.TargetMember).Select(p => p.Last()).Select(p => (p.TargetMember, Expression: p.GenerateExpression())).Where(p => p.Expression != null).Select(p => Bind(p.TargetMember, p.Expression))),
            SourceParameter);
    }

    public class Mapping<TSource, TTarget, TParameter> : Mapping<TSource, TTarget>
    {
        public Mapping(ParameterExpression sourceParameter, IEnumerable<MemberMapping<TSource, TTarget>> memberMappings, IEnumerable<MemberMapping<TSource, TTarget, TParameter>>) : base(sourceParameter, memberMappings)
        {

        }
    }
}

using MutatorFX.Coding;
using MutatorFX.QueryMutator.MemberMappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using static System.Linq.Expressions.Expression;

namespace MutatorFX.QueryMutator
{
    public class Mapping<TSource, TTarget> : MappingBase<TSource, TTarget>, IMapping<TSource, TTarget>
    {
        public Mapping(ParameterExpression sourceParameter, IEnumerable<MemberMapping<TSource, TTarget>> memberMappings) : base(sourceParameter, memberMappings) 
            => MemberMappings = memberMappings.GroupBy(p => p.TargetMember).Select(p => p.Last());

        public IEnumerable<MemberMapping<TSource, TTarget>> MemberMappings { get; }

        public static Mapping<TSource, TTarget> Create(Action<MappingBuilder<TSource, TTarget>> mappingFactory) => new MappingBuilder<TSource, TTarget>().Do(mappingFactory).Build();

        public virtual Expression<Func<TSource, TTarget>> ToExpression()
            => Lambda<Func<TSource, TTarget>>(MemberInit(New, GetMemberBindings()), SourceParameter);

        protected IEnumerable<MemberBinding> GetMemberBindings()
            => MemberMappings.Select(p => (p.TargetMember, Expression: p.GenerateExpression())).Where(p => p.Expression != null).Select(p => Bind(p.TargetMember, p.Expression));
    }

    public class Mapping<TSource, TTarget, TParameter> : MappingBase<TSource, TTarget>, IMapping<TSource, TTarget, TParameter>
    {
        public Mapping(ParameterExpression sourceParameter, IEnumerable<MemberMapping<TSource, TTarget>> memberMappings, IEnumerable<MemberMapping<TSource, TTarget, TParameter>> parameterizedMemberMappings) : base(sourceParameter, memberMappings)
        {
            ParameterizedMemberMappings = parameterizedMemberMappings;
            MappingFactory = memberMappings.Select(m => (m.TargetMember, (Func<TParameter, Expression>)(p => m.GenerateExpression())))
                .Concat(parameterizedMemberMappings.Select(m => (m.TargetMember, (Func<TParameter, Expression>)(p => m.GenerateExpression(p))))).GroupBy(m => m.TargetMember).Select(m => m.Last());
        }

        public static Mapping<TSource, TTarget, TParameter> Create(Action<MappingBuilder<TSource, TTarget, TParameter>> mappingFactory) => new MappingBuilder<TSource, TTarget, TParameter>().Do(mappingFactory).Build();

        public IEnumerable<(MemberInfo TargetMember, Func<TParameter, Expression> ExpressionFactory)> MappingFactory { get; }
        public IEnumerable<MemberMapping<TSource, TTarget, TParameter>> ParameterizedMemberMappings { get; }
        protected NewExpression New { get; } = New(typeof(TTarget));

        public IEnumerable<MemberMappingBase<TSource, TTarget>> MemberMappings => OriginalMemberMappings.Concat(ParameterizedMemberMappings);

        protected IEnumerable<MemberBinding> GetMemberBindings(TParameter parameter)
            => MappingFactory.Select(p => (TargetMember: p.TargetMember, Expression: p.ExpressionFactory(parameter))).Where(p => p.Expression != null).Select(p => Bind(p.TargetMember, p.Expression));

        public Expression<Func<TSource, TTarget>> ToExpression(TParameter parameter)
            => Lambda<Func<TSource, TTarget>>(MemberInit(New, GetMemberBindings(parameter)), SourceParameter);
    }
}

using MutatorFX.Coding;
using MutatorFX.QueryMutator.Expressions;
using MutatorFX.QueryMutator.MemberMappings;
using MutatorFX.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using static System.Linq.Expressions.Expression;

namespace MutatorFX.QueryMutator
{
    public class Mapping<TSource, TTarget>
    {
        public Mapping(ParameterExpression sourceParameter, IEnumerable<MemberMapping<TSource, TTarget>> memberMappings)
        {
            SourceParameter = sourceParameter;
            MemberMappings = memberMappings;
        }

        public ParameterExpression SourceParameter { get; }
        public IEnumerable<MemberMapping<TSource, TTarget>> MemberMappings { get; }
        public virtual Expression<Func<TSource, TTarget>> ToExpression() => Lambda<Func<TSource, TTarget>>(
            MemberInit(New(typeof(TTarget)),
            MemberMappings.GroupBy(p => p.TargetMember).Select(p => p.Last()).Select(p => (p.TargetMember, Expression: p.GenerateExpression())).Where(p => p.Expression != null).Select(p => Bind(p.TargetMember, p.Expression))),
            SourceParameter);
    }
}

using MutatorFX.QueryMutator.MemberMappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using static System.Linq.Expressions.Expression;

namespace MutatorFX.QueryMutator
{
    public abstract class MappingBase<TSource, TTarget>
    {
        public MappingBase(ParameterExpression sourceParameter, IEnumerable<MemberMapping<TSource, TTarget>> memberMappings)
        {
            SourceParameter = sourceParameter;
            OriginalMemberMappings = memberMappings;
        }
        protected NewExpression New { get; } = New(typeof(TTarget));
        public ParameterExpression SourceParameter { get; }
        public IEnumerable<MemberMappingBase<TSource, TTarget>> OriginalMemberMappings { get; }
    }
}

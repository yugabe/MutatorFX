using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace MutatorFX.QueryMutator.MemberMappings
{
    public abstract class MemberMapping<TSource, TTarget>
    {
        public MemberMapping(ParameterExpression sourceParameter, MemberInfo targetMember)
        {
            SourceParameter = sourceParameter;
            TargetMember = targetMember;
        }

        public ParameterExpression SourceParameter { get; }
        public MemberInfo TargetMember { get; protected set; }

        public abstract Expression GenerateExpression();
    }
}

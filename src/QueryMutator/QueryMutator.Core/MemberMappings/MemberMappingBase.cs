using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace MutatorFX.QueryMutator
{
    public abstract class MemberMappingBase<TSource, TTarget>
    {
        public MemberMappingBase(ParameterExpression sourceParameter, MemberInfo targetMember)
        {
            SourceParameter = sourceParameter;
            TargetMember = targetMember;
        }

        public ParameterExpression SourceParameter { get; }
        public MemberInfo TargetMember { get; }
    }
}

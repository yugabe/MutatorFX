using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace MutatorFX.QueryMutator.MemberMappings
{
    public class IgnoreMemberMapping<TSource, TTarget> : MemberMapping<TSource, TTarget>
    {
        public IgnoreMemberMapping(ParameterExpression sourceParameter, MemberInfo targetMember) : base(sourceParameter, targetMember) { }

        public override Expression GenerateExpression() => null;
    }
}

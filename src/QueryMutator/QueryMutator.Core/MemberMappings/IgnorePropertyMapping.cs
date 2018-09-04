using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace MutatorFX.QueryMutator.MemberMappings
{
    public class IgnorePropertyMapping<TSource, TTarget> : MemberMapping<TSource, TTarget>
    {
        public IgnorePropertyMapping(ParameterExpression sourceParameter, MemberInfo targetMember) : base(sourceParameter, targetMember) { }

        public override Expression GenerateExpression() => null;
    }
}

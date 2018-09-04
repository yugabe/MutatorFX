using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using static System.Linq.Expressions.Expression;

namespace MutatorFX.QueryMutator.MemberMappings
{

    public class MemberChainMapping<TSource, TTarget> : MemberMapping<TSource, TTarget>
    {
        public MemberChainMapping(ParameterExpression sourceParameter, MemberInfo targetMember, IEnumerable<PropertyInfo> propertyChain) : base(sourceParameter, targetMember)
            => PropertyChain = propertyChain;

        public IEnumerable<PropertyInfo> PropertyChain { get; }

        public override Expression GenerateExpression()
            => PropertyChain.Aggregate((Expression)SourceParameter, MakeMemberAccess);
    }
}

using System.Linq.Expressions;
using System.Reflection;

namespace MutatorFX.QueryMutator.MemberMappings
{
    public abstract class MemberMapping<TSource, TTarget> : MemberMappingBase<TSource, TTarget>
    {
        public MemberMapping(ParameterExpression sourceParameter, MemberInfo targetMember) : base(sourceParameter, targetMember) { }

        public abstract Expression GenerateExpression();
    }

    public abstract class MemberMapping<TSource, TTarget, TParameter> : MemberMappingBase<TSource, TTarget>
    {
        public MemberMapping(ParameterExpression sourceParameter, MemberInfo targetMember) : base(sourceParameter, targetMember) { }

        public abstract Expression GenerateExpression(TParameter parameter);
    }
}

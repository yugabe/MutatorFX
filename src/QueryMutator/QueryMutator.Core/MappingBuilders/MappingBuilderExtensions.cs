using MutatorFX.Coding;
using MutatorFX.QueryMutator.MemberMappings;
using MutatorFX.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace MutatorFX.QueryMutator
{
    public static class MappingBuilderExtensions
    {
        public static IMappingBuilder<TSource, TTarget> MapMember<TSource, TTarget, TMember>(this IMappingBuilder<TSource, TTarget> builder, Expression<Func<TTarget, TMember>> memberSelector, Expression<Func<TSource, TMember>> mappingExpression)
            => builder.Add(new CustomMemberMapping<TSource, TTarget, TMember>(builder.SourceParameter, memberSelector, mappingExpression));
        public static IMappingBuilder<TSource, TTarget> IgnoreMember<TSource, TTarget, TMember>(this IMappingBuilder<TSource, TTarget> builder, Expression<Func<TTarget, TMember>> memberSelector)
            => builder.Add(new IgnoreMemberMapping<TSource, TTarget>(builder.SourceParameter, (memberSelector.Body as MemberExpression).Member));
        public static IMappingBuilder<TSource, TTarget> MapMatchingPropertyChains<TSource, TTarget>(this IMappingBuilder<TSource, TTarget> builder)
            => builder.Do(b => typeof(TTarget).GetProperties().For(p => typeof(TSource).GetPropertyChains(p.Name).FirstOrDefault()?.Branch((IEnumerable<PropertyInfo> ch) => ch != null, ch => builder.Add(new PropertyChainMapping<TSource, TTarget>(builder.SourceParameter, p, ch)))));

        public static IMappingBuilder<TSource, TTarget, TParameter> MapMember<TSource, TTarget, TParameter, TMember>(this IMappingBuilder<TSource, TTarget, TParameter> builder, Expression<Func<TTarget, TMember>> memberSelector, Func<TParameter, Expression<Func<TSource, TMember>>> mappingExpression)
            => builder.Add(new ParameterizedCustomMemberMapping<TSource, TTarget, TMember, TParameter>(builder.SourceParameter, memberSelector, mappingExpression));
    }
}

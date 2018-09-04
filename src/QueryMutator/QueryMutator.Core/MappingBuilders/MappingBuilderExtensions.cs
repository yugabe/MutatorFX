using MutatorFX.QueryMutator.MemberMappings;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using MutatorFX.Coding;
using MutatorFX.Reflection;
using System.Linq;

namespace MutatorFX.QueryMutator
{
    public static class MappingBuilderExtensions
    {
        public static MappingBuilder<TSource, TTarget> MapProperty<TSource, TTarget, TProperty>(this MappingBuilder<TSource, TTarget> builder, Expression<Func<TTarget, TProperty>> propertySelector, Expression<Func<TSource, TProperty>> mappingExpression)
            => builder.Add(new CustomMemberMapping<TSource, TTarget, TProperty>(builder.SourceParameter, propertySelector, mappingExpression));
        public static MappingBuilder<TSource, TTarget> IgnoreProperty<TSource, TTarget, TProperty>(this MappingBuilder<TSource, TTarget> builder, Expression<Func<TTarget, TProperty>> propertySelector)
            => builder.Add(new IgnorePropertyMapping<TSource, TTarget>(builder.SourceParameter, (propertySelector.Body as MemberExpression).Member));
        public static MappingBuilder<TSource, TTarget> MapMatchingPropertyChains<TSource, TTarget>(this MappingBuilder<TSource, TTarget> builder)
            => builder.Do(b => typeof(TTarget).GetProperties().For(p => typeof(TSource).GetPropertyChains(p.Name).FirstOrDefault()?.Branch(ch => ch != null, ch => builder.Add(new PropertyChainMapping<TSource, TTarget>(builder.SourceParameter, p, ch)))));
    }
}

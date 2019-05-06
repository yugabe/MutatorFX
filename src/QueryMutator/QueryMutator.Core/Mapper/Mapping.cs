using System;
using System.Linq.Expressions;

namespace QueryMutator.Core
{
    /// <summary>
    /// Represents a generic mapping.
    /// </summary>
    public interface IMapping
    {
        /// <summary>
        /// Contains the expression used for the mapping.
        /// </summary>
        LambdaExpression Expression { get; }
    }

    /// <summary>
    /// Represents a mapping.
    /// </summary>
    /// <typeparam name="TSource">The source type of the mapping.</typeparam>
    /// <typeparam name="TTarget">The target type of the mapping.</typeparam>
    public interface IMapping<TSource, TTarget> : IMapping
    {
        /// <summary>
        /// Contains the expression used for the mapping.
        /// </summary>
        new Expression<Func<TSource, TTarget>> Expression { get; }
    }

    internal class Mapping<TSource, TTarget> : IMapping<TSource, TTarget>
    {
        public Expression<Func<TSource, TTarget>> Expression { get; set; }

        LambdaExpression IMapping.Expression => Expression;
    }

    /// <summary>
    /// Represents a mapping with a parameter.
    /// </summary>
    /// <typeparam name="TSource">The source type of the mapping.</typeparam>
    /// <typeparam name="TTarget">The target type of the mapping.</typeparam>
    /// <typeparam name="TParam">The parameter type of the mapping.</typeparam>
    public interface IMapping<TSource, TTarget, TParam>
    {
    }

    internal class Mapping<TSource, TTarget, TParam> : IMapping, IMapping<TSource, TTarget, TParam>
    {
        public MappingBuilder<TSource, TTarget, TParam> Builder { get; set; }

        LambdaExpression IMapping.Expression => null;
    }
}

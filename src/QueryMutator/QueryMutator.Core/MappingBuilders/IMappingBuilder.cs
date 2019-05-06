using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace QueryMutator.Core
{
    /// <summary>
    /// Represents an object that can be used to create a custom mapping between the 
    /// <typeparamref name="TSource"/> and <typeparamref name="TTarget"/> types.
    /// </summary>
    /// <typeparam name="TSource">The source type of the mapping.</typeparam>
    /// <typeparam name="TTarget">The target type of the mapping.</typeparam>
    public interface IMappingBuilder<TSource, TTarget>
    {
        /// <summary>
        /// Creates a mapping between a target property and a constant.
        /// </summary>
        /// <typeparam name="TMember">The type of the property.</typeparam>
        /// <param name="memberSelector">The selector for the target property.</param>
        /// <param name="constant">The value of the constant.</param>
        IMappingBuilder<TSource, TTarget> MapMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector, TMember constant);

        /// <summary>
        /// Creates a mapping between a target and a source property.
        /// </summary>
        /// <typeparam name="TMember">The type of the property.</typeparam>
        /// <param name="memberSelector">The selector for the target property.</param>
        /// <param name="mappingExpression">The expression for the source property.</param>
        IMappingBuilder<TSource, TTarget> MapMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector, Expression<Func<TSource, TMember>> mappingExpression);

        /// <summary>
        /// Creates a mapping between a target and a source property, where the source property type is nullable.
        /// </summary>
        /// <typeparam name="TMember">The underlying property type.</typeparam>
        /// <param name="memberSelector">The selector for the target property.</param>
        /// <param name="mappingExpression">The expression for the source property.</param>
        IMappingBuilder<TSource, TTarget> MapMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector, Expression<Func<TSource, TMember?>> mappingExpression) where TMember : struct;

        /// <summary>
        /// Creates a mapping between a target and a source property, where the target property type is nullable.
        /// </summary>
        /// <typeparam name="TMember">The underlying property type.</typeparam>
        /// <param name="memberSelector">The selector for the target property.</param>
        /// <param name="mappingExpression">The expression for the source property.</param>
        IMappingBuilder<TSource, TTarget> MapMember<TMember>(Expression<Func<TTarget, TMember?>> memberSelector, Expression<Func<TSource, TMember>> mappingExpression) where TMember : struct;

        /// <summary>
        /// Creates a mapping between a target and a source property, where each property type implements <see cref="IEnumerable{}"/>.
        /// If no mapping exists between <typeparamref name="TSourceMember"/> and <typeparamref name="TTargetMember"/>, a default mapping will be created.
        /// </summary>
        /// <typeparam name="TTargetMember">The generic argument of the target property type.</typeparam>
        /// <typeparam name="TSourceMember">The generic argument of the source property type.</typeparam>
        /// <param name="memberSelector">The selector for the target property.</param>
        /// <param name="mappingExpression">The expression for the source property.</param>
        IMappingBuilder<TSource, TTarget> MapMemberList<TTargetMember, TSourceMember>(Expression<Func<TTarget, IEnumerable<TTargetMember>>> memberSelector, Expression<Func<TSource, IEnumerable<TSourceMember>>> mappingExpression);

        /// <summary>
        /// Ignores the selected target property, excluding it from the mapping.
        /// </summary>
        /// <typeparam name="TMember">The type of the property.</typeparam>
        /// <param name="memberSelector">The selector for the target property.</param>
        IMappingBuilder<TSource, TTarget> IgnoreMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector);

        /// <summary>
        /// Sets the validation mode to be used when creating the mappings.
        /// </summary>
        /// <param name="mode">The selected validation mode.</param>
        IMappingBuilder<TSource, TTarget> ValidateMapping(ValidationMode mode);
    }

    /// <summary>
    /// Represents an object that can be used to create a custom mapping between the 
    /// <typeparamref name="TSource"/> and <typeparamref name="TTarget"/> types with a 
    /// <typeparamref name="TParam"/> parameter.
    /// </summary>
    /// <typeparam name="TSource">The source type of the mapping.</typeparam>
    /// <typeparam name="TTarget">The target type of the mapping.</typeparam>
    /// <typeparam name="TParam">The param type of the mapping.</typeparam>
    public interface IMappingBuilder<TSource, TTarget, TParam> : IMappingBuilder<TSource, TTarget>
    {
        IMappingBuilder<TSource, TTarget, TParam> MapMemberWithParameter<TMember>(Expression<Func<TTarget, TMember>> memberSelector, Func<TParam, Expression<Func<TSource, TMember>>> mappingExpression);
    }
}

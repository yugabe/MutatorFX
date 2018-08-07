using System;
using System.Linq;
using System.Linq.Expressions;

namespace MutatorFX.FilterMutator
{
    /// <summary>
    /// A simple <see cref="ITransformer{TSource, TResult}"/> implementation, which accepts the implementation details in constructor.
    /// </summary>
    /// <typeparam name="TSource">The source type to transform.</typeparam>
    /// <typeparam name="TResult">The result type to transform <typeparamref name="TSource"/> to.</typeparam>
    public class ExpressionTransformer<TSource, TResult> : ITransformer<TSource, TResult>
    {
        /// <summary>
        /// Create a simple transformer, which will use the provided expression to transform the source to the result dataset.
        /// </summary>
        /// <param name="transformExpression">The expression used to transform from <typeparamref name="TSource"/> to <typeparamref name="TResult"/>.</param>
        public ExpressionTransformer(Expression<Func<TSource, TResult>> transformExpression) => 
            TransformExpression = transformExpression ?? throw new ArgumentNullException(nameof(transformExpression));

        private Expression<Func<TSource, TResult>> TransformExpression { get; }

        /// <summary>
        /// Use the aquired expression to transform the <paramref name="source"/> dataset to the result dataset.
        /// </summary>
        /// <param name="source">The source to transform.</param>
        /// <returns>The transformed results.</returns>
        public IQueryable<TResult> Transform(IQueryable<TSource> source) => source.Select(TransformExpression);
    }
}

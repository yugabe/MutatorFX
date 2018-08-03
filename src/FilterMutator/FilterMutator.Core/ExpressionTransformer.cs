using System;
using System.Linq;
using System.Linq.Expressions;

namespace MutatorFX.FilterMutator
{
    public class ExpressionTransformer<TSource, TResult> : ITransformer<TSource, TResult>
    {
        public ExpressionTransformer(Expression<Func<TSource, TResult>> transformExpression) => 
            TransformExpression = transformExpression ?? throw new ArgumentNullException(nameof(transformExpression));

        public Expression<Func<TSource, TResult>> TransformExpression { get; }

        public IQueryable<TResult> Transform(IQueryable<TSource> source) => source.Select(TransformExpression);
    }
}

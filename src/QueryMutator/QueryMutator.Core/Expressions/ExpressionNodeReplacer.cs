using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace QueryMutator.Core
{
    internal class ExpressionNodeReplacer : ExpressionVisitor
    {
        public IReadOnlyDictionary<Expression, Expression> ReplaceTokens { get; }

        public ExpressionNodeReplacer(ParameterExpression source, ParameterExpression target)
            : this(new Dictionary<Expression, Expression> { [source] = target }) { }

        public ExpressionNodeReplacer(IReadOnlyDictionary<Expression, Expression> replaceTokenMap)
        {
            ReplaceTokens = replaceTokenMap;
        }

        public override Expression Visit(Expression node)
        {
            return ReplaceTokens.TryGetValue(node, out var target) ? target : base.Visit(node);
        }
    }

    internal static class ExpressionNodeReplacerExpressions
    {
        public static Expression<Func<T, TResult>> ReplaceParameter<T, TResult>(this Expression<Func<T, TResult>> expression, ParameterExpression target)
        {
            return Expression.Lambda<Func<T, TResult>>(new ExpressionNodeReplacer(expression.Parameters.Single(), target).Visit(expression.Body), target);
        }
    }
}

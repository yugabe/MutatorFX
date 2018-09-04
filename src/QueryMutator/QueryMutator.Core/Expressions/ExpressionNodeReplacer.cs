using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using static System.Linq.Expressions.Expression;

namespace MutatorFX.QueryMutator.Expressions
{
    public class ExpressionNodeReplacer : ExpressionVisitor
    {
        public IReadOnlyDictionary<Expression, Expression> ReplaceTokens { get; }

        public ExpressionNodeReplacer(ParameterExpression source, ParameterExpression target)
            : this(new Dictionary<Expression, Expression> { [source] = target }) { }

        public ExpressionNodeReplacer(IReadOnlyDictionary<Expression, Expression> replaceTokenMap)
            => ReplaceTokens = replaceTokenMap;

        public override Expression Visit(Expression node) => ReplaceTokens.TryGetValue(node, out var target) ? target : base.Visit(node);
    }

    public static class ExpressionNodeReplacerExpressions
    {
        public static Expression<Func<T, TResult>> ReplaceParameter<T, TResult>(this Expression<Func<T, TResult>> expression, ParameterExpression target)
            => Lambda<Func<T, TResult>>(new ExpressionNodeReplacer(expression.Parameters.Single(), target).Visit(expression.Body), target);
    }
}

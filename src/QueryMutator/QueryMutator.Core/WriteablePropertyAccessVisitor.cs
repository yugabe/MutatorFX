using MutatorFX.Coding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace MutatorFX.QueryMutator
{
    public class WriteablePropertyAccessVisitor : ExpressionVisitor
    {
        private WriteablePropertyAccessVisitor() { }
        private List<PropertyInfo> VisitProperties(Expression node) => Visit(node).Pipe(_ => _properties.ToList());

        public override Expression Visit(Expression node)
        {
            if (!(node is MemberExpression exp) || !(exp.Member is PropertyInfo prop) || !prop.CanWrite)
            {
                if (node.NodeType != ExpressionType.Parameter)
                {
                    throw new InvalidOperationException($"Provided expression is not of type {nameof(MemberExpression)} or the access is not to a publicly settable property member.");
                }

                return node;
            }
            return _properties.Do(p => p.Enqueue(prop)).Pipe(_ => base.Visit(node));
        }
        private Queue<PropertyInfo> _properties = new Queue<PropertyInfo>();
        public static List<PropertyInfo> VisitPropertyChain(Expression node) => new WriteablePropertyAccessVisitor().VisitProperties(node);
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace QueryMutator.Core
{
    public class ComplexMemberBinding : MemberBindingBase
    {
        public PropertyInfo SourceMember { get; set; }

        public new MemberInitExpression SourceExpression { get; set; }

        public override Expression GenerateExpression(ParameterExpression parameter)
        {
            return ReplaceParameters(SourceExpression, parameter);
        }

        private MemberInitExpression ReplaceParameters(MemberInitExpression expression, ParameterExpression parameter)
        {
            var bindings = new List<MemberAssignment>();

            foreach (var binding in expression.Bindings.ToList())
            {
                var memberBinding = binding as MemberAssignment;
                if (memberBinding.Expression is MemberExpression memberExpression)
                {
                    var body = ReplaceParameterChains(memberExpression, parameter);
                    bindings.Add(Expression.Bind(memberBinding.Member, body));
                }
                else if (memberBinding.Expression is MemberInitExpression memberInitExpression)
                {
                    var newMemberInitExpression = ReplaceParameters(memberInitExpression, parameter);
                    bindings.Add(Expression.Bind(memberBinding.Member, newMemberInitExpression));
                }
                else if (memberBinding.Expression.NodeType == ExpressionType.Coalesce)
                {
                    var coalesceExpression = memberBinding.Expression as BinaryExpression;
                    var body = ReplaceParameterChains(coalesceExpression.Left as MemberExpression, parameter);
                    bindings.Add(Expression.Bind(memberBinding.Member, Expression.Coalesce(body, coalesceExpression.Right)));
                }
                else if (memberBinding.Expression.NodeType == ExpressionType.Convert)
                {
                    var convertExpression = memberBinding.Expression as UnaryExpression;
                    var body = ReplaceParameterChains(convertExpression.Operand as MemberExpression, parameter);
                    bindings.Add(Expression.Bind(memberBinding.Member, Expression.Convert(body, convertExpression.Type)));
                }
                // TODO handle list member inits (tolist, select + tolist)
            }

            return Expression.MemberInit(expression.NewExpression, bindings);
        }

        private Expression ReplaceParameterChains(MemberExpression memberExpression, ParameterExpression parameter)
        {
            var properties = new List<PropertyInfo>();

            // Extract all of the nested properties from the expression
            Expression normalExpression = memberExpression;
            while (normalExpression.NodeType == ExpressionType.MemberAccess)
            {
                properties.Add((normalExpression as MemberExpression).Member as PropertyInfo);
                normalExpression = (normalExpression as MemberExpression).Expression;
            }

            // The source member is null when the property is explicitly mapped
            if (SourceMember != null)
            {
                properties.Add(SourceMember);
            }
            properties.Reverse();

            // Construct a new expression with the correct parameter and child properties
            Expression body = parameter;
            foreach (var property in properties)
            {
                body = Expression.Property(body, property);
            }

            return body;
        }
    }
}

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
            return ReplaceParameterChains(SourceExpression, parameter);
        }

        private MemberInitExpression ReplaceParameterChains(MemberInitExpression expression, ParameterExpression parameter)
        {
            var bindings = new List<MemberAssignment>();

            foreach (var binding in expression.Bindings.ToList())
            {
                var memberBinding = binding as MemberAssignment;
                if (memberBinding.Expression is MemberExpression memberExpression)
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
                    if(SourceMember != null)
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

                    bindings.Add(Expression.Bind(binding.Member, body));
                }
                else if (memberBinding.Expression is MemberInitExpression memberInitExpression)
                {
                    var newMemberInitExpression = ReplaceParameterChains(memberInitExpression, parameter);
                    bindings.Add(Expression.Bind(binding.Member, newMemberInitExpression));
                }
            }

            return Expression.MemberInit(expression.NewExpression, bindings);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace QueryMutator.Core
{
    public class UsingMemberBinding : MemberBindingBase
    {
        public new MemberInitExpression SourceExpression { get; set; }

        public MemberInfo SourceMember { get; set; }
        
        public override Expression GenerateExpression(ParameterExpression parameter)
        {
            return ReplaceParameterChains(SourceExpression, parameter);
        }
        
        protected MemberInitExpression ReplaceParameterChains(MemberInitExpression expression, ParameterExpression target)
        {
            var bindings = new List<MemberAssignment>();

            foreach(var binding in expression.Bindings.ToList())
            {
                var memberBinding = binding as MemberAssignment;
                if(memberBinding.Expression is MemberExpression memberExpression)
                {
                    var properties = new List<PropertyInfo>();

                    // Extract all of the nested properties from the expression
                    Expression normalExpression = memberExpression;
                    while (normalExpression.NodeType == ExpressionType.MemberAccess)
                    {
                        properties.Add((normalExpression as MemberExpression).Member as PropertyInfo);
                        normalExpression = (normalExpression as MemberExpression).Expression;
                    }

                    properties.Add(SourceMember as PropertyInfo);
                    properties.Reverse();

                    // Construct a new expression with the correct parameter and child properties
                    Expression body = target;
                    foreach(var property in properties)
                    {
                        body = Expression.Property(body, property);
                    }
                    
                    bindings.Add(Expression.Bind(binding.Member, body));
                }
                else if(memberBinding.Expression is MemberInitExpression memberInitExpression)
                {
                    var newMemberInitExpression = ReplaceParameterChains(memberInitExpression, target);
                    bindings.Add(Expression.Bind(binding.Member, newMemberInitExpression));
                }
            }

            return Expression.MemberInit(expression.NewExpression, bindings);
        }
    }
}

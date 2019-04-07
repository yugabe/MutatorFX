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
                    bindings.Add(Expression.Bind(memberBinding.Member, ReplacePropertyChains(memberExpression, parameter)));
                }
                else if (memberBinding.Expression is MemberInitExpression memberInitExpression)
                {
                    bindings.Add(Expression.Bind(memberBinding.Member, ReplaceParameters(memberInitExpression, parameter)));
                }
                else if (memberBinding.Expression.NodeType == ExpressionType.Coalesce)
                {
                    var coalesceExpression = memberBinding.Expression as BinaryExpression;
                    coalesceExpression = coalesceExpression.Update(ReplacePropertyChains(coalesceExpression.Left as MemberExpression, parameter), coalesceExpression.Conversion, coalesceExpression.Right);
                    bindings.Add(Expression.Bind(memberBinding.Member, coalesceExpression));
                }
                else if (memberBinding.Expression.NodeType == ExpressionType.Convert)
                {
                    var convertExpression = memberBinding.Expression as UnaryExpression;
                    convertExpression = convertExpression.Update(ReplacePropertyChains(convertExpression.Operand as MemberExpression, parameter));
                    bindings.Add(Expression.Bind(memberBinding.Member, convertExpression));
                }
                else if (memberBinding.Expression.NodeType == ExpressionType.Call)
                {
                    var methodCallExpression = memberBinding.Expression as MethodCallExpression;
                    var argument = methodCallExpression.Arguments.FirstOrDefault();
                    if(argument != null)
                    {
                        // In this case the expression is Select() then ToList()
                        if(argument.NodeType == ExpressionType.Call)
                        {
                            var innerMethodCallExpression = argument as MethodCallExpression;
                            if(innerMethodCallExpression.Arguments.FirstOrDefault() is MemberExpression memberArgument)
                            {
                                // Replace the property chains in the first argument and leave the rest
                                var newArguments = new[] { ReplacePropertyChains(memberArgument, parameter) }.Concat(innerMethodCallExpression.Arguments.Skip(1));
                                innerMethodCallExpression = innerMethodCallExpression.Update(innerMethodCallExpression.Object, newArguments);
                                methodCallExpression = methodCallExpression.Update(methodCallExpression.Object, new[] { innerMethodCallExpression });
                                bindings.Add(Expression.Bind(memberBinding.Member, methodCallExpression));
                            }
                        }
                        // In this case there is only a ToList() call
                        else if(argument.NodeType == ExpressionType.MemberAccess)
                        {
                            var newArguments = new[] { ReplacePropertyChains(argument as MemberExpression, parameter) };
                            methodCallExpression = methodCallExpression.Update(methodCallExpression.Object, newArguments);
                            bindings.Add(Expression.Bind(memberBinding.Member, methodCallExpression));
                        }
                    }
                }
            }

            return Expression.MemberInit(expression.NewExpression, bindings);
        }

        private Expression ReplacePropertyChains(MemberExpression memberExpression, ParameterExpression parameter)
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

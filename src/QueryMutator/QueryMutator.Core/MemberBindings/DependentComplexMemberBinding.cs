using System;
using System.Linq.Expressions;

namespace QueryMutator.Core
{
    internal class DependentComplexMemberBinding : ComplexMemberBinding
    {
        public Type SourceType { get; set; }

        public Type TargetType { get; set; }
        
        public override Expression GenerateExpression(ParameterExpression parameter)
        {
            return base.GenerateExpression(parameter);
        }
    }
}

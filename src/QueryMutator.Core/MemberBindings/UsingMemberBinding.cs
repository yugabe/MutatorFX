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
        
        public override Expression GenerateExpression()
        {
            return SourceExpression;
            //return ReplaceParameterChains(SourceExpression, parameter);
        }
        
    }
}

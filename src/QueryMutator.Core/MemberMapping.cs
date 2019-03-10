using System.Linq.Expressions;
using System.Reflection;

namespace QueryMutator.Core
{
    internal class MemberMapping
    {
        public MemberExpression SourceExpression { get; set; }

        public MemberInfo TargetMember { get; set; }
    }

}

using System.Collections.Generic;
using System.Linq.Expressions;

namespace MutatorFX.QueryMutator
{
    public interface IMappingMetadata
    {
        NewExpression New { get; }
        IEnumerable<IPropertyMapping> PropertyMappings { get; }
        ParameterExpression SourceParameter { get; }
    }
}
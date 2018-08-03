using FilterMutator.NetCore.Tests.Data;
using MutatorFX.FilterMutator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilterMutator.NetCore.Tests
{
    public class DogClauseFilterer : ClauseFilterer<Dog, DogFilter>
    {
        public override IEnumerable<IFilterClause<Dog, DogFilter>> GetClauses()
        {
            return CreateClauses()
                .AddClause(d => d.Id, c => d => c.Value == d.Id)
                .AddClause(d => d.MaxId, c => d => d.Id <= c.Value)
                .AddClause(d => d.MinId, c => d => d.Id >= c.Value)
                .AddClause(d => d.OwnerNameLike, c => d => d.Ownerships.Any(o => o.Owner.Name.Contains(c)));
        }
    }
}

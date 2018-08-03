using FilterMutator.NetCore.Tests.Data;
using MutatorFX.FilterMutator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilterMutator.NetCore.Tests
{
    public class DogOwnershipToDtoTransformer : ITransformer<DogOwnership, DogOwnershipDto>
    {
        public IQueryable<DogOwnershipDto> Transform(IQueryable<DogOwnership> source)
            => source.Select(d => new DogOwnershipDto { Id = d.Id });
    }
}

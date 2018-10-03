using MutatorFX.FilterMutator;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilterMutator.NetCore.Tests.TestClasses
{
    public class DogFilteringController
    {
        public DogFilteringController(IQueryExecutor<DogFilter, DogSort, DogDto> queryExecutor)
        {
            QueryExecutor = queryExecutor;
        }

        public IQueryExecutor<DogFilter, DogSort, DogDto> QueryExecutor { get; }

        public PagedResult<DogDto> GetFilteredItems(DogFilter filter)
        {
            return QueryExecutor.ExecuteQuery(filter, 1, 5, DogSort.ParentName, true);
        }
    }
}

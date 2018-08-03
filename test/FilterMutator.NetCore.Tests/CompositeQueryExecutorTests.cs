using FilterMutator.NetCore.Tests.Data;
using FilterMutator.NetCore.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MutatorFX.FilterMutator;
using MutatorFX.FilterMutator.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilterMutator.NetCore.Tests
{
    [TestClass]
    public partial class CompositeQueryExecutorTests
    {
        [TestMethod]
        public void CanComposeSimpleQueryExecutor()
        {
            var context = new TestDbContext();

            var executor = new CompositeQueryExecutor<DogOwnership,
                DogOwnershipDto,
                DogOwnershipFilter,
                DogOwnershipSort>(new DbSetSourceAccessor<TestDbContext, DogOwnership>(context),
                new NoopFilterer<DogOwnership, DogOwnershipFilter>(),
                new DogOwnershipToDtoTransformer(),
                new PropertyChainNameSorter<DogOwnership, DogOwnershipSort>(),
                new SimplePager<DogOwnershipDto>());

            var result = executor.ExecuteQuery(new DogOwnershipFilter { OwnerName = "Alma" }, 2, 10, DogOwnershipSort.OwnerName, true);
        }
    }
}

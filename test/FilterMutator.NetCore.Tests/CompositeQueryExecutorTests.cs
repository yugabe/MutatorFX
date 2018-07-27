using FilterMutator.NetCore.Tests.Data;
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
    public class CompositeQueryExecutorTests
    {
        public class DogOwnershipDto
        {
            public int Id { get; set; }
        }

        public class DogOwnershipFilter
        {
            public string OwnerName { get; set; }
        }

        public enum DogOwnershipSort
        {
            DogId, OwnerId, VetId, OwnerName
        }

        public class DogOwnershipToDtoTransformer : ITransformer<DogOwnership, DogOwnershipDto>
        {
            public IQueryable<DogOwnershipDto> Transform(IQueryable<DogOwnership> source)
                => source.Select(d => new DogOwnershipDto { Id = d.Id });
        }

        [TestMethod]
        public void CanComposeSimpleQueryExecutor()
        {
            var context = new TestDbContext();

            var executor = new CompositeQueryExecutor<DogOwnership,
                DogOwnershipDto,
                DogOwnershipFilter,
                DogOwnershipSort,
                DbSetSourceAccessor<TestDbContext, DogOwnership>,
                NoopFilterer<DogOwnership, DogOwnershipFilter>,
                DogOwnershipToDtoTransformer,
                PropertyChainNameSorter<DogOwnership, DogOwnershipSort>,
                SimplePager<DogOwnershipDto>>(new DbSetSourceAccessor<TestDbContext, DogOwnership>(context),
                new NoopFilterer<DogOwnership, DogOwnershipFilter>(),
                new DogOwnershipToDtoTransformer(),
                new PropertyChainNameSorter<DogOwnership, DogOwnershipSort>(),
                new SimplePager<DogOwnershipDto>());

            var result = executor.ExecuteQuery(new DogOwnershipFilter { OwnerName = "Alma" }, 2, 10, DogOwnershipSort.OwnerName, true);
        }

        public class DogOwnershipQueryExecutor : CompositeQueryExecutor<DogOwnership,
            DogOwnershipDto,
            DogOwnershipFilter,
            DogOwnershipSort,
            DbSetSourceAccessor<TestDbContext, DogOwnership>,
            NoopFilterer<DogOwnership, DogOwnershipFilter>,
            DogOwnershipToDtoTransformer,
            PropertyChainNameSorter<DogOwnership, DogOwnershipSort>,
            SimplePager<DogOwnershipDto>>
        {
            public DogOwnershipQueryExecutor(DbSetSourceAccessor<TestDbContext, DogOwnership> sourceAccessor, NoopFilterer<DogOwnership, DogOwnershipFilter> filterer, DogOwnershipToDtoTransformer transformer, PropertyChainNameSorter<DogOwnership, DogOwnershipSort> sorter, SimplePager<DogOwnershipDto> pager) : base(sourceAccessor, filterer, transformer, sorter, pager)
            {
            }
        }
    }
}

using FilterMutator.NetCore.Tests.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using MutatorFX.FilterMutator;

namespace FilterMutator.NetCore.Tests
{
    [TestClass]
    public class SortingTests
    {
        [TestMethod]
        public void SimpleSortingSucceeds()
        {
            var context = new TestDbContext();

            var source = context.DogOwnerships;

            var sorted = new PropertyChainNameSorter<DogOwnership, DogOwnershipSort>()
                .Sort(source, DogOwnershipSort.OwnerId, true).ToList();

            Assert.IsTrue(source.OrderByDescending(d => d.OwnerId).ToList().SequenceEqual(sorted));
        }

        public enum DogOwnershipSort
        {
            DogId, OwnerId, VetId, OwnerName
        }
    }
}

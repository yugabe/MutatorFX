using FilterMutator.NetCore.Tests.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FilterMutator.NetCore.Tests
{
    [TestClass]
    public class DependencyInjectionTests
    {
        [TestMethod]
        public void CanInjectDbSetAccessor()
        {
            var services = new ServiceCollection().AddDbContext<TestDbContext>();
        }
    }
}

using MutatorFX.Coding;
using FilterMutator.NetCore.Tests.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MutatorFX.FilterMutator;
using MutatorFX.FilterMutator.EFCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FilterMutator.NetCore.Tests.TestClasses;

namespace FilterMutator.NetCore.Tests
{
    [TestClass]
    public class DependencyInjectionTests
    {
        [TestMethod]
        public void CanResolveFilteringByGenericDependencies()
        {
            var provider = new ServiceCollection()
                .AddDbContext<TestDbContext>()
                .AddTransient<DbContext>(s => s.GetRequiredService<TestDbContext>())
                .AddScoped(typeof(ISourceAccessor<>), typeof(DbSetSourceAccessor<>))
                .AddScoped<IQueryExecutor<DogFilter, DogSort, DogDto>, CompositeQueryExecutor<Dog, DogDto, DogFilter, DogSort>>()
                .AddSingleton(typeof(IPager<>), typeof(SimplePager<>))
                .AddSingleton<ITransformer<Dog, DogDto>>(s => new ExpressionTransformer<Dog, DogDto>(d => new DogDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    OwnerNames = d.Ownerships.Select(o => o.Owner.Name).ToList(),
                    SiblingDogIds = d.Ownerships.SelectMany(o => o.Owner.OwnedDogs.Select(c => c.Id)).Distinct().ToList()
                }))
                .AddSingleton<IFilterer<Dog, DogFilter>, DogClauseFilterer>()
                .AddSingleton(typeof(ISorter<,>), typeof(PropertyChainNameSorter<,>))
                .AddScoped<DogFilteringController>()
                .BuildServiceProvider();

            var results = new[] { new DogFilter { MaxId = 28, MinId = 5, OwnerNameLike = "6" },
                new DogFilter { MaxId = 100, OwnerNameLike = "10" },
                new DogFilter { }
            }
                .Select(f => provider.CreateScope().Pipe(s => s.ServiceProvider.GetRequiredService<DogFilteringController>().GetFilteredItems(f).Do(i => s.Dispose()))).ToList();

            Assert.IsTrue(results.Select(r => r.TotalItems).SequenceEqual(new[] { 2, 2, 20 }));
            Assert.IsTrue(results.Select(r => r.Results.Count).SequenceEqual(new[] { 2, 2, 5 }));
        }
    }
}

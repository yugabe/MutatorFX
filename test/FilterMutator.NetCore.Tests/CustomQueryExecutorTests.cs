using FilterMutator.NetCore.Tests.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MutatorFX.FilterMutator;
using MutatorFX.FilterMutator.EFCore;
using MutatorFX.Coding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FilterMutator.NetCore.Tests;

namespace FilterMutator.NetCore.Tests
{
    [TestClass]
    public partial class CustomQueryExecutorTests
    {
        public class CustomQueryExecutor : QueryExecutorBase<Dog, DogDto, DogFilter, DogSort>
        {
            public CustomQueryExecutor(ISourceAccessor<Dog> source, IPager<DogDto> pager, ISorter<Dog, DogSort> sorter)
            {
                SourceAccessor = source;
                Pager = pager;
                Sorter = sorter;
            }
            public override IQueryable<Dog> Source => SourceAccessor.Source;

            public ISourceAccessor<Dog> SourceAccessor { get; }
            public IPager<DogDto> Pager { get; }
            public ISorter<Dog, DogSort> Sorter { get; }

            static Dictionary<Func<DogFilter, object>, Func<DogFilter, Expression<Func<Dog, bool>>>> filterLookup = new Dictionary<Func<DogFilter, object>, Func<DogFilter, Expression<Func<Dog, bool>>>>()
            {
                [f => f.Id] = f => d => d.Id == f.Id,
                [f => f.MaxId] = f => d => d.Id <= f.MaxId
                // TODO: cleanup
            };

            public override IQueryable<Dog> Filter(IQueryable<Dog> source, DogFilter filter)
                => filterLookup.Where(kv => kv.Key(filter) != default).Aggregate(source, (q, e) => q.Where(e.Value(filter)));

            public override IQueryable<DogDto> Page(IQueryable<DogDto> results, int page, int pageSize)
                => Pager.Page(results, page, pageSize);

            public override IQueryable<Dog> Sort(IQueryable<Dog> filtered, DogSort sort, bool sortDescending)
                => Sorter.Sort(filtered, sort, sortDescending);

            public override IQueryable<DogDto> Transform(IQueryable<Dog> source)
                => source.Select(d => new DogDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    OwnerNames = d.Ownerships.Select(o => o.Owner.Name).ToList(),
                    SiblingDogIds = d.Ownerships.Select(o => o.DogId).Where(i => i != d.Id).ToList()
                });
        }

        [TestMethod]
        public void CustomQueryExecutesSuccessfully()
        {
            var results = new ServiceCollection().AddDbContext<TestDbContext>()
                .AddTransient<DbContext>(s => s.GetRequiredService<TestDbContext>())
                .AddScoped(typeof(DbSetSourceAccessor<>))
                .AddSingleton(typeof(SimplePager<>))
                .AddScoped<CustomQueryExecutor>()
                .BuildServiceProvider()
                .GetRequiredService<CustomQueryExecutor>()
                    .ExecuteQuery(new DogFilter { Id = 4 }, 0, 10, DogSort.Id, true);

        }
    }
}

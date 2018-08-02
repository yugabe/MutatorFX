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

namespace FilterMutator.NetCore.Tests
{
    [TestClass]
    public class CustomQueryExecutorTests
    {
        public class DogDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string OwnerName { get; set; }
            public ICollection<int> SiblingDogIds { get; set; }
        }

        public class DogFilter
        {
            public int? Id { get; set; }
            public int? MinId { get; set; }
            public int? MaxId { get; set; }
            public string OwnerNameLike { get; set; }
        }

        public enum DogSort
        {
            OwnerName
        }

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
                    OwnerName = d.Ownerships.First().Owner.Name,
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
                    .ExecuteQuery(new DogFilter { Id = 4 }, 0, 10, DogSort.OwnerName, true);

        }
    }
}

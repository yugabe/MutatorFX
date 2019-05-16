using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueryMutator.Core;
using QueryMutator.TestDatabase;

namespace QueryMutator.Tests
{
    [TestClass]
    public class DependencyInjectionTests
    {
        [ClassInitialize]
        public static void CreateDatabase(TestContext context)
        {
            DatabaseHelper.CreateDatabase("QMTESTDB");
        }

        [TestMethod]
        public void MapperDependencyInjection()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<ParentEntity, ParentEntityDto>();
            });
            var mapper = config.CreateMapper();

            var serviceProvider = new ServiceCollection()
                .AddSingleton(mapper)
                .BuildServiceProvider();

            var mapperService = serviceProvider.GetService<IMapper>();

            Assert.IsNotNull(mapper);

            var parentMapping = mapperService.GetMapping<ParentEntity, ParentEntityDto>();

            using (var context = new DatabaseContext(DatabaseHelper.Options))
            {
                var parentDtos = context.ParentEntities.Select(parentMapping).ToList();

                Assert.AreEqual(1, parentDtos.Count);

                var result = parentDtos.FirstOrDefault();

                var expected = new ParentEntityDto
                {
                    Id = 1,
                    Name = "Entity",
                    DtoProperty = 0,
                    Ignored = "Ignore this property!",
                    Parameterized = 0,
                    NestedEntity = new NestedEntityDto
                    {
                        Id = 1,
                        Name = "NestedEntity",
                        NestedNestedEntity = new NestedNestedEntityDto
                        {
                            Id = 1,
                            Name = "NestedNestedEntity"
                        }
                    }
                };

                Assert.AreEqual(true, expected.Equals(result));
            }
        }

        [TestMethod]
        public void MappingDependencyInjection()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<ParentEntity, ParentEntityDto>();
            });
            var mapper = config.CreateMapper();
            var parentMapping = mapper.GetMapping<ParentEntity, ParentEntityDto>();

            var serviceProvider = new ServiceCollection()
                .AddSingleton(parentMapping)
                .BuildServiceProvider();

            var parentMappingDI = serviceProvider.GetService<IMapping<ParentEntity, ParentEntityDto>>();

            Assert.IsNotNull(parentMappingDI);

            using (var context = new DatabaseContext(DatabaseHelper.Options))
            {
                var parentDtos = context.ParentEntities.Select(parentMappingDI).ToList();

                Assert.AreEqual(1, parentDtos.Count);

                var result = parentDtos.FirstOrDefault();

                var expected = new ParentEntityDto
                {
                    Id = 1,
                    Name = "Entity",
                    DtoProperty = 0,
                    Ignored = "Ignore this property!",
                    Parameterized = 0,
                    NestedEntity = new NestedEntityDto
                    {
                        Id = 1,
                        Name = "NestedEntity",
                        NestedNestedEntity = new NestedNestedEntityDto
                        {
                            Id = 1,
                            Name = "NestedNestedEntity"
                        }
                    }
                };

                Assert.AreEqual(true, expected.Equals(result));
            }
        }

        [TestMethod]
        public void UseQueryMutator()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<ParentEntity, ParentEntityDto>();
            });

            var serviceProvider = new ServiceCollection()
                .UseQueryMutator(config, true)
                .BuildServiceProvider();

            var mapper = serviceProvider.GetService<IMapper>();

            Assert.IsNotNull(mapper);

            var parentMapping = serviceProvider.GetService<IMapping<ParentEntity, ParentEntityDto>>();

            Assert.IsNotNull(parentMapping);

            using (var context = new DatabaseContext(DatabaseHelper.Options))
            {
                var parentDtos = context.ParentEntities.Select(parentMapping).ToList();

                Assert.AreEqual(1, parentDtos.Count);

                var result = parentDtos.FirstOrDefault();

                var expected = new ParentEntityDto
                {
                    Id = 1,
                    Name = "Entity",
                    DtoProperty = 0,
                    Ignored = "Ignore this property!",
                    Parameterized = 0,
                    NestedEntity = new NestedEntityDto
                    {
                        Id = 1,
                        Name = "NestedEntity",
                        NestedNestedEntity = new NestedNestedEntityDto
                        {
                            Id = 1,
                            Name = "NestedNestedEntity"
                        }
                    }
                };

                Assert.AreEqual(true, expected.Equals(result));
            }
        }

    }
}

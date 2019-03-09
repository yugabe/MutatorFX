using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueryMutator.Core;

namespace QueryMutator.Tests
{
    [TestClass]
    public class MappingTests
    {
        private static readonly Dog TestDog = new Dog
        {
            Id = 1,
            Name = "Dog1",
            EntityProperty = 5,
            Ignored = "Ignore this property!",
            SmallDogId = 1
        };

        private static readonly SmallDog TestSmallDog = new SmallDog
        {
            Id = 1,
            Name = "SmallDog1"
        };

        private static readonly NullableEntity TestNullableEntity = new NullableEntity
        {
            Id = 0,
            NullableProperty = null,
            NotNullableProperty = 0
        };

        private static readonly Collection TestCollection = new Collection
        {
            Id = 0
        };

        private static readonly CollectionItem TestCollectionItem1 = new CollectionItem
        {
            Id = 0,
            CollectionId = 0,
        };

        private static readonly CollectionItem TestCollectionItem2 = new CollectionItem
        {
            Id = 1,
            CollectionId = 0,
        };

        [TestMethod]
        public void TestBasicMapping()
        {
            var options = BuildDatabase(nameof(TestBasicMapping));
            SeedDatabase(options);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<Dog, DogDto>();
            });
            var mapper = config.CreateMapper();
            var dogMapping = mapper.GetMapping<Dog, DogDto>();

            using (var context = new DatabaseContext(options))
            {
                var dogs = context.Dogs.Select(dogMapping).ToList();

                Assert.AreEqual(1, dogs.Count);

                var result = dogs.FirstOrDefault();

                var expected = new DogDto
                {
                    Id = 1,
                    Name = "Dog1",
                    DtoProperty = 0,
                    Ignored = "Ignore this property!",
                    Parameterized = 0,
                    SmallDog = null
                };

                var equal = CheckEqual(expected, result);

                Assert.AreEqual(true, equal);
            }
        }

        [TestMethod]
        public void TestIgnoreMember()
        {
            var options = BuildDatabase(nameof(TestIgnoreMember));
            SeedDatabase(options);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<Dog, DogDto>(mapping => mapping
                    .IgnoreMember(d => d.Ignored)
                );
            });
            var mapper = config.CreateMapper();
            var dogMapping = mapper.GetMapping<Dog, DogDto>();

            using (var context = new DatabaseContext(options))
            {
                var dogs = context.Dogs.Select(dogMapping).ToList();

                Assert.AreEqual(1, dogs.Count);

                var result = dogs.FirstOrDefault();

                var expected = new DogDto
                {
                    Id = 1,
                    Name = "Dog1",
                    DtoProperty = 0,
                    Ignored = null,
                    Parameterized = 0,
                    SmallDog = null
                };

                var equal = CheckEqual(expected, result);

                Assert.AreEqual(true, equal);
            }
        }

        [TestMethod]
        public void TestExplicitMapping()
        {
            var options = BuildDatabase(nameof(TestExplicitMapping));
            SeedDatabase(options);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<Dog, DogDto>(mapping => mapping
                    .MapMember(d => d.DtoProperty, dd => dd.EntityProperty)
                );
            });
            var mapper = config.CreateMapper();
            var dogMapping = mapper.GetMapping<Dog, DogDto>();

            using (var context = new DatabaseContext(options))
            {
                var dogs = context.Dogs.Select(dogMapping).ToList();

                Assert.AreEqual(1, dogs.Count);

                var result = dogs.FirstOrDefault();

                var expected = new DogDto
                {
                    Id = 1,
                    Name = "Dog1",
                    DtoProperty = 5,
                    Ignored = "Ignore this property!",
                    Parameterized = 0,
                    SmallDog = null
                };

                var equal = CheckEqual(expected, result);

                Assert.AreEqual(true, equal);
            }
        }

        [TestMethod]
        public void TestConstantMapping()
        {
            var options = BuildDatabase(nameof(TestConstantMapping));
            SeedDatabase(options);

            var constant = 15;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<Dog, DogDto>(mapping => mapping
                    .MapMember(d => d.DtoProperty, constant)
                );
            });
            var mapper = config.CreateMapper();
            var dogMapping = mapper.GetMapping<Dog, DogDto>();

            using (var context = new DatabaseContext(options))
            {
                var dogs = context.Dogs.Select(dogMapping).ToList();

                Assert.AreEqual(1, dogs.Count);

                var result = dogs.FirstOrDefault();

                var expected = new DogDto
                {
                    Id = 1,
                    Name = "Dog1",
                    DtoProperty = constant,
                    Ignored = "Ignore this property!",
                    Parameterized = 0,
                    SmallDog = null
                };

                var equal = CheckEqual(expected, result);

                Assert.AreEqual(true, equal);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(QueryMutatorValidationException))]
        public void TestSourceValidation()
        {
            var options = BuildDatabase(nameof(TestSourceValidation));
            SeedDatabase(options);
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<Dog, DogDto>(mapping => mapping
                    .ValidateMapping(ValidationMode.Source)
                );
            });
            var mapper = config.CreateMapper();
            var dogMapping = mapper.GetMapping<Dog, DogDto>();

            using (var context = new DatabaseContext(options))
            {
                var dogs = context.Dogs.Select(dogMapping).ToList();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(QueryMutatorValidationException))]
        public void TestDestinationValidation()
        {
            var options = BuildDatabase(nameof(TestDestinationValidation));
            SeedDatabase(options);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<Dog, DogDto>(mapping => mapping
                    .ValidateMapping(ValidationMode.Destination)
                );
            });
            var mapper = config.CreateMapper();
            var dogMapping = mapper.GetMapping<Dog, DogDto>();

            using (var context = new DatabaseContext(options))
            {
                var dogs = context.Dogs.Select(dogMapping).ToList();
            }
        }

        [TestMethod]
        public void TestChildMapping()
        {
            var options = BuildDatabase(nameof(TestChildMapping));
            SeedDatabase(options);

            var config = new MapperConfiguration(cfg =>
            {
                var smallDogMapping = cfg.CreateMapping<SmallDog, SmallDogDto>();

                cfg.CreateMapping<Dog, DogDto>(mapping => mapping
                    .MapMember(d => d.SmallDog, dd => new SmallDogDto { Id = dd.SmallDog.Id, Name = dd.SmallDog.Name })
                );
            });
            var mapper = config.CreateMapper();
            var dogMapping = mapper.GetMapping<Dog, DogDto>();

            using (var context = new DatabaseContext(options))
            {
                var dogs = context.Dogs.Select(dogMapping).ToList();

                Assert.AreEqual(1, dogs.Count);

                var result = dogs.FirstOrDefault();

                var expected = new DogDto
                {
                    Id = 1,
                    Name = "Dog1",
                    DtoProperty = 0,
                    Ignored = "Ignore this property!",
                    Parameterized = 0,
                    SmallDog = new SmallDogDto { Id = 1, Name = "SmallDog1" }
                };

                var equal = CheckEqual(expected, result);

                Assert.AreEqual(true, equal);
            }
        }

        [TestMethod]
        public void TestMapUsing()
        {
            var options = BuildDatabase(nameof(TestMapUsing));
            SeedDatabase(options);

            var config = new MapperConfiguration(cfg =>
            {
                var smallDogMapping = cfg.CreateMapping<SmallDog, SmallDogDto>();

                cfg.CreateMapping<Dog, DogDto>(mapping => mapping
                    .MapMemberUsing(d => d.SmallDog, smallDogMapping)
                );
            });
            var mapper = config.CreateMapper();
            var dogMapping = mapper.GetMapping<Dog, DogDto>();

            using (var context = new DatabaseContext(options))
            {
                var dogs = context.Dogs.Select(dogMapping).ToList();

                Assert.AreEqual(1, dogs.Count);

                var result = dogs.FirstOrDefault();

                var expected = new DogDto
                {
                    Id = 1,
                    Name = "Dog1",
                    DtoProperty = 0,
                    Ignored = "Ignore this property!",
                    Parameterized = 0,
                    SmallDog = new SmallDogDto { Id = 1, Name = "SmallDog1" }
                };

                var equal = CheckEqual(expected, result);

                Assert.AreEqual(true, equal);
            }
        }

        [TestMethod]
        public void TestMapWithParameter()
        {
            var options = BuildDatabase(nameof(TestMapWithParameter));
            SeedDatabase(options);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<Dog, DogDto, int>(mapping => mapping
                    .MapMemberWithParameter(d => d.Parameterized, p => dd => dd.Id * p)
                    );

                cfg.CreateMapping<Dog, DogDto, DogMapperParamaters>(mapping => mapping
                    .MapMemberWithParameter(d => d.Parameterized, p => dd => dd.Id * p.IntProperty)
                    .MapMemberWithParameter(d => d.Name, p => dd => dd.Name + p.StringProperty)
                    );
            });
            var mapper = config.CreateMapper();
            var dogMappingWithParameter = mapper.GetMapping<Dog, DogDto, int>();
            var dogMappingWithParameters = mapper.GetMapping<Dog, DogDto, DogMapperParamaters>();

            using (var context = new DatabaseContext(options))
            {
                var param = 5;
                var dogs = context.Dogs.Select(dogMappingWithParameter, param).ToList();

                Assert.AreEqual(1, dogs.Count);

                var result = dogs.FirstOrDefault();

                var expected = new DogDto
                {
                    Id = 1,
                    Name = "Dog1",
                    DtoProperty = 0,
                    Ignored = "Ignore this property!",
                    Parameterized = 1 * param,
                    SmallDog = null
                };

                var equal = CheckEqual(expected, result);

                Assert.AreEqual(true, equal);

                var @params = new DogMapperParamaters
                {
                    IntProperty = 10,
                    StringProperty = "_suffix"
                };
                dogs = context.Dogs.Select(dogMappingWithParameters, @params).ToList();

                Assert.AreEqual(1, dogs.Count);

                result = dogs.FirstOrDefault();

                expected = new DogDto
                {
                    Id = 1,
                    Name = "Dog1" + @params.StringProperty,
                    DtoProperty = 0,
                    Ignored = "Ignore this property!",
                    Parameterized = 1 * @params.IntProperty,
                    SmallDog = null
                };

                equal = CheckEqual(expected, result);

                Assert.AreEqual(true, equal);
            }
        }

        [TestMethod]
        public void TestJoin()
        {
            var options = BuildDatabase(nameof(TestJoin));
            SeedDatabase(options);

            var config = new MapperConfiguration(cfg =>
            {
                var smallDogMapping = cfg.CreateMapping<SmallDog, SmallDogDto>();

                cfg.CreateMapping<Dog, DogDto>(mapping => mapping
                    .MapMemberUsing(d => d.SmallDog, smallDogMapping)
                );
            });
            var mapper = config.CreateMapper();
            var dogMapping = mapper.GetMapping<Dog, DogDto>();

            using (var context = new DatabaseContext(options))
            {
                var joined = context.Dogs
                    .Join(context.SmallDogs,
                        d => d.SmallDogId,
                        s => s.Id,
                        (d, s) => new Dog
                        {
                            Id = d.Id,
                            Name = d.Name,
                            EntityProperty = d.EntityProperty,
                            Ignored = d.Ignored,
                            SmallDog = new SmallDog
                            {
                                Id = s.Id,
                                Name = s.Name
                            }
                        })
                    .Select(dogMapping).ToList();
                
                Assert.AreEqual(1, joined.Count);

                var result = joined.FirstOrDefault();

                var expected = new DogDto
                {
                    Id = 1,
                    Name = "Dog1",
                    DtoProperty = 0,
                    Ignored = "Ignore this property!",
                    Parameterized = 0,
                    SmallDog = new SmallDogDto { Id = 1, Name = "SmallDog1" }
                };

                var equal = CheckEqual(expected, result);

                Assert.AreEqual(true, equal);
            }
        }

        [TestMethod]
        public void TestAnonymousType()
        {
            var options = BuildDatabase(nameof(TestAnonymousType));
            SeedDatabase(options);

            var config = new MapperConfiguration(cfg =>
            {
                var smallDogMapping = cfg.CreateMapping<SmallDog, SmallDogDto>();

                cfg.CreateMapping<Dog, DogDto>(mapping => mapping
                    .MapMemberUsing(d => d.SmallDog, smallDogMapping)
                );
            });
            var mapper = config.CreateMapper();
            var dogMapping = mapper.GetMapping<Dog, DogDto>();

            using (var context = new DatabaseContext(options))
            {
                var joined = context.Dogs
                    .Select(d => new
                    {
                        d.Id,
                        d.Name,
                        d.EntityProperty,
                        d.Ignored,
                        SmallDog = new
                        {
                            d.SmallDog.Id,
                            d.SmallDog.Name
                        }
                    })
                    .Select(dogMapping).ToList();

                Assert.AreEqual(1, joined.Count);

                var result = joined.FirstOrDefault();

                var expected = new DogDto
                {
                    Id = 1,
                    Name = "Dog1",
                    DtoProperty = 0,
                    Ignored = "Ignore this property!",
                    Parameterized = 0,
                    SmallDog = new SmallDogDto { Id = 1, Name = "SmallDog1" }
                };

                var equal = CheckEqual(expected, result);

                Assert.AreEqual(true, equal);
            }
        }

        [TestMethod]
        public void TestNullableMapping()
        {
            var options = BuildDatabase(nameof(TestNullableMapping));
            SeedDatabase(options);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<NullableEntity, NullableEntityDto>(mapping => mapping
                    .MapMember(d => d.NullableProperty, dd => dd.NotNullableProperty)
                    .MapMember(d => d.NullableProperty2, dd => dd.NullableProperty)
                    .MapMember(d => d.NotNullableProperty, dd => dd.NullableProperty)
                );
            });
            var mapper = config.CreateMapper();
            var nullableMapping = mapper.GetMapping<NullableEntity, NullableEntityDto>();

            using (var context = new DatabaseContext(options))
            {
                var nullableDtos = context.NullableEntities.Select(nullableMapping).ToList();

                Assert.AreEqual(1, nullableDtos.Count);

                var result = nullableDtos.FirstOrDefault();

                var expected = new NullableEntityDto
                {
                    Id = 0,
                    NullableProperty = 0,
                    NullableProperty2 = null,
                    NotNullableProperty = 0
                };

                var equal = CheckEqual(expected, result);

                Assert.AreEqual(true, equal);
            }
        }

        [TestMethod]
        public void TestCollectionMapping()
        {
            var options = BuildDatabase(nameof(TestCollectionMapping));
            SeedDatabase(options);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<CollectionItem, CollectionItemDto>();

                cfg.CreateMapping<Collection, CollectionDto>(mapping => mapping
                    .MapMember(d => d.CollectionItems, dd => dd.CollectionItems)
                );
            });
            var mapper = config.CreateMapper();
            var collectionMapping = mapper.GetMapping<Collection, CollectionDto>();

            using (var context = new DatabaseContext(options))
            {
                var collections = context.Dogs.Select(collectionMapping).ToList();

                Assert.AreEqual(1, collections.Count);

                var result = collections.FirstOrDefault();

                var expected = new CollectionDto
                {
                    Id = 0,
                    CollectionItems = new List<CollectionItemDto>
                    {
                        new CollectionItemDto { Id = 0 },
                        new CollectionItemDto { Id = 1 },
                    }
                };

                var equal = CheckEqual(expected, result);

                Assert.AreEqual(true, equal);
            }
        }

        #region Helper methods

        private DbContextOptions<DatabaseContext> BuildDatabase(string databaseName)
        {
            return new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
        }

        private void SeedDatabase(DbContextOptions<DatabaseContext> options)
        {
            using (var context = new DatabaseContext(options))
            {
                context.SmallDogs.Add(TestSmallDog);
                context.Dogs.Add(TestDog);
                context.NullableEntities.Add(TestNullableEntity);
                context.Collections.Add(TestCollection);
                context.CollectionItems.Add(TestCollectionItem1);
                context.CollectionItems.Add(TestCollectionItem2);
                context.SaveChanges();
            }
        }
        
        private bool CheckEqual(DogDto expected, DogDto actual)
        {
            if (expected.Id != actual.Id || expected.Name != actual.Name || expected.DtoProperty != actual.DtoProperty
                || expected.Ignored != actual.Ignored || expected.Parameterized != actual.Parameterized)
            {
                return false;
            }

            if ((expected.SmallDog == null && actual.SmallDog != null) || (expected.SmallDog != null && actual.SmallDog == null))
            {
                return false;
            }

            if (expected.SmallDog != null && actual.SmallDog != null)
            {
                return CheckEqual(expected.SmallDog, actual.SmallDog);
            }

            return true;
        }

        private bool CheckEqual(SmallDogDto expected, SmallDogDto actual)
        {
            if (expected.Id != actual.Id || expected.Name != actual.Name)
            {
                return false;
            }

            return true;
        }

        private bool CheckEqual(NullableEntityDto expected, NullableEntityDto actual)
        {
            if (expected.Id != actual.Id || expected.NotNullableProperty != actual.NotNullableProperty
                || expected.NullableProperty != actual.NullableProperty || expected.NullableProperty2 != actual.NullableProperty2)
            {
                return false;
            }

            return true;
        }

        private bool CheckEqual(CollectionDto expected, CollectionDto actual)
        {
            if (expected.Id != actual.Id)
            {
                return false;
            }
            if (expected.CollectionItems.Count != actual.CollectionItems.Count)
            {
                return false;
            }
            for(var i = 0; i < expected.CollectionItems.Count; i++)
            {
                if(!CheckEqual(expected.CollectionItems[i], actual.CollectionItems[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckEqual(CollectionItemDto expected, CollectionItemDto actual)
        {
            if (expected.Id != actual.Id)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueryMutator.Core;

namespace QueryMutator.Tests
{
    [TestClass]
    public class MappingTests
    {
        [TestMethod]
        public void TestBasicMapping()
        {
            var options = BuildDatabase(nameof(TestBasicMapping));

            // TODO test collection default mapping?
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
                    SmallDog = new SmallDogDto
                    {
                        Id = 1,
                        Name = "SmallDog1",
                        SmallSmallDog = new SmallSmallDogDto
                        {
                            Id = 1,
                            Name = "SmallSmallDog1"
                        }
                    }
                };

                Assert.AreEqual(true, expected.Equals(result));
            }
        }

        [TestMethod]
        public void TestIgnoreMember()
        {
            var options = BuildDatabase(nameof(TestIgnoreMember));

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
                    SmallDog = new SmallDogDto
                    {
                        Id = 1,
                        Name = "SmallDog1",
                        SmallSmallDog = new SmallSmallDogDto
                        {
                            Id = 1,
                            Name = "SmallSmallDog1"
                        }
                    }
                };

                Assert.AreEqual(true, expected.Equals(result));
            }
        }

        [TestMethod]
        public void TestExplicitMapping()
        {
            var options = BuildDatabase(nameof(TestExplicitMapping));

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
                    SmallDog = new SmallDogDto
                    {
                        Id = 1,
                        Name = "SmallDog1",
                        SmallSmallDog = new SmallSmallDogDto
                        {
                            Id = 1,
                            Name = "SmallSmallDog1"
                        }
                    }
                };
                
                Assert.AreEqual(true, expected.Equals(result));
            }
        }

        [TestMethod]
        public void TestConstantMapping()
        {
            var options = BuildDatabase(nameof(TestConstantMapping));

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
                    SmallDog = new SmallDogDto
                    {
                        Id = 1,
                        Name = "SmallDog1",
                        SmallSmallDog = new SmallSmallDogDto
                        {
                            Id = 1,
                            Name = "SmallSmallDog1"
                        }
                    }
                };
                
                Assert.AreEqual(true, expected.Equals(result));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(QueryMutatorValidationException))]
        public void TestSourceValidation()
        {
            var options = BuildDatabase(nameof(TestSourceValidation));
            
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

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<Dog, DogDto>(mapping => mapping
                    .MapMember(d => d.SmallDog, dd => new SmallDogDto { Id = dd.SmallDog.Id })
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
                    SmallDog = new SmallDogDto { Id = 1, Name = null }
                };
                
                Assert.AreEqual(true, expected.Equals(result));
            }

            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<SmallDog, SmallDogDto>(mapping => mapping
                    .MapMember(d => d.SmallSmallDog, dd => new SmallSmallDogDto { Id = dd.SmallSmallDog.Id })
                );

                cfg.CreateMapping<Dog, DogDto>();
            });
            mapper = config.CreateMapper();
            dogMapping = mapper.GetMapping<Dog, DogDto>();

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
                    SmallDog = new SmallDogDto
                    {
                        Id = 1,
                        Name = "SmallDog1",
                        SmallSmallDog = new SmallSmallDogDto
                        {
                            Id = 1,
                            Name = null
                        }
                    }
                };

                Assert.AreEqual(true, expected.Equals(result));
            }
        }

        [TestMethod]
        public void TestMapUsing()
        {
            var options = BuildDatabase(nameof(TestMapUsing));

            // TODO add some property mapping that actually confirms that its different
            // from the default mapping
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<SmallSmallDog, SmallSmallDogDto>();

                cfg.CreateMapping<SmallDog, SmallDogDto>();

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
                    SmallDog = new SmallDogDto
                    {
                        Id = 1,
                        Name = "SmallDog1",
                        SmallSmallDog = new SmallSmallDogDto
                        {
                            Id = 1,
                            Name = "SmallSmallDog1"
                        }
                    }
                };
                
                Assert.AreEqual(true, expected.Equals(result));
            }
        }

        [TestMethod]
        public void TestMapWithParameter()
        {
            var options = BuildDatabase(nameof(TestMapWithParameter));

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
                    SmallDog = new SmallDogDto
                    {
                        Id = 1,
                        Name = "SmallDog1",
                        SmallSmallDog = new SmallSmallDogDto
                        {
                            Id = 1,
                            Name = "SmallSmallDog1"
                        }
                    }
                };
                
                Assert.AreEqual(true, expected.Equals(result));

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
                    SmallDog = new SmallDogDto
                    {
                        Id = 1,
                        Name = "SmallDog1",
                        SmallSmallDog = new SmallSmallDogDto
                        {
                            Id = 1,
                            Name = "SmallSmallDog1"
                        }
                    }
                };
                
                Assert.AreEqual(true, expected.Equals(result));
            }
        }

        [TestMethod]
        public void TestJoin()
        {
            var options = BuildDatabase(nameof(TestJoin));

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<SmallDog, SmallDogDto>();
                cfg.CreateMapping<Dog, DogDto>();
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
                    SmallDog = new SmallDogDto
                    {
                        Id = 1,
                        Name = "SmallDog1",
                        SmallSmallDog = new SmallSmallDogDto
                        {
                            Id = 1,
                            Name = "SmallSmallDog1"
                        }
                    }
                };
                
                Assert.AreEqual(true, expected.Equals(result));
            }
        }

        [TestMethod]
        public void TestAnonymousType()
        {
            var options = BuildDatabase(nameof(TestAnonymousType));

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<SmallDog, SmallDogDto>();
                cfg.CreateMapping<Dog, DogDto>();
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
                    SmallDog = new SmallDogDto
                    {
                        Id = 1,
                        Name = "SmallDog1",
                        SmallSmallDog = new SmallSmallDogDto
                        {
                            Id = 1,
                            Name = "SmallSmallDog1"
                        }
                    }
                };
                
                Assert.AreEqual(true, expected.Equals(result));
            }
        }

        [TestMethod]
        public void TestNullableMapping()
        {
            var options = BuildDatabase(nameof(TestNullableMapping));

            var constant = 15;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<NullableEntity, NullableEntityDto>(mapping => mapping
                    .MapMember(d => d.NullableProperty, dd => dd.NotNullableProperty)
                    .MapMember(d => d.NullableProperty2, dd => dd.NullableProperty)
                    .MapMember(d => d.NotNullableProperty, dd => dd.NullableProperty)
                    .MapMember(d => d.NotNullableProperty2, dd => dd.NullablePropertyWithValue)
                    .MapMember(d => d.NullableProperty3, constant)
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
                    Id = 1,
                    NullableProperty = 10,
                    NullableProperty2 = null,
                    NullableProperty3 = constant,
                    NotNullableProperty = 0,
                    NotNullableProperty2 = 20
                };
                
                Assert.AreEqual(true, expected.Equals(result));
            }
        }

        [TestMethod]
        public void TestCollectionMapping()
        {
            var options = BuildDatabase(nameof(TestCollectionMapping));

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<CollectionItem, CollectionItemDto>();

                cfg.CreateMapping<Collection, CollectionDto>(mapping => mapping
                    .MapMemberList(d => d.CollectionItems, dd => dd.CollectionItems)
                    .MapMemberList(d => d.CollectionItemDtos, dd => dd.CollectionItems)
                );
            });
            var mapper = config.CreateMapper();
            var collectionMapping = mapper.GetMapping<Collection, CollectionDto>();
            
            using (var context = new DatabaseContext(options))
            {
                var collections = context.Collections.Select(collectionMapping).ToList();

                Assert.AreEqual(1, collections.Count);

                var result = collections.FirstOrDefault();

                var expected = new CollectionDto
                {
                    Id = 1,
                    CollectionItemDtos = new List<CollectionItemDto>
                    {
                        new CollectionItemDto { Id = 0 },
                        new CollectionItemDto { Id = 1 },
                    },
                    CollectionItems = new List<CollectionItem>
                    {
                        new CollectionItem { Id = 0 },
                        new CollectionItem { Id = 1 },
                    }
                };

                Assert.AreEqual(true, expected.Equals(result));
            }
        }

        private DbContextOptions<DatabaseContext> BuildDatabase(string databaseName)
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;

            using (var context = new DatabaseContext(options))
            {
                context.Database.EnsureCreated(); // This call is necessary for the data seeding to work
            }

            return options;
        }
    }
}

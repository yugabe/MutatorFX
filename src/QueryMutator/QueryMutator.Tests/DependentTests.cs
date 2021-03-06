﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueryMutator.Core;
using QueryMutator.TestDatabase;

namespace QueryMutator.Tests
{
    [TestClass]
    public class DependentTests
    {
        [ClassInitialize]
        public static void CreateDatabase(TestContext context)
        {
            DatabaseHelper.CreateDatabase("QMTESTDB");
        }

        [TestMethod]
        public void DependentMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<ParentEntity, ParentEntityDto>();
            });
            var mapper = config.CreateMapper();
            var parentMapping = mapper.GetMapping<ParentEntity, ParentEntityDto>();

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
        public void DependentNestedMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<NestedEntity, NestedEntityDto>(mapping => mapping
                    .MapMember(d => d.NestedNestedEntity, dd => new NestedNestedEntityDto { Id = dd.NestedNestedEntity.Id })
                );

                cfg.CreateMapping<ParentEntity, ParentEntityDto>();
            });
            var mapper = config.CreateMapper();
            var parentMapping = mapper.GetMapping<ParentEntity, ParentEntityDto>();

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
                        Name ="NestedEntity",
                        NestedNestedEntity = new NestedNestedEntityDto
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
        public void DependentNullableMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<NullableParentEntity, NullableParentEntityDto>();
            });
            var mapper = config.CreateMapper();
            var nullableMapping = mapper.GetMapping<NullableParentEntity, NullableParentEntityDto>();

            using (var context = new DatabaseContext(DatabaseHelper.Options))
            {
                var nullableDtos = context.NullableParentEntities.Select(nullableMapping).ToList();

                Assert.AreEqual(1, nullableDtos.Count);

                var result = nullableDtos.FirstOrDefault();

                var expected = new NullableParentEntityDto
                {
                    Id = 1,
                    NestedNullableEntity = new NestedNullableEntityDto
                    {
                        Id = 1,
                        NotNullableToNullable = 10,
                        NullableToNullable = null,
                        NullableToNotNullable = 0,
                        NullableWithValueToNotNullable = 20
                    }
                };

                Assert.AreEqual(true, expected.Equals(result));
            }
        }

        [TestMethod]
        public void DependentCollectionMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<CollectionParent, CollectionParentDto>();

                cfg.CreateMapping<CollectionParent, OtherCollectionParentDto>();
            });
            var mapper = config.CreateMapper();
            var collectionMapping = mapper.GetMapping<CollectionParent, CollectionParentDto>();
            var otherCollectionMapping = mapper.GetMapping<CollectionParent, OtherCollectionParentDto>();

            using (var context = new DatabaseContext(DatabaseHelper.Options))
            {
                var collectionParents = context.CollectionParents.Select(collectionMapping).ToList();

                Assert.AreEqual(1, collectionParents.Count);

                var result = collectionParents.FirstOrDefault();

                var expected = new CollectionParentDto
                {
                    Id = 1,
                    Collections = new List<Collection>
                    {
                        new Collection { Id = 1, CollectionParentId = 1 },
                        new Collection { Id = 2, CollectionParentId = 1 },
                    }
                };

                Assert.AreEqual(true, expected.Equals(result));
            }

            using (var context = new DatabaseContext(DatabaseHelper.Options))
            {
                var collectionParents = context.CollectionParents.Select(otherCollectionMapping).ToList();

                Assert.AreEqual(1, collectionParents.Count);

                var result = collectionParents.FirstOrDefault();

                var expected = new OtherCollectionParentDto
                {
                    Id = 1,
                    Collections = new List<CollectionDto>
                    {
                        new CollectionDto { Id = 1 },
                        new CollectionDto { Id = 2 },
                    }
                };

                Assert.AreEqual(true, expected.Equals(result));
            }
        }

        [TestMethod]
        public void DependentNestedCollectionMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMapping<DependentNestedCollectionParent, DependentNestedCollectionParentDto>();

                cfg.CreateMapping<DependentNestedCollectionParent, OtherDependentNestedCollectionParentDto>();
            });
            var mapper = config.CreateMapper();
            var collectionMapping = mapper.GetMapping<DependentNestedCollectionParent, DependentNestedCollectionParentDto>();
            var otherCollectionMapping = mapper.GetMapping<DependentNestedCollectionParent, OtherDependentNestedCollectionParentDto>();

            using (var context = new DatabaseContext(DatabaseHelper.Options))
            {
                var collectionParents = context.DependentNestedCollectionParents.Select(collectionMapping).ToList();

                Assert.AreEqual(1, collectionParents.Count);

                var result = collectionParents.FirstOrDefault();

                var expected = new DependentNestedCollectionParentDto
                {
                    Id = 1,
                    DependentNestedCollection = new DependentNestedCollectionDto
                    {
                        Id = 1,
                        DependentNestedCollectionItems = new List<DependentNestedCollectionItemDto>
                        {
                            new DependentNestedCollectionItemDto { Id = 1 },
                            new DependentNestedCollectionItemDto { Id = 2 },
                        }
                    }
                };

                Assert.AreEqual(true, expected.Equals(result));
            }

            using (var context = new DatabaseContext(DatabaseHelper.Options))
            {
                var collectionParents = context.DependentNestedCollectionParents.Select(otherCollectionMapping).ToList();

                Assert.AreEqual(1, collectionParents.Count);

                var result = collectionParents.FirstOrDefault();

                var expected = new OtherDependentNestedCollectionParentDto
                {
                    Id = 1,
                    DependentNestedCollection = new OtherDependentNestedCollectionDto
                    {
                        Id = 1,
                        DependentNestedCollectionItems = new List<DependentNestedCollectionItem>
                        {
                            new DependentNestedCollectionItem { Id = 1, DependentNestedCollectionId = 1 },
                            new DependentNestedCollectionItem { Id = 2, DependentNestedCollectionId = 1 },
                        }
                    }
                };

                Assert.AreEqual(true, expected.Equals(result));
            }
        }

        [TestMethod]
        public void DependentAttributeMapping()
        {
            var config = new MapperConfiguration(cfg => 
            {
                cfg.UseAttributeMapping(typeof(DatabaseContext).Assembly);
            });
            var mapper = config.CreateMapper();
            var attributeMapping = mapper.GetMapping<AttributeParent, AttributeParentDto>();

            using (var context = new DatabaseContext(DatabaseHelper.Options))
            {
                var attributeDtos = context.AttributeParents.Select(attributeMapping).ToList();

                Assert.AreEqual(1, attributeDtos.Count);

                var result = attributeDtos.FirstOrDefault();

                var expected = new AttributeParentDto
                {
                    Id = 1,
                    AttributeChild = new AttributeChildDto
                    {
                        Id = 1
                    }
                };

                Assert.AreEqual(true, expected.Equals(result));
            }
        }
    }
}

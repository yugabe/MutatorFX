using System;
using System.Collections.Generic;
using System.Text;

namespace QueryMutator.Tests
{
    public class Dog
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int EntityProperty { get; set; }

        public string Ignored { get; set; }

        public int? SmallDogId { get; set; }
        public SmallDog SmallDog { get; set; }
    }

    public class SmallDog
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? SmallSmallDogId { get; set; }
        public SmallSmallDog SmallSmallDog { get; set; }
    }

    public class SmallSmallDog
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class NullableEntity
    {
        public int Id { get; set; }

        public int? NullableProperty { get; set; }

        public int? NullablePropertyWithValue { get; set; }

        public int NotNullableProperty { get; set; }
    }

    public class NullableParent
    {
        public int Id { get; set; }

        public int NullableChildId { get; set; }
        public NullableChild NullableChild { get; set; }
    }

    public class NullableChild
    {
        public int Id { get; set; }

        public int NotNullableToNullable { get; set; }

        public int? NullableToNullable { get; set; }

        public int? NullableToNotNullable { get; set; }

        public int? NullableWithValueToNotNullable { get; set; }
    }

    public class CollectionParent
    {
        public int Id { get; set; }

        public ICollection<Collection> Collections { get; set; }
    }

    public class Collection
    {
        public int Id { get; set; }

        public ICollection<CollectionItem> CollectionItems { get; set; }
        
        public int CollectionParentId { get; set; }
        public CollectionParent CollectionParent { get; set; }
    }

    public class CollectionItem
    {
        public int Id { get; set; }

        public int CollectionId { get; set; }
        public Collection Collection { get; set; }
    }

    public class DependentCollectionParent
    {
        public int Id { get; set; }

        public int DependentCollectionId { get; set; }
        public DependentCollection DependentCollection { get; set; }
    }

    public class DependentCollection
    {
        public int Id { get; set; }

        public ICollection<DependentCollectionItem> DependentCollectionItems { get; set; }
    }

    public class DependentCollectionItem
    {
        public int Id { get; set; }

        public int DependentCollectionId { get; set; }
        public DependentCollection DependentCollection { get; set; }
    }
}

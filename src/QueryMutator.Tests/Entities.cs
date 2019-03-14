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

    public class Collection
    {
        public int Id { get; set; }

        public ICollection<CollectionItem> CollectionItems { get; set; }
    }

    public class CollectionItem
    {
        public int Id { get; set; }

        public int CollectionId { get; set; }
        public Collection Collection { get; set; }
    }
}

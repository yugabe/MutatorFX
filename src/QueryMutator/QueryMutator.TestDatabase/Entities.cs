using System.Collections.Generic;

namespace QueryMutator.TestDatabase
{
    public class ParentEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int EntityProperty { get; set; }

        public string Ignored { get; set; }

        public int? NestedEntityId { get; set; }
        public NestedEntity NestedEntity { get; set; }
    }

    public class NestedEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? NestedNestedEntityId { get; set; }
        public NestedNestedEntity NestedNestedEntity { get; set; }
    }

    public class NestedNestedEntity
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

    public class NullableParentEntity
    {
        public int Id { get; set; }

        public int NestedNullableEntityId { get; set; }
        public NestedNullableEntity NestedNullableEntity { get; set; }
    }

    public class NestedNullableEntity
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

    public class DependentNestedCollectionParent
    {
        public int Id { get; set; }

        public int DependentNestedCollectionId { get; set; }
        public DependentNestedCollection DependentNestedCollection { get; set; }
    }

    public class DependentNestedCollection
    {
        public int Id { get; set; }

        public ICollection<DependentNestedCollectionItem> DependentNestedCollectionItems { get; set; }
    }

    public class DependentNestedCollectionItem
    {
        public int Id { get; set; }

        public int DependentNestedCollectionId { get; set; }
        public DependentNestedCollection DependentNestedCollection { get; set; }
    }

    public class AttributeEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class FlattenedParent
    {
        public int Id { get; set; }

        public int ChildId { get; set; }
        public FlattenedChild Child { get; set; }
    }

    public class FlattenedChild
    {
        public int Id { get; set; }
        
        public int ChildId { get; set; }
        public FlattenedChildChild Child { get; set; }
    }

    public class FlattenedChildChild
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

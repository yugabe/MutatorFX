using System;
using System.Collections.Generic;
using QueryMutator.Core;

namespace QueryMutator.TestDatabase
{
    public class ParentEntityDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DtoProperty { get; set; }

        public string Ignored { get; set; }

        public int Parameterized { get; set; }

        public NestedEntityDto NestedEntity { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ParentEntityDto d))
            {
                return false;
            }

            if (Id != d.Id || Name != d.Name || DtoProperty != d.DtoProperty || Ignored != d.Ignored || Parameterized != d.Parameterized)
            {
                return false;
            }

            if ((NestedEntity == null && d.NestedEntity != null) || (NestedEntity != null && d.NestedEntity == null))
            {
                return false;
            }

            if (NestedEntity != null && d.NestedEntity != null)
            {
                return NestedEntity.Equals(d.NestedEntity);
            }

            return true;
        }

        public override int GetHashCode() => HashCode.Combine(Id, Name, DtoProperty, Ignored, Parameterized, NestedEntity.GetHashCode());
    }

    public class ParentEntityParamaters
    {
        public int IntProperty { get; set; }

        public string StringProperty { get; set; }
    }

    public class NestedEntityDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public NestedNestedEntityDto NestedNestedEntity { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is NestedEntityDto d))
            {
                return false;
            }

            if(Id != d.Id || Name != d.Name)
            {
                return false;
            }

            if (NestedNestedEntity != null && d.NestedNestedEntity != null)
            {
                return NestedNestedEntity.Equals(d.NestedNestedEntity);
            }

            return true;
        }

        public override int GetHashCode() => HashCode.Combine(Id, Name);
    }

    public class NestedNestedEntityDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is NestedNestedEntityDto d))
            {
                return false;
            }

            return (Id == d.Id) && (Name == d.Name);
        }

        public override int GetHashCode() => HashCode.Combine(Id, Name);
    }

    public class NullableEntityDto
    {
        public int Id { get; set; }

        public int? NullableProperty { get; set; }

        public int? NullableProperty2 { get; set; }

        public int? NullableProperty3 { get; set; }

        public int NotNullableProperty { get; set; }

        public int NotNullableProperty2 { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is NullableEntityDto n))
            {
                return false;
            }

            return (Id == n.Id) && (NullableProperty == n.NullableProperty) && (NullableProperty2 == n.NullableProperty2)
                  && (NullableProperty3 == n.NullableProperty3) && (NotNullableProperty == n.NotNullableProperty)
                  && (NotNullableProperty2 == n.NotNullableProperty2);
        }

        public override int GetHashCode() => HashCode.Combine(Id, NullableProperty, NullableProperty2, NullableProperty3, NotNullableProperty, NotNullableProperty2);
    }

    public class NullableParentEntityDto
    {
        public int Id { get; set; }

        public NestedNullableEntityDto NestedNullableEntity { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is NullableParentEntityDto n))
            {
                return false;
            }

            return Id == n.Id && NestedNullableEntity.Equals(n.NestedNullableEntity);
        }

        public override int GetHashCode() => HashCode.Combine(Id, NestedNullableEntity.GetHashCode());
    }

    public class NestedNullableEntityDto
    {
        public int Id { get; set; }

        public int? NotNullableToNullable { get; set; }

        public int? NullableToNullable { get; set; }

        public int NullableToNotNullable { get; set; }

        public int NullableWithValueToNotNullable { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is NestedNullableEntityDto n))
            {
                return false;
            }

            return (Id == n.Id) && (NotNullableToNullable == n.NotNullableToNullable) && (NullableToNullable == n.NullableToNullable)
                  && (NullableToNotNullable == n.NullableToNotNullable) && (NullableWithValueToNotNullable == n.NullableWithValueToNotNullable);
        }

        public override int GetHashCode() => HashCode.Combine(Id, NotNullableToNullable, NullableToNullable, NullableToNotNullable, NullableWithValueToNotNullable);
    }

    public class CollectionParentDto
    {
        public int Id { get; set; }

        public IList<Collection> Collections { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is CollectionParentDto c))
            {
                return false;
            }

            if ((Id != c.Id) || (Collections.Count != c.Collections.Count))
            {
                return false;
            }

            for (var i = 0; i < Collections.Count; i++)
            {
                var item = Collections[i];
                var other = c.Collections[i];
                if (item.Id != other.Id || item.CollectionParentId != other.CollectionParentId)
                {
                    return false;
                }
            }
            
            return true;
        }

        public override int GetHashCode() => HashCode.Combine(Id, Collections.GetHashCode());
    }

    public class OtherCollectionParentDto
    {
        public int Id { get; set; }

        public IList<CollectionDto> Collections { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is OtherCollectionParentDto c))
            {
                return false;
            }

            if ((Id != c.Id) || (Collections.Count != c.Collections.Count))
            {
                return false;
            }

            for (var i = 0; i < Collections.Count; i++)
            {
                if (Collections[i].Id != c.Collections[i].Id)
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode() => HashCode.Combine(Id, Collections.GetHashCode());
    }

    public class CollectionDto
    {
        public int Id { get; set; }

        public IList<CollectionItemDto> CollectionItemDtos { get; set; }

        public IList<CollectionItem> CollectionItems { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is CollectionDto c))
            {
                return false;
            }

            if ((Id != c.Id) || (CollectionItemDtos.Count != c.CollectionItemDtos.Count))
            {
                return false;
            }

            for (var i = 0; i < CollectionItemDtos.Count; i++)
            {
                if (!CollectionItemDtos[i].Equals(c.CollectionItemDtos[i]))
                {
                    return false;
                }
            }

            if ((Id != c.Id) || (CollectionItems.Count != c.CollectionItems.Count))
            {
                return false;
            }

            for (var i = 0; i < CollectionItems.Count; i++)
            {
                var item = CollectionItems[i];
                var other = c.CollectionItems[i];
                if(item.Id != other.Id || item.CollectionId != other.CollectionId)
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode() => HashCode.Combine(Id, CollectionItemDtos.GetHashCode(), CollectionItems.GetHashCode());
    }

    public class CollectionItemDto
    {
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is CollectionItemDto c))
            {
                return false;
            }

            return Id == c.Id;
        }

        public override int GetHashCode() => HashCode.Combine(Id);
    }

    public class DependentNestedCollectionParentDto
    {
        public int Id { get; set; }

        public DependentNestedCollectionDto DependentNestedCollection { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is DependentNestedCollectionParentDto c))
            {
                return false;
            }

            return Id == c.Id && DependentNestedCollection.Equals(c.DependentNestedCollection);
        }

        public override int GetHashCode() => HashCode.Combine(Id, DependentNestedCollection.GetHashCode());
    }
    
    public class DependentNestedCollectionDto
    {
        public int Id { get; set; }

        public IList<DependentNestedCollectionItemDto> DependentNestedCollectionItems { get; set; }
        
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is DependentNestedCollectionDto c))
            {
                return false;
            }

            if ((Id != c.Id) || (DependentNestedCollectionItems.Count != c.DependentNestedCollectionItems.Count))
            {
                return false;
            }

            for (var i = 0; i < DependentNestedCollectionItems.Count; i++)
            {
                if (!DependentNestedCollectionItems[i].Equals(c.DependentNestedCollectionItems[i]))
                {
                    return false;
                }
            }
            
            return true;
        }

        public override int GetHashCode() => HashCode.Combine(Id, DependentNestedCollectionItems.GetHashCode());
    }

    public class DependentNestedCollectionItemDto
    {
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is DependentNestedCollectionItemDto c))
            {
                return false;
            }

            return Id == c.Id;
        }

        public override int GetHashCode() => HashCode.Combine(Id);
    }

    public class OtherDependentNestedCollectionParentDto
    {
        public int Id { get; set; }

        public OtherDependentNestedCollectionDto DependentNestedCollection { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is OtherDependentNestedCollectionParentDto c))
            {
                return false;
            }

            return Id == c.Id && DependentNestedCollection.Equals(c.DependentNestedCollection);
        }

        public override int GetHashCode() => HashCode.Combine(Id, DependentNestedCollection.GetHashCode());
    }

    public class OtherDependentNestedCollectionDto
    {
        public int Id { get; set; }

        public IList<DependentNestedCollectionItem> DependentNestedCollectionItems { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is OtherDependentNestedCollectionDto c))
            {
                return false;
            }

            if ((Id != c.Id) || (DependentNestedCollectionItems.Count != c.DependentNestedCollectionItems.Count))
            {
                return false;
            }

            for (var i = 0; i < DependentNestedCollectionItems.Count; i++)
            {
                var item = DependentNestedCollectionItems[i];
                var other = c.DependentNestedCollectionItems[i];
                if (item.Id != other.Id || item.DependentNestedCollectionId != other.DependentNestedCollectionId)
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode() => HashCode.Combine(Id, DependentNestedCollectionItems.GetHashCode());
    }

    [MapFrom(typeof(AttributeEntity))]
    public class AttributeEntityDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is AttributeEntityDto d))
            {
                return false;
            }
            
            return Id == d.Id && Name == d.Name;
        }

        public override int GetHashCode() => HashCode.Combine(Id, Name);
    }

    public class FlattenedParentDto
    {
        public int Id { get; set; }

        public string ChildChildName { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is FlattenedParentDto c))
            {
                return false;
            }

            return Id == c.Id && ChildChildName == c.ChildChildName;
        }

        public override int GetHashCode() => HashCode.Combine(Id, ChildChildName);
    }

}

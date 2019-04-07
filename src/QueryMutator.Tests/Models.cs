using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueryMutator.Tests
{
    public class DogDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DtoProperty { get; set; }

        public string Ignored { get; set; }

        public int Parameterized { get; set; }

        public SmallDogDto SmallDog { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is DogDto d))
            {
                return false;
            }

            if (Id != d.Id || Name != d.Name || DtoProperty != d.DtoProperty || Ignored != d.Ignored || Parameterized != d.Parameterized)
            {
                return false;
            }

            if ((SmallDog == null && d.SmallDog != null) || (SmallDog != null && d.SmallDog == null))
            {
                return false;
            }

            if (SmallDog != null && d.SmallDog != null)
            {
                return SmallDog.Equals(d.SmallDog);
            }

            return true;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, DtoProperty, Ignored, Parameterized, SmallDog);
        }
    }

    public class SmallDogDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public SmallSmallDogDto SmallSmallDog { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            
            if (!(obj is SmallDogDto d))
            {
                return false;
            }

            if(Id != d.Id || Name != d.Name)
            {
                return false;
            }

            if (SmallSmallDog != null && d.SmallSmallDog != null)
            {
                return SmallSmallDog.Equals(d.SmallSmallDog);
            }

            return true;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }
    }

    public class SmallSmallDogDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is SmallSmallDogDto d))
            {
                return false;
            }

            return (Id == d.Id) && (Name == d.Name);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }
    }

    public class DogMapperParamaters
    {
        public int IntProperty { get; set; }

        public string StringProperty { get; set; }
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
            if (obj == null)
            {
                return false;
            }
            
            if (!(obj is NullableEntityDto n))
            {
                return false;
            }

            return (Id == n.Id) && (NullableProperty == n.NullableProperty) && (NullableProperty2 == n.NullableProperty2)
                  && (NullableProperty3 == n.NullableProperty3) && (NotNullableProperty == n.NotNullableProperty)
                  && (NotNullableProperty2 == n.NotNullableProperty2);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, NullableProperty, NullableProperty2, NotNullableProperty);
        }
    }

    public class NullableParentDto
    {
        public int Id { get; set; }

        public NullableChildDto NullableChild { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is NullableParentDto n))
            {
                return false;
            }

            return Id == n.Id && NullableChild.Equals(n.NullableChild);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, NullableChild.GetHashCode());
        }
    }

    public class NullableChildDto
    {
        public int Id { get; set; }

        public int? NotNullableToNullable { get; set; }

        public int? NullableToNullable { get; set; }

        public int NullableToNotNullable { get; set; }

        public int NullableWithValueToNotNullable { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is NullableChildDto n))
            {
                return false;
            }

            return (Id == n.Id) && (NotNullableToNullable == n.NotNullableToNullable) && (NullableToNullable == n.NullableToNullable)
                  && (NullableToNotNullable == n.NullableToNotNullable) && (NullableWithValueToNotNullable == n.NullableWithValueToNotNullable);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, NotNullableToNullable, NullableToNullable, NullableToNotNullable, NullableWithValueToNotNullable);
        }
    }

    public class CollectionParentDto
    {
        public int Id { get; set; }

        public IList<Collection> Collections { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is CollectionParentDto c))
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

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Collections);
        }
    }

    public class CollectionParent2Dto
    {
        public int Id { get; set; }

        public IList<CollectionDto> Collections { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is CollectionParent2Dto c))
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

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Collections);
        }
    }

    public class CollectionDto
    {
        public int Id { get; set; }

        public IList<CollectionItemDto> CollectionItemDtos { get; set; }

        public IList<CollectionItem> CollectionItems { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            
            if (!(obj is CollectionDto c))
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

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, CollectionItems, CollectionItemDtos);
        }
    }

    public class CollectionItemDto
    {
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            
            if (!(obj is CollectionItemDto c))
            {
                return false;
            }

            return Id == c.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }

    public class DependentCollectionParentDto
    {
        public int Id { get; set; }

        public DependentCollectionDto DependentCollection { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is DependentCollectionParentDto c))
            {
                return false;
            }

            return Id == c.Id && DependentCollection.Equals(c.DependentCollection);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, DependentCollection.GetHashCode());
        }
    }
    
    public class DependentCollectionDto
    {
        public int Id { get; set; }

        public IList<DependentCollectionItemDto> DependentCollectionItems { get; set; }
        
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is DependentCollectionDto c))
            {
                return false;
            }

            if ((Id != c.Id) || (DependentCollectionItems.Count != c.DependentCollectionItems.Count))
            {
                return false;
            }

            for (var i = 0; i < DependentCollectionItems.Count; i++)
            {
                if (!DependentCollectionItems[i].Equals(c.DependentCollectionItems[i]))
                {
                    return false;
                }
            }
            
            return true;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, DependentCollectionItems);
        }
    }

    public class DependentCollectionItemDto
    {
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is DependentCollectionItemDto c))
            {
                return false;
            }

            return Id == c.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}

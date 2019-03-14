using System;
using System.Collections.Generic;
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

    public class CollectionDto
    {
        public int Id { get; set; }

        public IList<CollectionItemDto> CollectionItems { get; set; }

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

            if((Id != c.Id) || (CollectionItems.Count != c.CollectionItems.Count))
            {
                return false;
            }
            
            for (var i = 0; i < CollectionItems.Count; i++)
            {
                if (CollectionItems[i].Equals(c.CollectionItems[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, CollectionItems);
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
}

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
    }

    public class SmallDogDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
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

        public int NotNullableProperty { get; set; }
    }

    public class CollectionDto
    {
        public int Id { get; set; }

        public IList<CollectionItemDto> CollectionItems { get; set; }
    }

    public class CollectionItemDto
    {
        public int Id { get; set; }
    }
}

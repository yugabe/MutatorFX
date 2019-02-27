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
}

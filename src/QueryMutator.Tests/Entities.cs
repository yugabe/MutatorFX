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
        public virtual SmallDog SmallDog { get; set; }
    }

    public class SmallDog
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

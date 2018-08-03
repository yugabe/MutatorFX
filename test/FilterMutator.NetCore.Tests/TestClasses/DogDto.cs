using System;
using System.Collections.Generic;
using System.Text;

namespace FilterMutator.NetCore.Tests
{
    public class DogDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> OwnerNames { get; set; }
        public ICollection<int> SiblingDogIds { get; set; }
    }
}

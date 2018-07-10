using System.Collections.Generic;

namespace FilterMutator.NetCore.Tests.Data
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<DogOwnership> Ownerships { get; set; }
    }
}
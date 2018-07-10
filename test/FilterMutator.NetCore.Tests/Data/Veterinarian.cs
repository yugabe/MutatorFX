using System.Collections.Generic;

namespace FilterMutator.NetCore.Tests.Data
{
    public class Veterinarian
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<DogOwnership> VettedDogs { get; set; }
    }
}
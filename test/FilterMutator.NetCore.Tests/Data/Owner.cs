using System;
using System.Collections.Generic;
using System.Text;

namespace FilterMutator.NetCore.Tests.Data
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<DogOwnership> OwnedDogs { get; set; }
    }
}

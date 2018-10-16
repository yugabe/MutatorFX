using MutatorFX.QueryMutator.Linq;
using System;
using System.Linq;

namespace MutatorFX.QueryMutator
{
    public class Program
    {
        public int X { get; set; }

        public int Y() => X;
        [STAThread]
        public static void Main()
        {
            var kutyaToDtoMapping = Mapping<Kutya, KutyaDto, int>.Create(mapping => mapping
                .MapMember(k => k.Parameterized, p => k => k.Id * p)
                .MapMatchingPropertyChains()
                .MapMember(k => k.DtoProperty, kk => kk.EntityProperty)
                .IgnoreMember(k => k.Ignored)
                );

            var kutyak = new[] {
                new Kutya
                {
                    Id = 1, Name = "Bodri",
                    EntityProperty = 5,
                    Ignored = "IGNORE!"
                }, new Kutya { },
                new Kutya { Id = 3, Name = "Pimpedli", EntityProperty = 10 } };
            var dtok = kutyak.AsQueryable().Select(kutyaToDtoMapping, 2).ToList();
        }
    }

    public class Kutya
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EntityProperty { get; set; }
        public string Ignored { get; set; }
    }

    public class KutyaDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DtoProperty { get; set; }
        public int Parameterized { get; set; }
        public string Ignored { get; set; }
    }
}

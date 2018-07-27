namespace FilterMutator.NetCore.Tests.Data
{
    public class DogOwnership
    {
        public int Id { get; set; }
        public Dog Dog { get; set; }
        public int DogId { get; set; }
        public Owner Owner { get; set; }
        public int OwnerId { get; set; }
        public Veterinarian Vet { get; set; }
        public int VetId { get; set; }
    }
}
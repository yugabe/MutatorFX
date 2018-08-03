namespace FilterMutator.NetCore.Tests
{
    public class DogFilter
    {
        public int? Id { get; set; }
        public int? MinId { get; set; }
        public int? MaxId { get; set; }
        public string OwnerNameLike { get; set; }
    }
}

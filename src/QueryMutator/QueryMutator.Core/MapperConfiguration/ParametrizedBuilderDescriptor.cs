namespace QueryMutator.Core
{
    internal class ParametrizedBuilderDescriptor
    {
        public IMapping Mapping { get; set; }

        public MappingBuilderBase Builder { get; set; }
    }
}

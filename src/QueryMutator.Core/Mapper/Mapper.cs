using System.Collections.Generic;
using System.Linq;

namespace QueryMutator.Core
{
    public interface IMapper
    {
        IMapping<TSource, TTarget> GetMapping<TSource, TTarget>();

        IMapping<TSource, TTarget, TParam> GetMapping<TSource, TTarget, TParam>();
    }

    internal class Mapper : IMapper
    {
        public List<MappingDescriptor> Mappings { get; set; }

        public IMapping<TSource, TTarget> GetMapping<TSource, TTarget>()
        {
            var mapping = Mappings.FirstOrDefault(m => m.SourceType == typeof(TSource) && m.TargetType == typeof(TTarget) && m.ParameterType == null);
            if(mapping != null)
            {
                return mapping.Mapping as Mapping<TSource, TTarget>;
            }
            else
            {
                throw new MappingNotFoundException("Specified mapping was not found");
            }
        }

        public IMapping<TSource, TTarget, TParam> GetMapping<TSource, TTarget, TParam>()
        {
            var mapping = Mappings.FirstOrDefault(m => m.SourceType == typeof(TSource) && m.TargetType == typeof(TTarget) && m.ParameterType == typeof(TParam));
            if (mapping != null)
            {
                return mapping.Mapping as Mapping<TSource, TTarget, TParam>;
            }
            else
            {
                throw new MappingNotFoundException("Specified mapping was not found");
            }
        }
    }
}

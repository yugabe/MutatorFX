using System.Collections.Generic;

namespace QueryMutator.Core
{
    public interface IMapper
    {
        IMapping<TSource, TTarget> GetMapping<TSource, TTarget>();

        IMapping<TSource, TTarget, TParam> GetMapping<TSource, TTarget, TParam>();
    }

    internal class Mapper : IMapper
    {
        public Dictionary<MappingKey, IMapping> Mappings { get; set; }

        public IMapping<TSource, TTarget> GetMapping<TSource, TTarget>()
        {
            if (Mappings.TryGetValue(new MappingKey(typeof(TSource), typeof(TTarget)), out var mapping))
            {
                return mapping as Mapping<TSource, TTarget>;
            }
            else
            {
                throw new MappingNotFoundException("Specified mapping was not found");
            }
        }

        public IMapping<TSource, TTarget, TParam> GetMapping<TSource, TTarget, TParam>()
        {
            if (Mappings.TryGetValue(new MappingKey(typeof(TSource), typeof(TTarget), typeof(TParam)), out var mapping))
            {
                return mapping as Mapping<TSource, TTarget, TParam>;
            }
            else
            {
                throw new MappingNotFoundException("Specified mapping was not found");
            }
        }
    }
}

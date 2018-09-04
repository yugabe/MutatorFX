using MutatorFX.QueryMutator.MemberMappings;
using MutatorFX.Coding;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Linq.Expressions.Expression;
using System.Linq.Expressions;

namespace MutatorFX.QueryMutator
{
    public class MappingBuilder<TSource, TTarget>
    {
        public MappingBuilder() : this(typeof(TSource).Name.ToLower()) { }
        public MappingBuilder(string sourceParameterName) => SourceParameter = Parameter(typeof(TSource), sourceParameterName);

        public ParameterExpression SourceParameter { get; }
        public ICollection<MemberMapping<TSource, TTarget>> PropertyMappings { get; } = new List<MemberMapping<TSource, TTarget>>();
        public Mapping<TSource, TTarget> Build() => new Mapping<TSource, TTarget>(SourceParameter, PropertyMappings);
        public MappingBuilder<TSource, TTarget> Add(MemberMapping<TSource, TTarget> mapping) => this.Do(m => PropertyMappings.Add(mapping));
    }
}

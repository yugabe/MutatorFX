using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace QueryMutator.Core
{
    public interface IMapping<TSource, TTarget>
    {
        Expression<Func<TSource, TTarget>> Expression { get; }
    }

    internal class Mapping<TSource, TTarget> : IMapping<TSource, TTarget>
    {
        public Expression<Func<TSource, TTarget>> Expression { get; set; }
    }

    public interface IMapping<TSource, TTarget, TParam>
    {
    }

    internal class Mapping<TSource, TTarget, TParam> : IMapping<TSource, TTarget, TParam>
    {
    }
}

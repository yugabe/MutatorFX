using System;
using System.Linq;

namespace MutatorFX.FilterMutator
{
    /// <summary>
    /// A simple source accessor which accepts an accessor function to provide for the <see cref="ISourceAccessor{TSource}"/> interface.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the datasource.</typeparam>
    public class ClosureSourceAccessor<TSource>: ISourceAccessor<TSource>
    {
        /// <summary>
        /// Create a new accessor, which will use the provided function to access the queryable source.
        /// </summary>
        /// <param name="sourceAccessor">The function to use to access the queryable source.</param>
        public ClosureSourceAccessor(Func<IQueryable<TSource>> sourceAccessor) =>
            SourceAccessor = sourceAccessor;

        private Func<IQueryable<TSource>> SourceAccessor { get; }

        /// <summary>
        /// Use the aquired accessor function to access the queryable source.
        /// </summary>
        public IQueryable<TSource> Source => SourceAccessor();
    }
}

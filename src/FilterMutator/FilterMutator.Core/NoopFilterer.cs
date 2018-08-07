using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MutatorFX.FilterMutator
{
    /// <summary>
    /// A simple filterer implementation that returns the input datasource (does not filter). Can be used for mocking and testing or composition.
    /// </summary>
    /// <typeparam name="TSource">The source type to apply no filtering to.</typeparam>
    /// <typeparam name="TFilter">The filter type, not used.</typeparam>
    public class NoopFilterer<TSource, TFilter> : IFilterer<TSource, TFilter>
    {
        /// <summary>
        /// Returns the input <paramref name="source"/> object.
        /// </summary>
        /// <param name="source">This object is returned.</param>
        /// <param name="filter">This object is ignored.</param>
        /// <returns>The <paramref name="source"/> object.</returns>
        public IQueryable<TSource> Filter(IQueryable<TSource> source, TFilter filter) => source;
    }
}

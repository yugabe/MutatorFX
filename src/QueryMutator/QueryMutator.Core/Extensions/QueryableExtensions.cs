using System.Linq;

namespace QueryMutator.Core
{
    /// <summary>
    /// Globally usable extensions for custom projections.
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// Projects each element of a sequence into a new form using the supplied <paramref name="mapping"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the given object <paramref name="source"/>.</typeparam>
        /// <typeparam name="TTarget">The type of the destination object into which the source is projected.</typeparam>
        /// <param name="source">The object to execute the given action on.</param>
        /// <param name="mapping">The mapping to use for the projection.</param>
        /// <returns></returns>
        public static IQueryable<TTarget> Select<TSource, TTarget>(this IQueryable<TSource> source, IMapping<TSource, TTarget> mapping)
        {
            return source.Select(mapping.Expression);
        }

        /// <summary>
        /// Projects each element of a sequence into a new form using the supplied <paramref name="mapping"/> and <paramref name="parameter"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the given object <paramref name="source"/>.</typeparam>
        /// <typeparam name="TTarget">The type of the destination object into which the source is projected.</typeparam>
        /// <typeparam name="TParameter">The type of the parameter used for the projection.</typeparam>
        /// <param name="source">The object to execute the given action on.</param>
        /// <param name="mapping">The mapping to use for the projection.</param>
        /// <param name="parameter">An instance of the type <typeparamref name="TParameter"/> required for the mapping.</param>
        /// <returns></returns>
        public static IQueryable<TTarget> Select<TSource, TTarget, TParameter>(this IQueryable<TSource> source, IMapping<TSource, TTarget, TParameter> mapping, TParameter parameter)
        {
            return source.Select((mapping as Mapping<TSource, TTarget, TParameter>).Builder.ToExpression(parameter));
        }
    }
}

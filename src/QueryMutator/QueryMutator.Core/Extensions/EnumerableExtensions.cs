using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueryMutator.Core
{
    internal static class EnumerableExtensions
    {
        public static IList<T> TopologicalSort<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> getDependencies, IEqualityComparer<T> comparer = null)
        {
            var sorted = new List<T>();
            var visited = new Dictionary<T, bool>(comparer);

            foreach (var item in source)
            {
                Visit(item, getDependencies, sorted, visited);
            }

            return sorted;
        }

        private static void Visit<T>(T item, Func<T, IEnumerable<T>> getDependencies, List<T> sorted, Dictionary<T, bool> visited)
        {
            var alreadyVisited = visited.TryGetValue(item, out var inProcess);

            if (alreadyVisited)
            {
                if (inProcess)
                {
                    throw new MappingValidationException("Cyclic dependency found.");
                }
            }
            else
            {
                visited[item] = true;

                var dependencies = getDependencies(item);
                if (dependencies != null)
                {
                    foreach (var dependency in dependencies)
                    {
                        Visit(dependency, getDependencies, sorted, visited);
                    }
                }

                visited[item] = false;
                if (!sorted.Any(s => s.Equals(item)))
                {
                    sorted.Add(item);
                }
            }
        }
    }
}

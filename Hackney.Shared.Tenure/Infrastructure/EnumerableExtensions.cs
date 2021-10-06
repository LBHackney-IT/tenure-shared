using System.Collections.Generic;
using System.Linq;

namespace Hackney.Shared.Tenure.Infrastructure
{
    // TODO - move somewhere more common

    public static class EnumerableExtensions
    {
        public static List<T> ToListOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null ? new List<T>() : enumerable.ToList();
        }

        public static List<T> ToListOrNull<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null ? null : enumerable.ToList();
        }
    }
}

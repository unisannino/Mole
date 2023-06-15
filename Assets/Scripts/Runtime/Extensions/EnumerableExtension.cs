using System.Collections.Generic;
using System.Linq;

namespace Unisannino.Mole.Runtime.Extensions
{
    public static class EnumerableExtension
    {
        public static IEnumerable<(T, int)> WithIndex<T>(this IEnumerable<T> self)
        {
            return self.Select((item, index) => (item, index));
        }
    }
}
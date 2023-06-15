using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unisannino.Mole.Runtime.Extensions
{
    public static class EnumerableExtension
    {
        public static IEnumerable<(T, int)> WithIndex<T>(this IEnumerable<T> self)
        {
            return self.Select((item, index) => (item, index));
        }
        
        public static void Shuffle<T>(this IList<T> self)
        {
            // fisher-yates shuffle
            var n = self.Count;
            for (var i = 0; i < n; i++)
            {
                var r = i + Random.Range(0, n - i);
                (self[r], self[i]) = (self[i], self[r]);
            }
        }
    }
}
using System.Collections.Generic;

namespace ReleaseUtility.Extensions
{
    public static class HashSetExt
    {
        public static void AddRange<T>(this HashSet<T> hashSet, IEnumerable<T> items)
        {
            foreach(T item in items)
            {
                hashSet.Add(item);
            }
        }
    }
}

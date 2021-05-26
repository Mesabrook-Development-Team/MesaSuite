using System;
using System.Collections.Generic;

namespace API_User.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach(T item in enumerable)
            {
                action(item);
            }

            return enumerable;
        }
    }
}
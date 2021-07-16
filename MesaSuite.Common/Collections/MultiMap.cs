using MesaSuite.Common.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace MesaSuite.Common.Collections
{
    public class MultiMap<TKey, TValue> : Dictionary<TKey, HashSet<TValue>>
    {
        public void Add(TKey key, TValue value)
        {
            HashSet<TValue> values = this.GetOrSetDefault(key, () => new HashSet<TValue>());
            values.Add(value);
        }

        public void Remove(TKey key, TValue value)
        {
            if (!ContainsKey(key))
            {
                return;
            }

            HashSet<TValue> values = this[key];
            values.Remove(value);

            if (!values.Any())
            {
                Remove(key);
            }
        }
    }
}

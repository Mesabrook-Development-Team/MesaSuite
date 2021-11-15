using System;
using Newtonsoft.Json.Linq;

namespace MesaSuite.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static T Cast<T>(this object anObject)
        {
            if (anObject == null)
            {
                return default(T);
            }

            try
            {
                if (anObject is JArray jArray)
                {
                    return jArray.ToObject<T>();
                }

                return (T)Convert.ChangeType(anObject, typeof(T));
            }
            catch
            {
                return default(T);
            }
        }
    }
}

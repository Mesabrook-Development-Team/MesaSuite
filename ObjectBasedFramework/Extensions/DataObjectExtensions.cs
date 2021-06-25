using System;

namespace ClussPro.ObjectBasedFramework.Extensions
{
    public static class DataObjectExtensions
    {
        public static T As<T>(this DataObject dataObject) where T:DataObject
        {
            if (!dataObject.GetType().IsAssignableFrom(typeof(T)))
            {
                throw new InvalidCastException("Data Object destination must be of the same or inherited type as the source.");
            }

            return (T)dataObject;
        }
    }
}

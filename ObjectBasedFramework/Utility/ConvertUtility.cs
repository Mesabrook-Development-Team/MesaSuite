using System;

namespace ClussPro.ObjectBasedFramework.Utility
{
    public static class ConvertUtility
    {
        public static long? GetNullableLong(object value)
        {
            if (value == null)
            {
                return null;
            }

            Type baseType = Nullable.GetUnderlyingType(value.GetType());
            if (baseType != null)
            {
                value = Convert.ChangeType(value, baseType);
            }

            return (long?)Convert.ChangeType(value, typeof(long));
        }
    }
}

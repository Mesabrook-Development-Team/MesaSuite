using MesaSuite.Common.Attributes;
using System;
using System.Linq;

namespace MesaSuite.Common.Extensions
{
    public static class EnumExtensions
    {
        internal static TAttribute GetAttribute<TAttribute>(this Enum value) where TAttribute:Attribute
        {
            Type enumType = value.GetType();
            string name = Enum.GetName(enumType, value);
            return enumType.GetField(name)
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }

        public static string GetValue(this Enum anEnum)
        {
            EnumValueAttribute enumValueAttribute = anEnum.GetAttribute<EnumValueAttribute>();
            return enumValueAttribute?.Value;
        }
    }
}

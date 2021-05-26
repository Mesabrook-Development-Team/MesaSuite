using System;

namespace MesaSuite.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class EnumValueAttribute : Attribute
    {
        public string Value;

        public EnumValueAttribute(string Value)
        {
            this.Value = Value;
        }
    }
}

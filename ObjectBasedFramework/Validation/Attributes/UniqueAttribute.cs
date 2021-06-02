using System;

namespace ClussPro.ObjectBasedFramework.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class UniqueAttribute : Attribute
    {
        public string[] UniqueFields { get; set; }
        public UniqueAttribute(string[] UniqueFields)
        {
            this.UniqueFields = UniqueFields;
        }
    }
}

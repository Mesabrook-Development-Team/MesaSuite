using System;

namespace ReleaseUtility.Steps
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DoNotSetAttribute : Attribute
    {
    }
}

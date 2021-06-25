using ClussPro.ObjectBasedFramework.Schema.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace ClussPro.ObjectBasedFramework.Utility
{
    public class ObjectBasedFrameworkJsonContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (member.GetCustomAttribute<RelationshipAttribute>() != null || member.GetCustomAttribute<RelationshipListAttribute>() != null)
            {
                property.ShouldSerialize = i => false;
                property.Ignored = true;
            }

            return property;
        }
    }
}

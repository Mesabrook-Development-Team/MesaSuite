using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace API.Common.Utility
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

            if (typeof(ISystemLoaded).IsAssignableFrom(member.DeclaringType) && (member.Name.Equals(nameof(ISystemLoaded.SystemID), System.StringComparison.OrdinalIgnoreCase) || member.Name.Equals(nameof(ISystemLoaded.SystemHash), System.StringComparison.OrdinalIgnoreCase)))
            {
                property.ShouldSerialize = i => false;
                property.Ignored = true;
            }

            if (!property.Ignored)
            {
                property.ShouldSerialize = obj =>
                {
                    if (obj is DataObject dataObject && Schema.GetSchemaObject(obj.GetType()).GetField(member.Name) != null)
                    {
                        return dataObject.IsPathRetrieved(member.Name);
                    }

                    return true;
                };
            }

            return property;
        }
    }
}

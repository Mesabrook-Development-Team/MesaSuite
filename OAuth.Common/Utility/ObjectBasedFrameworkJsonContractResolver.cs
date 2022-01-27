using System.Reflection;
using ClussPro.ObjectBasedFramework;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace API.Common.Utility
{
    public class ObjectBasedFrameworkJsonContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            property.ShouldSerialize = obj =>
            {
                if (obj is DataObject dataObject)
                {
                    return dataObject.IsPathRetrieved(member.Name);
                }

                return true;
            };

            return property;
        }
    }
}

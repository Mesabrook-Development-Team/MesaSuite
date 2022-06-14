using System.Reflection;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema;
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
                    SchemaObject objectSchema = Schema.GetSchemaObject(dataObject.GetType());
                    if (objectSchema.GetField(member.Name) != null || // Only schema fields should be checked for retrieval
                        objectSchema.GetRelationship(member.Name) != null ||
                        objectSchema.GetRelationshipList(member.Name) != null)
                    {
                        return dataObject.IsPathRetrieved(member.Name);
                    }
                }

                return true;
            };

            return property;
        }
    }
}

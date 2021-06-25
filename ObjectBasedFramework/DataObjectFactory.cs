using ClussPro.ObjectBasedFramework.Schema;
using System;

namespace ClussPro.ObjectBasedFramework
{
    public static class DataObjectFactory
    {
        public static T Create<T>() where T:DataObject
        {
            SchemaObject schemaObject = Schema.Schema.GetSchemaObject<T>();
            return (T)schemaObject.CreateInstance();
        }

        public static DataObject Create(Type dataObjectType)
        {
            if (!typeof(DataObject).IsAssignableFrom(dataObjectType))
            {
                throw new InvalidOperationException("dataObjectType must be a type of Data Object");
            }

            SchemaObject schemaObject = Schema.Schema.GetSchemaObject(dataObjectType);
            return schemaObject.CreateInstance();
        }
    }
}

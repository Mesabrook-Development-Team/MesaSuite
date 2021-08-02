using ClussPro.Base.Data;
using System;

namespace ClussPro.ObjectBasedFramework.Schema
{
    public class Field
    {
        internal Field() { }

        public SchemaObject ParentSchemaObject { get; internal set; }
        public FieldSpecification.FieldTypes FieldType { get; internal set; }
        public int DataSize { get; internal set; }
        public int DataScale { get; internal set; }
        public string FieldName { get; internal set; }
        public bool IsRequired { get; internal set; }
        public bool IsSystemLoaded { get; internal set; }
        public bool IsPrimaryKey { get; internal set; }
        public Type ReturnType { get; internal set; }

        public Action<DataObject, object> SetValue { get; internal set; }

        internal Func<object, object> GetPrivateDataCallback { get; set; }

        internal Action<DataObject, object> SetPrivateDataCallback { get; set; }

        public object GetValue(DataObject dataObject)
        {
            return GetPrivateDataCallback(dataObject);
        }
    }
}

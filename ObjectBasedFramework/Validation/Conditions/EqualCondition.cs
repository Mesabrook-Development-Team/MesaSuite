using System;
using System.Collections.Generic;
using ClussPro.ObjectBasedFramework.Schema;

namespace ClussPro.ObjectBasedFramework.Validation.Conditions
{
    public class EqualCondition : Condition
    {
        public EqualCondition() : base() { }

        public EqualCondition(string field, object value)
        {
            Field = field;
            Value = value;
        }

        public string Field { get; set; }
        public object Value { get; set; }

        public override IEnumerable<string> AdditionalDataObjectFields => !Field.Contains(".") ? new string[0] : new[] { Field };

        public override bool Evaluate(DataObject dataObject)
        {
            SchemaObject schemaObject = Schema.Schema.GetSchemaObject(dataObject.GetType());
            Field field = schemaObject.GetField(Field);

            object fieldValue;
            if (Field.Contains("."))
            {
                SchemaObject workingObject = schemaObject;
                DataObject workingDataObject = dataObject;
                string[] parts = Field.Split('.');
                for(int i = 0; i < parts.Length - 1; i++)
                {
                    string path = parts[i];
                    Relationship relationship = workingObject.GetRelationship(path);
                    workingObject = relationship.ParentSchemaObject;
                    workingDataObject = relationship.GetValue(workingDataObject);
                }

                fieldValue = field.GetValue(workingDataObject);
            }
            else
            {
                fieldValue = field.GetValue(dataObject);
            }

            if (Value == null)
            {
                return fieldValue == null;
            }
            else if (fieldValue != null && Value is IConvertible && fieldValue is IConvertible)
            {
                var convertedFieldValue = Convert.ChangeType(fieldValue, Value.GetType());
                return Value.Equals(convertedFieldValue);
            }
            else
            {
                return Value.Equals(fieldValue);
            }
        }
    }
}

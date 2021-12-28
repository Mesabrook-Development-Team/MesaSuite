using System;
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

        public override bool Evaluate(DataObject dataObject)
        {
            SchemaObject schemaObject = Schema.Schema.GetSchemaObject(dataObject.GetType());
            Field field = schemaObject.GetField(Field);
            object fieldValue = field.GetValue(dataObject);

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

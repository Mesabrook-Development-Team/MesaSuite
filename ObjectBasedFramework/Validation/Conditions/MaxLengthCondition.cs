using ClussPro.ObjectBasedFramework.Schema;

namespace ClussPro.ObjectBasedFramework.Validation.Conditions
{
    public class MaxLengthCondition : Condition
    {
        private string field;
        private int maxLength;
        public MaxLengthCondition(string field, int maxLength)
        {
            this.field = field;
            this.maxLength = maxLength;
        }

        public override bool Evaluate(DataObject dataObject)
        {
            SchemaObject schemaObject = Schema.Schema.GetSchemaObject(dataObject.GetType());
            Field schemaField = schemaObject.GetField(field);
            object value = schemaField.GetValue(dataObject);

            if (!(value is string stringValue))
            {
                return true;
            }

            return stringValue.Length <= maxLength;
        }
    }
}

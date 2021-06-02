using ClussPro.ObjectBasedFramework.Schema;

namespace ClussPro.ObjectBasedFramework.Validation.Conditions
{
    public class RequiredFieldCondition : Condition
    {
        private string field;
        public RequiredFieldCondition(string field)
        {
            this.field = field;
        }

        public override bool Evaluate(DataObject dataObject)
        {
            SchemaObject schemaObject = Schema.Schema.GetSchemaObject(dataObject.GetType());
            Field schemaField = schemaObject.GetField(field);

            return schemaField.GetValue(dataObject) != null;
        }
    }
}

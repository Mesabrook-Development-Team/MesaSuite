using System;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework.Schema;

namespace ClussPro.ObjectBasedFramework.Validation.Conditions
{
    public class PresenceCondition : Condition
    {
        private string field;
        public PresenceCondition(string field)
        {
            this.field = field;
        }

        public override bool Evaluate(DataObject dataObject, ITransaction transaction)
        {
            SchemaObject schemaObject = Schema.Schema.GetSchemaObject(dataObject.GetType());
            Field schemaField = schemaObject.GetField(field);

            if (schemaField.ReturnType == typeof(string))
            {
                return !string.IsNullOrEmpty((string)schemaField.GetValue(dataObject));
            }

            return schemaField.GetValue(dataObject) != null;
        }
    }
}

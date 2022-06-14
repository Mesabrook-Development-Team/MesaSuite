using ClussPro.ObjectBasedFramework.Schema;

namespace ClussPro.ObjectBasedFramework.Validation.Conditions
{
    public class FieldToFieldEqualCondition : Condition
    {
        private string _myField;
        private string _otherField;

        public FieldToFieldEqualCondition(string myField, string otherField)
        {
            _myField = myField;
            _otherField = otherField;
        }

        public override bool Evaluate(DataObject dataObject)
        {
            SchemaObject schemaObject = Schema.Schema.GetSchemaObject(dataObject.GetType());
            Field field = schemaObject.GetField(_otherField);

            object otherFieldValue;
            if (_otherField.Contains("."))
            {
                SchemaObject workingObject = schemaObject;
                DataObject workingDataObject = dataObject;
                string[] parts = _otherField.Split('.');
                for (int i = 0; i < parts.Length - 1; i++)
                {
                    string path = parts[i];
                    Relationship relationship = workingObject.GetRelationship(path);
                    workingObject = relationship.ParentSchemaObject;
                    workingDataObject = relationship.GetValue(workingDataObject);
                }

                otherFieldValue = field.GetValue(workingDataObject);
            }
            else
            {
                otherFieldValue = field.GetValue(dataObject);
            }

            return new EqualCondition(_myField, otherFieldValue).Evaluate(dataObject);
        }
    }
}

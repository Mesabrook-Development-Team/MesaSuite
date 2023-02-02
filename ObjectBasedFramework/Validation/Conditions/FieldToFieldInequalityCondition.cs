namespace ClussPro.ObjectBasedFramework.Validation.Conditions
{
    public class FieldToFieldInequalityCondition : InequalityCondition
    {
        public string OtherField { get; set; }
        public FieldToFieldInequalityCondition(string field, Operations operation, string otherField) : base(field, operation, null)
        {
            OtherField = otherField;
        }

        public override bool Evaluate(DataObject dataObject)
        {
            Value = dataObject.GetValue(OtherField);

            return base.Evaluate(dataObject);
        }
    }
}

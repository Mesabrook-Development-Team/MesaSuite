namespace ClussPro.ObjectBasedFramework.Validation.Conditions
{
    public class IsFieldDirtyCondition : Condition
    {
        private string _field;
        public IsFieldDirtyCondition(string field)
        {
            _field = field;
        }

        public override bool Evaluate(DataObject dataObject)
        {
            return dataObject.IsFieldDirty(_field);
        }
    }
}

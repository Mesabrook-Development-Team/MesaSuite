using ClussPro.Base.Data.Query;

namespace ClussPro.ObjectBasedFramework.Validation.Conditions
{
    public class IsFieldDirtyCondition : Condition
    {
        private string _field;
        public IsFieldDirtyCondition(string field)
        {
            _field = field;
        }

        public override bool Evaluate(DataObject dataObject, ITransaction transaction)
        {
            return dataObject.IsFieldDirty(_field);
        }
    }
}

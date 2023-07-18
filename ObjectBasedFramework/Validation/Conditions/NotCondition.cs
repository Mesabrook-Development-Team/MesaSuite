using ClussPro.Base.Data.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClussPro.ObjectBasedFramework.Validation.Conditions
{
    public class NotCondition : Condition
    {
        public NotCondition() : base() { }

        public NotCondition(Condition baseCondition) : base()
        {
            BaseCondition = baseCondition;
        }

        public Condition BaseCondition { get; set; }

        public override IEnumerable<string> AdditionalDataObjectFields => BaseCondition.AdditionalDataObjectFields;

        public override bool Evaluate(DataObject dataObject, ITransaction transaction)
        {
            return !BaseCondition.Evaluate(dataObject, transaction);
        }
    }
}

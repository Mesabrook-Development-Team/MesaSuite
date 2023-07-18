using ClussPro.Base.Data.Query;
using System.Collections.Generic;
using System.Linq;

namespace ClussPro.ObjectBasedFramework.Validation.Conditions
{
    public abstract class Condition
    {
        public virtual IEnumerable<string> AdditionalDataObjectFields { get; } = Enumerable.Empty<string>();

        public abstract bool Evaluate(DataObject dataObject, ITransaction transaction);
    }
}

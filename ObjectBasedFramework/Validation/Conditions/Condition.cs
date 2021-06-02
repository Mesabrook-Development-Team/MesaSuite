using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClussPro.ObjectBasedFramework.Validation.Conditions
{
    public abstract class Condition
    {
        public virtual IEnumerable<string> AdditionalDataObjectFields { get; } = Enumerable.Empty<string>();

        public abstract bool Evaluate(DataObject dataObject);
    }
}

using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Validation.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClussPro.ObjectBasedFramework.Validation.Attributes
{
    public interface IValidationAttribute
    {
        string GetMessage(Field field);
        Condition GetCondition(Field field);
    }
}

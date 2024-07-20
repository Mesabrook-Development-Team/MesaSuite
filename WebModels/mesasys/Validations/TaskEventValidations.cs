using ClussPro.ObjectBasedFramework.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModels.mesasys.Validations
{
    public class TaskEventValidations : IValidationDefinition
    {
        public string Schema => "mesasys";

        public string Object => nameof(TaskEvent);

        public IEnumerable<ValidationRule> ValidationRules
        {
            get
            {
                yield return new ValidationRule()
                {
                    ID = new Guid("39115898-D71C-42ED-B016-B70C05EF7836"),
                    Message = "Selected permissions are not valid for the selected Scope",
                    Field = nameof(TaskEvent.ScopePermissions),
                    Condition = new TaskScopePermissionsValidCondition()
                };
            }
        }
    }
}

using ClussPro.ObjectBasedFramework.Validation;
using ClussPro.ObjectBasedFramework.Validation.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModels.mesasys.Validations
{
    public class NotificationEventValidations : IValidationDefinition
    {
        public string Schema => "mesasys";

        public string Object => nameof(NotificationEvent);

        public IEnumerable<ValidationRule> ValidationRules
        {
            get
            {
                yield return new ValidationRule()
                {
                    ID = new Guid("7BEE85B4-A5BD-4951-AFDC-CC1763853593"),
                    Message = "Selected permissions are not valid for the selected Scope",
                    Field = nameof(NotificationEvent.ScopePermissions),
                    Condition = new NotificationScopePermissionsValidCondition()
                };

                yield return new ValidationRule()
                {
                    ID = new Guid("93DA35EB-F008-48DC-830A-CCF454D2B806"),
                    Message = "System ID or User ID Owner must be selected, but not both",
                    Field = $"{nameof(NotificationEvent.UserIDOwner)},{nameof(NotificationEvent.SystemID)}",
                    Condition = new ConditionGroup(ConditionGroup.ConditionGroupTypes.And,
                        new ConditionGroup(ConditionGroup.ConditionGroupTypes.Or,
                            new PresenceCondition(nameof(NotificationEvent.SystemID)),
                            new PresenceCondition(nameof(NotificationEvent.UserIDOwner))),
                        new NotCondition(
                            new ConditionGroup(ConditionGroup.ConditionGroupTypes.And,
                                new PresenceCondition(nameof(NotificationEvent.SystemID)),
                                new PresenceCondition(nameof(NotificationEvent.UserIDOwner)))))
                };

                yield return new ValidationRule()
                {
                    ID = new Guid("3193D0A4-C438-4247-8BF8-72423BA56CE5"),
                    Message = "User Secret is required if User ID Owner has a value",
                    Field = nameof(NotificationEvent.UserSecret),
                    Condition = new ConditionGroup(ConditionGroup.ConditionGroupTypes.Or,
                        new NotCondition(new PresenceCondition(nameof(NotificationEvent.UserIDOwner))),
                        new PresenceCondition(nameof(NotificationEvent.UserSecret)))
                };
            }
        }
    }
}

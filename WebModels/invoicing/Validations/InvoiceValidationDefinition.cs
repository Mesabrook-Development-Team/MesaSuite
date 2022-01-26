using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.ObjectBasedFramework.Validation;
using ClussPro.ObjectBasedFramework.Validation.Conditions;

namespace WebModels.invoicing.Validations
{
    public class InvoiceValidationDefinition : IValidationDefinition
    {
        public string Schema => "invoicing";

        public string Object => nameof(Invoice);

        public IEnumerable<ValidationRule> ValidationRules
        {
            get
            {
                yield return new ValidationRule()
                {
                    ID = new Guid("425CF830-E284-4D12-8959-C14996D2C5A3"),
                    Field = "GovernmentIDFrom,LocationIDFrom",
                    Message = "Either Government From or Location From are required, but not both.",
                    Condition = new ConditionGroup(ConditionGroup.ConditionGroupTypes.And,
                        new NotCondition(new ConditionGroup(ConditionGroup.ConditionGroupTypes.And,
                            new PresenceCondition(nameof(Invoice.GovernmentIDFrom)),
                            new PresenceCondition(nameof(Invoice.LocationIDFrom)))),
                        new ConditionGroup(ConditionGroup.ConditionGroupTypes.Or,
                            new PresenceCondition(nameof(Invoice.GovernmentIDFrom)),
                            new PresenceCondition(nameof(Invoice.LocationIDFrom))))
                };

                yield return new ValidationRule()
                {
                    ID = new Guid("574B65B2-A357-40D4-B5CA-CB4770DCBFCC"),
                    Field = "GovernmentIDTo,LocationIDTo",
                    Message = "Either Government To or Location To are required, but not both.",
                    Condition = new ConditionGroup(ConditionGroup.ConditionGroupTypes.And,
                        new NotCondition(new ConditionGroup(ConditionGroup.ConditionGroupTypes.And,
                            new PresenceCondition(nameof(Invoice.GovernmentIDTo)),
                            new PresenceCondition(nameof(Invoice.LocationIDTo)))),
                        new ConditionGroup(ConditionGroup.ConditionGroupTypes.Or,
                            new PresenceCondition(nameof(Invoice.GovernmentIDTo)),
                            new PresenceCondition(nameof(Invoice.LocationIDTo))))
                };
            }
        }
    }
}

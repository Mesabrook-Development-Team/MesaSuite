using ClussPro.ObjectBasedFramework.Validation;
using System;
using System.Collections.Generic;

namespace WebModels.purchasing.Validations
{
    public class FulfillmentPlanValidations : IValidationDefinition
    {
        public string Schema => "purchasing";

        public string Object => nameof(FulfillmentPlan);

        public IEnumerable<ValidationRule> ValidationRules
        {
            get
            {
                yield return new ValidationRule()
                {
                    ID = FulfillmentPlan.SaveFlags.V_RailcarIsIdle,
                    Field = nameof(FulfillmentPlan.RailcarID),
                    Message = "Railcar must not be leased to another company and must not be assigned to another active Purchase Order.",
                    Condition = new FulfillmentPlanRailcarIsIdleCondition()
                };
            }
        }
    }
}

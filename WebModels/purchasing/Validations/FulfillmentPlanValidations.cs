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
                    ID = new Guid("F36370C5-D5B1-4F7B-9F50-5F04626826B3"),
                    Field = nameof(FulfillmentPlan.RailcarID),
                    Message = "Railcar must not be leased to another company and must not be assigned to another active Purchase Order.",
                    Condition = new FulfillmentPlanRailcarIsIdleCondition()
                };
            }
        }
    }
}

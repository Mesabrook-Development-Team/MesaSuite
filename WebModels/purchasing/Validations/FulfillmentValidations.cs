using ClussPro.ObjectBasedFramework.Validation;
using System;
using System.Collections.Generic;

namespace WebModels.purchasing.Validations
{
    public class FulfillmentValidations : IValidationDefinition
    {
        public string Schema => "purchasing";

        public string Object => nameof(Fulfillment);

        public IEnumerable<ValidationRule> ValidationRules
        {
            get
            {
                yield return new ValidationRule()
                {
                    ID = new Guid("4710ABB2-7AA7-40A9-8773-0E9B6806291D"),
                    Field = nameof(Fulfillment.RailcarID),
                    Message = FulfillmentOnEligibleRailcarCondition.MESSAGE,
                    Condition = new FulfillmentOnEligibleRailcarCondition()
                };
            }
        }
    }
}

using System;
using System.Collections.Generic;
using ClussPro.ObjectBasedFramework.Validation;

namespace WebModels.fleet.Validations
{
    public class CarHandlingRateValidationDefinition : IValidationDefinition
    {
        public string Schema => "fleet";

        public string Object => nameof(CarHandlingRate);

        public IEnumerable<ValidationRule> ValidationRules
        {
            get
            {
                yield return new ValidationRule()
                {
                    ID = new Guid("50FF8153-A445-4F92-80F2-42A784218BD9"),
                    Message = "Company or Government are required, but not both",
                    Field = "CompanyID,GovernmentID",
                    Condition = new XOrPresenceCondition("CompanyID", "GovernmentID")
                };
            }
        }
    }
}

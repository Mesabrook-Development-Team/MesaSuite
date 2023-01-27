using System;
using System.Collections.Generic;
using ClussPro.ObjectBasedFramework.Validation;

namespace WebModels.fleet.Validations
{
    public class LocomotiveValidationDefinition : IValidationDefinition
    {
        public string Schema => "fleet";

        public string Object => nameof(Locomotive);

        public IEnumerable<ValidationRule> ValidationRules
        {
            get
            {
                yield return new ValidationRule()
                {
                    ID = new Guid("95ECAC13-F7B8-4405-BECA-BCA21E01672A"),
                    Message = "Government Owner or Company Owner are required, but not both",
                    Field = "CompanyIDOwner,GovernmentIDOwner",
                    Condition = new XOrPresenceCondition("CompanyIDOwner", "GovernmentIDOwner")
                };

                yield return new ValidationRule()
                {
                    ID = new Guid("6148CC81-18C4-490C-AF3F-39682D699D42"),
                    Message = "Government Possessor or Company Possessor are required, but not both",
                    Field = "CompanyIDPossessor,GovernmentIDPossessor",
                    Condition = new XOrPresenceCondition("CompanyIDPossessor", "GovernmentIDPossessor")
                };
            }
        }
    }
}

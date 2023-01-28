using System;
using System.Collections.Generic;
using ClussPro.ObjectBasedFramework.Validation;

namespace WebModels.fleet.Validations
{
    public class RailDistrictValidationDefinition : IValidationDefinition
    {
        public string Schema => "fleet";

        public string Object => nameof(RailDistrict);

        public IEnumerable<ValidationRule> ValidationRules
        {
            get
            {
                yield return new ValidationRule()
                {
                    ID = new Guid("9406A96C-66E2-4571-BD91-232750D37152"),
                    Message = "Company or Government are required, but not both",
                    Field = "CompanyID,GovernmentID",
                    Condition = new XOrPresenceCondition("CompanyID", "GovernmentID")
                };
            }
        }
    }
}

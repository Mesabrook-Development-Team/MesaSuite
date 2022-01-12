using System;
using System.Collections.Generic;
using ClussPro.ObjectBasedFramework.Validation;
using ClussPro.ObjectBasedFramework.Validation.Conditions;

namespace WebModels.gov.Validations
{
    internal class OfficialValidationDefinition : IValidationDefinition
    {
        public string Schema => "gov";

        public string Object => "Official";

        public IEnumerable<ValidationRule> ValidationRules
        {
            get
            {
                yield return new ValidationRule()
                {
                    ID = new Guid("F44A3C4A-D18F-4710-A046-E5F4FF0CF97D"),
                    Field = "CanMintCurrency",
                    Message = "Cannot allow an Official to mint currency if the Government is not allowed to mint currency",
                    Condition = new ConditionGroup(ConditionGroup.ConditionGroupTypes.Or,
                                    new EqualCondition("CanMintCurrency", false),
                                    new ConditionGroup(ConditionGroup.ConditionGroupTypes.And,
                                        new EqualCondition("CanMintCurrency", true),
                                        new EqualCondition("Government.CanMintCurrency", true)))
                };
            }
        }
    }
}

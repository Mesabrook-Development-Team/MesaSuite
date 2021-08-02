using ClussPro.ObjectBasedFramework.Validation;
using System;
using System.Collections.Generic;
using WebModels.hMailServer.dbo;
using WebModels.hMailServer.Validations.Conditions;

namespace WebModels.hMailServer.Validations.dbo
{
    public class AliasValidations : IValidationDefinition
    {
        public string Schema => "dbo";

        public string Object => "hm_aliases";

        public IEnumerable<ValidationRule> ValidationRules
        {
            get
            {
                yield return new ValidationRule()
                {
                    ID = Alias.ValidationFlags.V_AddressEndsWithCompanyAddress,
                    Field = "AliasName",
                    Message = "Alias must end with Company's Domain",
                    Condition = new EndsWithOtherFieldCondition<Alias>("AliasName", alias => alias.AliasDomain.DomainName)
                };
            }
        }
    }
}

using ClussPro.ObjectBasedFramework.Validation;
using ClussPro.ObjectBasedFramework.Validation.Conditions;
using System;
using System.Collections.Generic;
using WebModels.hMailServer.dbo;
using WebModels.hMailServer.Validations.Conditions;

namespace WebModels.hMailServer.Validations.dbo
{
    public class DistributionListValidations : IValidationDefinition
    {
        public string Schema => "dbo";

        public string Object => "hm_distributionlists";

        public IEnumerable<ValidationRule> ValidationRules
        {
            get
            {
                yield return new ValidationRule()
                {
                    ID = new Guid("E15DAE45-96B6-4C7E-870F-93473A94B623"),
                    Field = "DistributionListRequireAddress",
                    Message = "Specific address is required when Send Type is Specific, otherwise it must be blank",
                    Condition = new ConditionGroup(ConditionGroup.ConditionGroupTypes.Or,
                                                    new ConditionGroup(ConditionGroup.ConditionGroupTypes.And,
                                                        new EqualCondition("DistributionListMode", 2),
                                                        new PresenceCondition("DistributionListRequireAddress")),
                                                    new ConditionGroup(ConditionGroup.ConditionGroupTypes.And,
                                                        new NotCondition(new EqualCondition("DistributionListMode", 2)),
                                                        new NotCondition(new PresenceCondition("DistributionListRequireAddress"))))
                };

                yield return new ValidationRule()
                {
                    ID = DistributionList.ValidationFlags.V_AddressEndsWithCompanyAddress,
                    Field = "DistributionListAddress",
                    Message = "Address must end with Company's Domain",
                    Condition = new EndsWithOtherFieldCondition<DistributionList>("DistributionListAddress", dl => dl.DistributionListDomain.DomainName)
                };
            }
        }
    }
}

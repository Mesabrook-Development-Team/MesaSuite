using System;
using System.Collections.Generic;
using ClussPro.ObjectBasedFramework.Validation;
using ClussPro.ObjectBasedFramework.Validation.Conditions;

namespace WebModels.fleet.Validations
{
    public class LocomotiveModelValidationDefinition : IValidationDefinition
    {
        public string Schema => "fleet";

        public string Object => nameof(LocomotiveModel);

        public IEnumerable<ValidationRule> ValidationRules
        {
            get
            {
                yield return new ValidationRule()
                {
                    ID = new Guid("4F70AE77-2734-4343-9A55-311B7532B68F"),
                    Message = "Water Capacity is a required field if this Model is marked as Steam",
                    Field = "WaterCapcity",
                    Condition = new ConditionGroup(ConditionGroup.ConditionGroupTypes.Or,
                                    new EqualCondition(nameof(LocomotiveModel.IsSteamPowered), false),
                                    new PresenceCondition(nameof(LocomotiveModel.WaterCapacity)))
                };
            }
        }
    }
}

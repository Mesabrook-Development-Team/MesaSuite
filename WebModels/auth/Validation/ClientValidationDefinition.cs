using System;
using System.Collections.Generic;
using ClussPro.ObjectBasedFramework.Validation;
using ClussPro.ObjectBasedFramework.Validation.Conditions;

namespace WebModels.auth.Validation
{
    public class ClientValidationDefinition : IValidationDefinition
    {
        public string Schema => "auth";

        public string Object => "Client";

        public IEnumerable<ValidationRule> ValidationRules
        {
            get
            {
                yield return new ValidationRule()
                {
                    ID = new Guid("657C55BE-4301-46CC-A214-798B01371A45"),
                    Field = nameof(Client.RedirectionURI),
                    Condition = new ConditionGroup(ConditionGroup.ConditionGroupTypes.Or,
                        new EqualCondition(nameof(Client.Type), Client.Types.Device),
                        new PresenceCondition(nameof(Client.RedirectionURI))),
                    Message = "Redirection URI is a required field when Type is Browser Enabled"
                };
            }
        }
    }
}

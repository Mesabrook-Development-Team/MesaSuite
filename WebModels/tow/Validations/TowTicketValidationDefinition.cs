using ClussPro.ObjectBasedFramework.Validation;
using ClussPro.ObjectBasedFramework.Validation.Conditions;
using System;
using System.Collections.Generic;

namespace WebModels.tow.Validations
{
    public class TowTicketValidationDefinition : IValidationDefinition
    {
        public string Schema => "tow";

        public string Object => nameof(TowTicket);

        public IEnumerable<ValidationRule> ValidationRules
        {
            get
            {
                yield return new ValidationRule()
                {
                    ID = new Guid("FF517441-03D8-4C31-A58F-82F0BC19895B"),
                    Field = nameof(TowTicket.CoordX),
                    Message = "Coordinate X is a required field",
                    Condition = new ConditionGroup(ConditionGroup.ConditionGroupTypes.Or,
                        new EqualCondition(nameof(TowTicket.StatusCode), (int)TowTicket.Statuses.New),
                        new PresenceCondition(nameof(TowTicket.CoordX)))
                };

                yield return new ValidationRule()
                {
                    ID = new Guid("FF517441-03D8-4C31-A58F-82F0BC19895B"),
                    Field = nameof(TowTicket.CoordZ),
                    Message = "Coordinate Z is a required field",
                    Condition = new ConditionGroup(ConditionGroup.ConditionGroupTypes.Or,
                        new EqualCondition(nameof(TowTicket.StatusCode), (int)TowTicket.Statuses.New),
                        new PresenceCondition(nameof(TowTicket.CoordZ)))
                };

                yield return new ValidationRule()
                {
                    ID = new Guid("F31665ED-A4D8-4823-832E-BC1FB67C9EC3"),
                    Field = nameof(TowTicket.RespondingTime),
                    Message = "Responding Time is a required field",
                    Condition = new ConditionGroup(ConditionGroup.ConditionGroupTypes.Or,
                        new InequalityCondition(nameof(TowTicket.StatusCode), InequalityCondition.Operations.LessThan, (int)TowTicket.Statuses.ResponseEnRoute),
                        new PresenceCondition(nameof(TowTicket.RespondingTime)))
                };

                yield return new ValidationRule()
                {
                    ID = new Guid("F31665ED-A4D8-4823-832E-BC1FB67C9EC3"),
                    Field = nameof(TowTicket.CompletionTime),
                    Message = "Completion Time is a required field",
                    Condition = new ConditionGroup(ConditionGroup.ConditionGroupTypes.Or,
                        new InequalityCondition(nameof(TowTicket.StatusCode), InequalityCondition.Operations.LessThan, (int)TowTicket.Statuses.History),
                        new PresenceCondition(nameof(TowTicket.CompletionTime)))
                };
            }
        }
    }
}

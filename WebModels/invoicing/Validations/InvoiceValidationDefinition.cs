using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.ObjectBasedFramework.Validation;
using ClussPro.ObjectBasedFramework.Validation.Conditions;

namespace WebModels.invoicing.Validations
{
    public class InvoiceValidationDefinition : IValidationDefinition
    {
        public string Schema => "invoicing";

        public string Object => nameof(Invoice);

        public IEnumerable<ValidationRule> ValidationRules
        {
            get
            {
                #region Presence
                yield return new ValidationRule()
                {
                    ID = new Guid("425CF830-E284-4D12-8959-C14996D2C5A3"),
                    Field = "GovernmentIDFrom,LocationIDFrom",
                    Message = "Either Government From or Location From are required, but not both.",
                    Condition = new ConditionGroup(ConditionGroup.ConditionGroupTypes.And,
                        new NotCondition(new ConditionGroup(ConditionGroup.ConditionGroupTypes.And,
                            new PresenceCondition(nameof(Invoice.GovernmentIDFrom)),
                            new PresenceCondition(nameof(Invoice.LocationIDFrom)))),
                        new ConditionGroup(ConditionGroup.ConditionGroupTypes.Or,
                            new PresenceCondition(nameof(Invoice.GovernmentIDFrom)),
                            new PresenceCondition(nameof(Invoice.LocationIDFrom))))
                };

                yield return new ValidationRule()
                {
                    ID = new Guid("574B65B2-A357-40D4-B5CA-CB4770DCBFCC"),
                    Field = "GovernmentIDTo,LocationIDTo",
                    Message = "Either Government To or Location To are required, but not both.",
                    Condition = new ConditionGroup(ConditionGroup.ConditionGroupTypes.And,
                        new NotCondition(new ConditionGroup(ConditionGroup.ConditionGroupTypes.And,
                            new PresenceCondition(nameof(Invoice.GovernmentIDTo)),
                            new PresenceCondition(nameof(Invoice.LocationIDTo)))),
                        new ConditionGroup(ConditionGroup.ConditionGroupTypes.Or,
                            new PresenceCondition(nameof(Invoice.GovernmentIDTo)),
                            new PresenceCondition(nameof(Invoice.LocationIDTo))))
                };
                #endregion

                #region Same Destination
                yield return new ValidationRule()
                {
                    ID = new Guid("F44C3FB5-3E2C-48BB-AB96-AAA7A19A6D3A"),
                    Field = "GovernmentIDFrom,GovernmentIDTo",
                    Message = "Cannot Invoice From and To same Government",
                    Condition = new ConditionGroup(ConditionGroup.ConditionGroupTypes.Or,
                                    new ConditionGroup(ConditionGroup.ConditionGroupTypes.And,
                                        new NotCondition(new PresenceCondition("GovernmentIDFrom")),
                                        new NotCondition(new PresenceCondition("GovernmentIDTo"))),
                                    new NotCondition(new FieldToFieldEqualCondition("GovernmentIDFrom", "GovernmentIDTo")))
                };

                yield return new ValidationRule()
                {
                    ID = new Guid("F44C3FB5-3E2C-48BB-AB96-AAA7A19A6D3A"),
                    Field = "LocationIDFrom,LocationIDTo",
                    Message = "Cannot Invoice From and To same Location",
                    Condition = new ConditionGroup(ConditionGroup.ConditionGroupTypes.Or,
                                    new ConditionGroup(ConditionGroup.ConditionGroupTypes.And,
                                        new NotCondition(new PresenceCondition("LocationIDFrom")),
                                        new NotCondition(new PresenceCondition("LocationIDTo"))),
                                    new NotCondition(new FieldToFieldEqualCondition("LocationIDFrom", "LocationIDTo")))
                };
                #endregion

                #region Status
                yield return new ValidationRule()
                {
                    ID = Invoice.ValidationIDs.V_HistoryStatusChanges,
                    Message = "Completed Invoices may not be updated or deleted",
                    ApplyOnDelete = true,
                    Condition = new NotCondition(new EqualCondition("Status", Invoice.Statuses.Complete))
                };

                yield return new ValidationRule()
                {
                    ID = new Guid("DE904CC5-FF28-4250-BCEA-D31D749FEF51"),
                    Message = "Invoice must be entirely filled out before issuing",
                    Condition = new ConditionGroup(ConditionGroup.ConditionGroupTypes.Or,
                                    new NotCondition(new IsFieldDirtyCondition(nameof(Invoice.Status))),
                                    new NotCondition(new EqualCondition(nameof(Invoice.Status), Invoice.Statuses.Sent)),
                                    new IsValidForSentStatusCondition())
                };
                #endregion
            }
        }
    }
}

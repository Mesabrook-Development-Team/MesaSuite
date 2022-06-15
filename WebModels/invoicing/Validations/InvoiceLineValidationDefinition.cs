using System;
using System.Collections.Generic;
using ClussPro.ObjectBasedFramework.Validation;
using ClussPro.ObjectBasedFramework.Validation.Conditions;

namespace WebModels.invoicing.Validations
{
    internal class InvoiceLineValidationDefinition : IValidationDefinition
    {
        public string Schema => "invoicing";

        public string Object => nameof(InvoiceLine);

        public IEnumerable<ValidationRule> ValidationRules
        {
            get
            {
                yield return new ValidationRule()
                {
                    ID = new Guid("26F499F7-5E16-45D8-B8EC-D1883C376C31"),
                    Message = "Completed Invoices may not be updated or deleted",
                    ApplyOnDelete = true,
                    Condition = new NotCondition(new EqualCondition("Invoice.Status", Invoice.Statuses.Complete))
                };
            }
        }
    }
}

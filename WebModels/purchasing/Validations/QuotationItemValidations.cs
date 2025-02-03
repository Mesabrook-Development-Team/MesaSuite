using ClussPro.ObjectBasedFramework.Validation;
using System;
using System.Collections.Generic;

namespace WebModels.purchasing.Validation
{
    public class QuotationItemValidations : IValidationDefinition
    {
        public string Schema => "purchasing";

        public string Object => nameof(QuotationItem);

        public IEnumerable<ValidationRule> ValidationRules
        {
            get
            {
                yield return new ValidationRule()
                {
                    ID = new Guid("3D72BB96-9A4E-4E4A-A4D5-E87EA0BC062F"),
                    Field = nameof(QuotationItem.ItemID),
                    Message = "Quoted Item must be within Price Manager",
                    Condition = new QuotedItemInPriceManagerCondition()
                };
            }
        }
    }
}

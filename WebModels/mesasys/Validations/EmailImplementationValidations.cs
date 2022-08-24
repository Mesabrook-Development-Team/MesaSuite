using System;
using System.Collections.Generic;
using ClussPro.ObjectBasedFramework.Validation;

namespace WebModels.mesasys.Validations
{
    internal class EmailImplementationValidations : IValidationDefinition
    {
        public string Schema => "mesasys";

        public string Object => nameof(EmailImplementation);

        public IEnumerable<ValidationRule> ValidationRules
        {
            get
            {
                yield return new ValidationRule()
                {
                    ID = new Guid("45D472AB-840F-47BA-9FB1-24B4602B0342"),
                    Field = nameof(EmailImplementation.Body),
                    Message = "Email Body has some invalid bindings.",
                    Condition = new HasValidBindingsCondition($"{nameof(EmailImplementation.EmailTemplate)}.{nameof(EmailTemplate.AllowedFields)}", nameof(EmailImplementation.Body))
                };
            }
        }
    }
}

using System;
using System.Collections.Generic;
using ClussPro.ObjectBasedFramework.Validation;
using ClussPro.ObjectBasedFramework.Validation.Conditions;

namespace WebModels.company.Validation
{
    public class RegisterValidations : IValidationDefinition
    {
        public string Schema => "company";

        public string Object => nameof(Register);

        public IEnumerable<ValidationRule> ValidationRules
        {
            get
            {
                yield return new ValidationRule()
                {
                    ID = new Guid("B2CB2C0D-0090-449A-8B4A-4A1941411C67"),
                    ApplyOnInsert = false,
                    Field = nameof(Register.Identifier),
                    Message = "Identifier cannot be changed",
                    Condition = new NotCondition(new IsFieldDirtyCondition(nameof(Register.Identifier)))
                };
            }
        }
    }
}

using System.Collections.Generic;

namespace ClussPro.ObjectBasedFramework.Validation
{
    public class ObjectAttributeValidationDefinition : IValidationDefinition
    {
        public string Schema { get; internal set; }

        public string Object { get; internal set; }

        internal List<ValidationRule> InternalValidationRules = new List<ValidationRule>();

        public IEnumerable<ValidationRule> ValidationRules => InternalValidationRules;
    }
}

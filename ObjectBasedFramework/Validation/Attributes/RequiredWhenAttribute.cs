using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Validation.Conditions;
using System;

namespace ClussPro.ObjectBasedFramework.Validation.Attributes
{
    public class RequiredWhenAttribute : Attribute, IValidationAttribute
    {
        public string OtherField { get; set; }
        public object OtherValue { get; set; }

        public RequiredWhenAttribute(string OtherField, object OtherValue)
        {
            this.OtherField = OtherField;
            this.OtherValue = OtherValue;
        }

        public Condition GetCondition(Field field)
        {
            return new ConditionGroup(ConditionGroup.ConditionGroupTypes.Or,
                new NotCondition(new EqualCondition(OtherField, OtherValue)),
                new PresenceCondition(field.FieldName));
        }

        public string GetMessage(Field field)
        {
            return $"{field.FieldName} is required when {OtherField} is set to {OtherValue}";
        }
    }
}

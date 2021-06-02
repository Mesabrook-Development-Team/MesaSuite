using ClussPro.ObjectBasedFramework.Validation.Conditions;
using System;

namespace ClussPro.ObjectBasedFramework.Validation
{
    public class ValidationRule
    {
        public Guid ID { get; set; }
        public bool ApplyOnInsert { get; set; } = true;
        public bool ApplyOnUpdate { get; set; } = true;
        public bool ApplyOnDelete { get; set; }
        public string Field { get; set; }
        public string Message { get; set; }
        public Condition Condition { get; set; }
    }
}

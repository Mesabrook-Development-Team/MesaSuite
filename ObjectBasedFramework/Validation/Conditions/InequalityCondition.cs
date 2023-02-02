using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.ObjectBasedFramework.Schema;

namespace ClussPro.ObjectBasedFramework.Validation.Conditions
{
    public class InequalityCondition : Condition
    {
        private string Field { get; set; }
        private Operations Operation { get; set; }
        protected object Value { get; set; }

        public InequalityCondition(string field, Operations operation, object value)
        {
            Field = field;
            Operation = operation;
            Value = value;
        }

        public override bool Evaluate(DataObject dataObject)
        {
            SchemaObject schemaObject = Schema.Schema.GetSchemaObject(dataObject.GetType());
            Field field = schemaObject.GetField(Field);
            object dbValue = field.GetValue(dataObject);

            if ((Operation == Operations.LessThanOrEqual ||
                Operation == Operations.Equal ||
                Operation == Operations.GreaterThanOrEqual) &&
                dbValue == Value)
            {
                return true;
            }

            if (dbValue == null || Value == null)
            {
                return false;
            }

            IComparable dbComparable = (IComparable)dbValue;
            IComparable valueComparable = (IComparable)Value;

            if (Operation == Operations.LessThanOrEqual || Operation == Operations.LessThan)
            {
                return dbComparable.CompareTo(valueComparable) < 0;
            }

            if (Operation == Operations.GreaterThan || Operation == Operations.GreaterThanOrEqual)
            {
                return dbComparable.CompareTo(valueComparable) > 0;
            }

            return false;
        }

        public enum Operations
        {
            LessThan,
            LessThanOrEqual,
            Equal,
            GreaterThanOrEqual,
            GreaterThan
        }
    }
}

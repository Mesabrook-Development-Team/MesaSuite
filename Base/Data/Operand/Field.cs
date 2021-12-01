using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClussPro.Base.Data.Operand
{
    public class Field : IOperand
    {
        public string TableAlias { get; set; }
        public string FieldName { get; set; }

        public static implicit operator Field(string value)
        {
            Field field = new Field();
            if (value.Contains("."))
            {
                field.TableAlias = value.Substring(0, value.LastIndexOf('.'));
                field.FieldName = value.Substring(value.LastIndexOf('.') + 1);
            }
            else
            {
                field.FieldName = value;
            }

            return field;
        }
    }
}

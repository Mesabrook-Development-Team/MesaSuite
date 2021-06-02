using ClussPro.Base.Data.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClussPro.Base.Data.Conditions
{
    public class Exists : ICondition
    {
        public ISelectQuery SelectQuery { get; set; }
        public ExistTypes ExistType { get; set; }

        public enum ExistTypes
        {
            Exists,
            NotExists
        }
    }
}

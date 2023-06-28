using System;
using System.Collections.Generic;

namespace CompanyStudio.Models
{
    public class Register
    {
        public long? RegisterID { get; set; }
        public long? LocationID { get; set; }
        public Location Location { get; set; }
        public Guid? Identifier { get; set; }
        public string Name { get; set; }
        public RegisterStatus CurrentStatus { get; set; }

        public List<RegisterStatus> RegisterStatuses { get; set; }
    }
}

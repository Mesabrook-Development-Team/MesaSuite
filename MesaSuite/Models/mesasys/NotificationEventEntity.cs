using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MesaSuite.Models.company;
using MesaSuite.Models.gov;

namespace MesaSuite.Models.mesasys
{
    public class NotificationEventEntity
    {
        public long? NotificationEventEntityID { get; set; }
        public long? NotificationEventID { get; set; }
        public NotificationEvent NotificationEvent { get; set; }
        public long? CompanyID { get; set; }
        public Company Company { get; set; }
        public long? LocationID { get; set; }
        public Location Location { get; set; }
        public long? GovenrmentID { get; set; }
        public Government Government { get; set; }
    }
}

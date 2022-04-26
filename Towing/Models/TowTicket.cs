using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Towing.Models
{
    public class TowTicket
    {
        public long? TowTicketID { get; set; }
        public string UserIssuedTo { get; set; }
        public string TicketNumber { get; set; }
        public DateTime? IssueDate { get; set; }
        public string PhoneNumber { get; set; }
        public int CoordX { get; set; }
        public int CoordZ { get; set; }
        public string Description { get; set; }
        public string UserResponding { get; set; }
        public string Status { get; set; }
        public DateTime? RespondingTime { get; set; }
        public DateTime? CompletionTime { get; set; }
    }
}

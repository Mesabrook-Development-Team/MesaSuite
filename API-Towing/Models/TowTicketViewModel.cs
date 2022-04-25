using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebModels.tow;

namespace API_Towing.Models
{
    public class TowTicketViewModel
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

        public static TowTicketViewModel CreateFromTowTicket(TowTicket towTicket)
        {
            TowTicketViewModel instance = new TowTicketViewModel()
            {
                TowTicketID = towTicket.TowTicketID,
                UserIssuedTo = towTicket.UserIssuedTo.Username,
                PhoneNumber = towTicket.PhoneNumber,
                TicketNumber = towTicket.TicketNumber,
                IssueDate = towTicket.IssueDate,
                CoordX = towTicket.CoordX ?? 0,
                CoordZ = towTicket.CoordZ ?? 0,
                Description = towTicket.Description,
                UserResponding = towTicket.UserResponding.Username,
                Status = towTicket.Status.ToString()
            };

            return instance;
        }
    }
}
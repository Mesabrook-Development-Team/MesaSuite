using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using WebModels.tow;

namespace API_Towing.Models
{
    public class TowTicketViewModel
    {
        [JsonIgnore]
        public static readonly string[] SEARCH_FIELDS = new string[]
        {
            nameof(TowTicket.TowTicketID),
            $"{nameof(TowTicket.UserIssuedTo)}.{nameof(WebModels.security.User.Username)}",
            nameof(TowTicket.PhoneNumber),
            nameof(TowTicket.TicketNumber),
            nameof(TowTicket.IssueDate),
            nameof(TowTicket.CoordX),
            nameof(TowTicket.CoordZ),
            nameof(TowTicket.Description),
            $"{nameof(TowTicket.UserResponding)}.{nameof(WebModels.security.User.Username)}",
            nameof(TowTicket.StatusCode),
            nameof(TowTicket.RespondingTime),
            nameof(TowTicket.CompletionTime)
        };

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
                Status = towTicket.Status.ToString(),
                RespondingTime = towTicket.RespondingTime,
                CompletionTime = towTicket.CompletionTime
            };

            return instance;
        }
    }
}
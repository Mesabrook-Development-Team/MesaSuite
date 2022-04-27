using System;

namespace Towing.Models
{
    public class GetStatusModel
    {
        public string ticketnumber { get; set; }
        public string status { get; set; }
        public string responder { get; set; }
        public DateTime? responsetime { get; set; }
    }
}

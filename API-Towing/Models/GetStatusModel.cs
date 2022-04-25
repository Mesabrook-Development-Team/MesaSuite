using System;

namespace API_Towing.Models
{
    public class GetStatusModel
    {
        public string status { get; set; }
        public string responder { get; set; }
        public DateTime? responsetime { get; set; }
    }
}
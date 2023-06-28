using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStudio.Models
{
    public class RegisterStatus
    {
        public long? RegisterStatusID { get; set; }
        public long? RegisterID { get; set; }
        public Register Register { get; set; }
        public DateTime? ChangeTime { get; set; }
        public enum Statuses
        {
            Offline,
            InternalStorageFull,
            Online
        }
        public Statuses Status { get; set; }
        public string Initiator { get; set; }
    }
}

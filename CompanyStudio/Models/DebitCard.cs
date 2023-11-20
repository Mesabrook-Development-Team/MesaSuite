using System;

namespace CompanyStudio.Models
{
    public class DebitCard
    {
        public long? DebitCardID { get; set; }
        public long? AccountID { get; set; }
        public Account Account { get; set; }
        public string CardNumber { get; set; }
        public DateTime? IssuedTime { get; set; }
        public long? UserIDIssuedBy { get; set; }
        public User UserIssuedBy { get; set; }
    }
}

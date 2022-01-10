namespace GovernmentPortal.Models
{
    public class Category
    {
        public long CategoryID { get; set; }
        public long GovernmentID { get; set; }
        public long CompanyID { get; set; }
        public string Name { get; set; }
        public int AccountCount { get; set; }
    }
}

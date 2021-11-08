namespace CompanyStudio.Models
{
    public class Category
    {
        public long CategoryID { get; set; }
        public long CompanyID { get; set; }
        public string Name { get; set; }
        public int AccountCount { get; set; }
    }
}

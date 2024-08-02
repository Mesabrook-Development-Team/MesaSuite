namespace MesaSuite.Models.company
{
    public class Location
    {
        public long? LocationID { get; set; }
        public long? CompanyID { get; set; }
        public Company Company { get; set; }
        public string Name { get; set; }
    }
}

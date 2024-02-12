namespace SystemManagement.Models
{
    public class TermsOfService
    {
        public long? TermsOfServiceID { get; set; }
        public enum Types
        {
            MesabrookServer,
            MesaSuite
        }
        public Types Type { get; set; }
        public string Terms { get; set; }
    }
}

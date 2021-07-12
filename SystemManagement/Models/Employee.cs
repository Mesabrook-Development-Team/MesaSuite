namespace SystemManagement.Models
{
    public class Employee
    {
        public long EmployeeID { get; set; }
        public long CompanyID { get; set; }
        public long UserID { get; set; }
        public bool ManageEmails { get; set; }
        public bool ManageEmployees { get; set; }
    }
}

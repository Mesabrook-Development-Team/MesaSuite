namespace CompanyStudio.Models
{
    public class Employee
    {
        public long EmployeeID { get; set; }
        public long CompanyID { get; set; }
        public long UserID { get; set; }
        public bool ManageEmails { get; set; }
        public bool ManageEmployees { get; set; }
        public bool ManageAccounts { get; set; }
        public bool ManageLocations { get; set; }
        public string EmployeeName { get; set; }
    }
}

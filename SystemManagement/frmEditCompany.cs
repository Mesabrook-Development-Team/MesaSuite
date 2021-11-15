using MesaSuite.Common.Collections;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemManagement.Models;

namespace SystemManagement
{
    public partial class frmEditCompany : Form
    {
        public long CompanyID { get; set; }
        private string InitialEmailDomain { get; set; }
        private List<Employee> _employees = new List<Employee>();
        public frmEditCompany()
        {
            InitializeComponent();
            imlSmall.Images.Add("user", Properties.Resources.user);
        }

        private async void frmEditCompany_Load(object sender, EventArgs e)
        {
            GetData get = new GetData(DataAccess.APIs.SystemManagement, "Company/Get");
            get.QueryString = new MultiMap<string, string>()
            {
                { "id", CompanyID.ToString() }
            };

            Enabled = false;

            Company company = await get.GetObject<Company>();
            if (company != null)
            {
                txtName.Text = company.Name;
                cboDomain.Text = company.EmailDomain;

                InitialEmailDomain = company.EmailDomain;
            }

            await LoadDomains();
            await LoadEmployees();
        }

        private async Task LoadDomains()
        {
            Enabled = false;

            GetData get = new GetData(DataAccess.APIs.SystemManagement, "Domain/GetAll");
            List<Domain> domains = await get.GetObject<List<Domain>>();

            if (domains != null)
            {
                foreach (Domain domain in domains)
                {
                    cboDomain.Items.Add(domain.DomainName);
                }
            }

            Enabled = true;
            BringToFront();
        }

        private async Task LoadEmployees()
        {
            Enabled = false;

            lstEmployees.Items.Clear();

            GetData get = new GetData(DataAccess.APIs.SystemManagement, "Employee/GetEmployeesByCompany");
            get.QueryString = new MultiMap<string, string>()
            {
                { "companyid", CompanyID.ToString() }
            };
            _employees = await get.GetObject<List<Employee>>();
            if (_employees == null)
            {
                _employees = new List<Employee>();
                Enabled = true;
                BringToFront();
                return;
            }

            MultiMap<string, string> getUserQueryString = new MultiMap<string, string>();
            foreach(long userID in _employees.Select(e => e.UserID))
            {
                getUserQueryString.Add("userids", userID.ToString());
            }
            get = new GetData(DataAccess.APIs.SystemManagement, "User/GetUsers");
            get.QueryString = getUserQueryString;

            List<User> users = await get.GetObject<List<User>>();
            Dictionary<long, User> usersByID = new Dictionary<long, User>();
            if (users != null)
            {
                usersByID = users.ToDictionary(u => u.UserID);
            }

            foreach(Employee employee in _employees)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = employee;
                item.Text = usersByID.GetOrDefault(employee.UserID)?.Username;
                item.ImageKey = "user";
                lstEmployees.Items.Add(item);
            }

            Enabled = true;
            BringToFront();
        }

        private async void cmdSelectEmployees_Click(object sender, EventArgs e)
        {
            frmSelectUsers selectUsers = new frmSelectUsers();
            selectUsers.SelectedUserIDs = _employees.Select(emp => emp.UserID).ToList();
            DialogResult result = selectUsers.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            Enabled = false;

            foreach(long userID in selectUsers.SelectedUserIDs.Except(_employees.Select(emp => emp.UserID)))
            {
                Employee employee = new Employee();
                employee.UserID = userID;
                employee.CompanyID = CompanyID;

                PutData putEmployee = new PutData(DataAccess.APIs.SystemManagement, "Employee/CreateOrUpdate", employee);
                await putEmployee.ExecuteNoResult();
            }

            foreach(long employeeID in _employees.Where(emp => !selectUsers.SelectedUserIDs.Contains(emp.UserID)).Select(emp => emp.EmployeeID))
            {
                PutData delete = new PutData(DataAccess.APIs.SystemManagement, "Employee/DemoteEmployee", new Employee() { EmployeeID = employeeID });
                await delete.ExecuteNoResult();
            }

            await LoadEmployees();
        }

        private string domainWarningText = "";
        private bool clearedDomainWarningShown = false;

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Name is a required field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboDomain.Text != null && !cboDomain.Items.Contains(cboDomain.Text) && domainWarningText != cboDomain.Text)
            {
                domainWarningText = cboDomain.Text;
                MessageBox.Show("Selected email domain does not exist in the system.  This will result to problems for company emails.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(cboDomain.Text) && !string.IsNullOrEmpty(InitialEmailDomain) && !clearedDomainWarningShown)
            {
                clearedDomainWarningShown = true;
                MessageBox.Show("Clearing Email Domain will keep any Aliases and Distribution Lists in place.  If you intend to remove these records, reommend deleting the domain.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Company company = new Company()
            {
                CompanyID = CompanyID,
                Name = txtName.Text,
                EmailDomain = cboDomain.Text
            };

            PutData put = new PutData(DataAccess.APIs.SystemManagement, "Company/Put", company);
            await put.ExecuteNoResult();

            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

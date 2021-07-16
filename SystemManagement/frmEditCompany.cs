using MesaSuite.Common.Collections;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemManagement.Models;

namespace SystemManagement
{
    public partial class frmEditCompany : Form
    {
        public long CompanyID { get; set; }
        private List<Employee> _employees = new List<Employee>();
        public frmEditCompany()
        {
            InitializeComponent();
            imlSmall.Images.Add("user", Properties.Resources.user);
        }

        private async void frmEditCompany_Load(object sender, EventArgs e)
        {
            GetData get = new GetData(DataAccess.APIs.SystemManagement, "Company/GetCompany");
            get.QueryString = new MultiMap<string, string>()
            {
                { "id", CompanyID.ToString() }
            };

            Enabled = false;

            Company company = await get.GetObject<Company>();
            if (company != null)
            {
                txtName.Text = company.Name;
            }

            await LoadEmployees();
        }

        private async Task LoadEmployees()
        {
            Enabled = false;

            lstEmployees.Items.Clear();

            GetData get = new GetData(DataAccess.APIs.SystemManagement, "Company/GetEmployeesByCompany");
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
                item.SubItems.Add(employee.ManageEmails.ToString());
                item.SubItems.Add(employee.ManageEmployees.ToString());
                lstEmployees.Items.Add(item);
            }

            Enabled = true;
            BringToFront();
        }

        private void lstEmployees_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach(ListViewItem item in lstEmployees.SelectedItems)
            {
                frmEditEmployee editEmployee = new frmEditEmployee();
                editEmployee.Employee = (Employee)item.Tag;
                editEmployee.FormClosed += EditEmployee_FormClosed;
                editEmployee.Show();
            }
        }

        private async void EditEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmEditEmployee editEmployee = (frmEditEmployee)sender;
            editEmployee.FormClosed -= EditEmployee_FormClosed;

            await LoadEmployees();
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

                PostData postEmployee = new PostData(DataAccess.APIs.SystemManagement, "Company/PostEmployee", employee);
                await postEmployee.ExecuteNoResult();
            }

            foreach(long employeeID in _employees.Where(emp => !selectUsers.SelectedUserIDs.Contains(emp.UserID)).Select(emp => emp.EmployeeID))
            {
                DeleteData delete = new DeleteData(DataAccess.APIs.SystemManagement, "Company/DeleteEmployee");
                delete.QueryString = new Dictionary<string, string>()
                {
                    { "id", employeeID.ToString() }
                };
                await delete.Execute();
            }

            await LoadEmployees();
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Name is a required field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Company company = new Company()
            {
                CompanyID = CompanyID,
                Name = txtName.Text
            };

            PutData put = new PutData(DataAccess.APIs.SystemManagement, "Company/PutCompany", company);
            await put.ExecuteNoResult();

            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

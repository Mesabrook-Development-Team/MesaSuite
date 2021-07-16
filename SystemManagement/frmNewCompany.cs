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
    public partial class frmNewCompany : Form
    {
        private List<Employee> _employees = new List<Employee>();
        public frmNewCompany()
        {
            InitializeComponent();

            imlSmall.Images.Add("user", Properties.Resources.user);
        }

        private void lstEmployees_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach(ListViewItem item in lstEmployees.SelectedItems)
            {
                Employee employee = (Employee)item.Tag;

                frmEditEmployee editEmployee = new frmEditEmployee();
                editEmployee.Employee = employee;
                editEmployee.CompanyNameOverride = txtName.Text;
                editEmployee.PerformDatabaseSave = false;
                editEmployee.FormClosed += EditEmployee_FormClosed;
                editEmployee.Show();
            }
        }

        private async void EditEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmEditEmployee editEmployee = (frmEditEmployee)sender;
            editEmployee.FormClosed -= EditEmployee_FormClosed;

            Enabled = false;

            await LoadEmployees();

            Enabled = true;

            BringToFront();
        }

        private async Task LoadEmployees()
        {
            lstEmployees.Items.Clear();

            GetData get = new GetData(DataAccess.APIs.SystemManagement, "User/GetUsers");
            MultiMap<string, string> queryString = new MultiMap<string, string>();
            foreach (Employee employee in _employees)
            {
                queryString.Add("userids", employee.UserID.ToString());
            }

            get.QueryString = queryString;
            List<User> users = await get.GetObject<List<User>>();

            Dictionary<long, User> usersByUserID = new Dictionary<long, User>();
            if (users != null)
            {
                usersByUserID = users.ToDictionary(u => u.UserID);
            }

            foreach(Employee employee in _employees)
            {
                ListViewItem item = new ListViewItem();
                item.Text = usersByUserID.GetOrDefault(employee.UserID)?.Username;
                item.Tag = employee;
                item.ImageKey = "user";
                item.SubItems.Add(employee.ManageEmails.ToString());
                item.SubItems.Add(employee.ManageEmployees.ToString());

                lstEmployees.Items.Add(item);
            }

            BringToFront();
        }

        private async void cmdSelectEmployees_Click(object sender, EventArgs e)
        {
            frmSelectUsers selectUsers = new frmSelectUsers();
            selectUsers.SelectedUserIDs = _employees.Select(emp => emp.UserID).ToList();
            DialogResult res = selectUsers.ShowDialog();

            if (res != DialogResult.OK)
            {
                return;
            }

            foreach(long newUserID in selectUsers.SelectedUserIDs.Except(_employees.Select(emp => emp.UserID)))
            {
                Employee employee = new Employee();
                employee.UserID = newUserID;

                _employees.Add(employee);
            }

            _employees.RemoveAll(emp => !selectUsers.SelectedUserIDs.Contains(emp.UserID));

            Enabled = false;
            await LoadEmployees();
            Enabled = true;

            BringToFront();
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Name is a required field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Company company = new Company()
            {
                Name = txtName.Text
            };

            PostData post = new PostData(DataAccess.APIs.SystemManagement, "Company/PostCompany", company);
            company = await post.Execute<Company>();

            if (!post.RequestSuccessful)
            {
                return;
            }

            bool employeeSaveSuccessful = true;
            foreach(Employee employee in _employees)
            {
                employee.CompanyID = company.CompanyID;

                post = new PostData(DataAccess.APIs.SystemManagement, "Company/PostEmployee", employee);
                await post.ExecuteNoResult();

                if (!post.RequestSuccessful)
                {
                    employeeSaveSuccessful = false;
                }
            }

            if (!employeeSaveSuccessful)
            {
                MessageBox.Show("The Company save was successful, but at least one Employee did not save successfully.  Recommend reviewing employees and trying again through the Employee Edit screen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DialogResult = DialogResult.OK;

            Close();
        }
    }
}

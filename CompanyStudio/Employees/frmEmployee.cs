using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompanyStudio.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Utility;

namespace CompanyStudio.Employees
{
    public partial class frmEmployee : BaseCompanyStudioContent
    {
        public event EventHandler OnSave;
        public Employee Employee { get; set; }
        public frmEmployee()
        {
            InitializeComponent();
        }

        private bool closeOnShown = false;
        private async void frmEmployee_Load(object sender, EventArgs e)
        {
            if (Company == null || Company.CompanyID == 0)
            {
                MessageBox.Show("You must select a company.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                closeOnShown = true;
                return;
            }

            PermissionsManager.OnPermissionChange += PermissionsManager_OnPermissionChange;

            GetData get = new GetData(DataAccess.APIs.CompanyStudio, "Employee/GetCandidates");
            get.Headers.Add("CompanyID", Company.CompanyID.ToString());

            List<User> users = await get.GetObject<List<User>>();
            if (users != null)
            {
                foreach(User user in users)
                {
                    cboEmployees.Items.Add(DropDownItem.Create(user, user.Username));
                }
            }

            if (Employee == null)
            {
                Text += " - New";
            }
            else
            {
                Text += " - " + Employee.EmployeeName;
                cboEmployees.Enabled = false;
                cboEmployees.Items.Add(new DropDownItem<User>(new User() { UserID = Employee.UserID, Username = Employee.EmployeeName }, Employee.EmployeeName));
                cboEmployees.SelectedIndex = 0;
                chkManageEmails.Checked = Employee.ManageEmails;
                chkManageEmployees.Checked = Employee.ManageEmployees;

                IsDirty = false;
            }
        }

        private void PermissionsManager_OnPermissionChange(object sender, PermissionsManager.PermissionChangeEventArgs e)
        {
            if (Company.CompanyID == e.CompanyID && e.Permission == PermissionsManager.Permissions.ManageEmployees && !e.Value)
            {
                IsDirty = false;
                Close();
            }
        }

        private void frmEmployee_Shown(object sender, EventArgs e)
        {
            if (closeOnShown)
            {
                Close();
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            IsDirty = true;
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            if (cboEmployees.SelectedItem == null)
            {
                MessageBox.Show("User is a required field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            loader.BringToFront();
            loader.Visible = true;

            if (Employee == null)
            {
                Employee = new Employee();
                Employee.CompanyID = Company.CompanyID;
            }

            Employee.UserID = ((DropDownItem<User>)cboEmployees.SelectedItem).Object.UserID;
            Employee.ManageEmails = chkManageEmails.Checked;
            Employee.ManageEmployees = chkManageEmployees.Checked;

            if (Employee.EmployeeID == default)
            {
                PostData post = new PostData(DataAccess.APIs.CompanyStudio, "Employee/Post");
                post.Headers.Add("CompanyID", Company.CompanyID.ToString());
                post.ObjectToPost = Employee;
                Employee savedEmployee = await post.Execute<Employee>();
                if (post.RequestSuccessful)
                {
                    IsDirty = false;
                    Employee = savedEmployee;
                    Text = Text.Substring(0, Text.LastIndexOf("-") + 2) + Employee.EmployeeName;
                    OnSave?.Invoke(this, new EventArgs());
                }
            }
            else
            {
                PutData put = new PutData(DataAccess.APIs.CompanyStudio, "Employee/Put", Employee);
                put.Headers.Add("CompanyID", Company.CompanyID.ToString());
                Employee savedEmployee = await put.Execute<Employee>();
                if (put.RequestSuccessful)
                {
                    IsDirty = false;
                    Employee = savedEmployee;
                    Text = Text.Substring(0, Text.LastIndexOf("-") + 2) + Employee.EmployeeName;
                    OnSave?.Invoke(this, new EventArgs());
                }
            }

            loader.Visible = false;
        }

        private void frmEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            PermissionsManager.OnPermissionChange -= PermissionsManager_OnPermissionChange;
        }
    }
}

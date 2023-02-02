using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CompanyStudio.Extensions;
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

            PermissionsManager.OnCompanyPermissionChange += PermissionsManager_OnPermissionChange;

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
                cboEmployees.Items.Insert(0, new DropDownItem<User>(new User() { UserID = Employee.UserID, Username = Employee.EmployeeName }, Employee.EmployeeName));
                cboEmployees.SelectedIndex = 0;
                chkManageEmails.Checked = Employee.ManageEmails;
                chkManageEmployees.Checked = Employee.ManageEmployees;
                chkManageAccounts.Checked = Employee.ManageAccounts;
                chkManageLocations.Checked = Employee.ManageLocations;
                chkIssueWireTransfers.Checked = Employee.IssueWireTransfers;
                chkFleetSetup.Checked = Employee.FleetSecurity.AllowSetup;
                chkFleetLeasing.Checked = Employee.FleetSecurity.AllowLeasingManagement;
                chkFleetYardmaster.Checked = Employee.FleetSecurity.IsYardmaster;
                chkFleetTrainCrew.Checked = Employee.FleetSecurity.IsTrainCrew;
                chkFleetLoadUnload.Checked = Employee.FleetSecurity.AllowLoadUnload;

                IsDirty = false;
            }
        }

        private void PermissionsManager_OnPermissionChange(object sender, PermissionsManager.CompanyWidePermissionChangeEventArgs e)
        {
            if (Company.CompanyID == e.CompanyID && e.Permission == PermissionsManager.CompanyWidePermissions.ManageEmployees && !e.Value)
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
            Employee.ManageAccounts = chkManageAccounts.Checked;
            Employee.ManageLocations = chkManageLocations.Checked;
            Employee.IssueWireTransfers = chkIssueWireTransfers.Checked;

            bool saveSuccess;
            Employee savedEmployee;
            if (Employee.EmployeeID == default)
            {
                PostData post = new PostData(DataAccess.APIs.CompanyStudio, "Employee/Post");
                post.Headers.Add("CompanyID", Company.CompanyID.ToString());
                post.ObjectToPost = Employee;
                savedEmployee = await post.Execute<Employee>();
                saveSuccess = post.RequestSuccessful;
            }
            else
            {
                PutData put = new PutData(DataAccess.APIs.CompanyStudio, "Employee/Put", Employee);
                put.Headers.Add("CompanyID", Company.CompanyID.ToString());
                savedEmployee = await put.Execute<Employee>();
                saveSuccess = put.RequestSuccessful;
            }

            if (saveSuccess)
            {
                FleetTracking.Models.FleetSecurity security = new FleetTracking.Models.FleetSecurity()
                {
                    EmployeeID = savedEmployee.EmployeeID,
                    AllowSetup = chkFleetSetup.Checked,
                    AllowLeasingManagement = chkFleetLeasing.Checked,
                    IsYardmaster = chkFleetYardmaster.Checked,
                    IsTrainCrew = chkFleetTrainCrew.Checked,
                    AllowLoadUnload = chkFleetLoadUnload.Checked
                };

                PutData put = new PutData(DataAccess.APIs.CompanyStudio, "Employee/PutFleetSecurity", security);
                put.AddCompanyHeader(Company.CompanyID);
                await put.ExecuteNoResult();
                if (put.RequestSuccessful)
                {
                    GetData get = new GetData(DataAccess.APIs.CompanyStudio, $"Employee/Get/{savedEmployee.EmployeeID}");
                    get.AddCompanyHeader(Company.CompanyID);

                    Employee = await get.GetObject<Employee>();
                    IsDirty = false;
                    Text = Text.Substring(0, Text.LastIndexOf("-") + 2) + Employee.EmployeeName;
                    OnSave?.Invoke(this, new EventArgs());
                    cboEmployees.Enabled = false;
                }
            }

            loader.Visible = false;
        }

        private void frmEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            PermissionsManager.OnCompanyPermissionChange -= PermissionsManager_OnPermissionChange;
        }
    }
}

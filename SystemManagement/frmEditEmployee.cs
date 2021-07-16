using MesaSuite.Common.Collections;
using MesaSuite.Common.Data;
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
    public partial class frmEditEmployee : Form
    {
        public Employee Employee { get; set; }
        public string CompanyNameOverride { get; set; }
        public bool PerformDatabaseSave { get; set; } = true;

        public frmEditEmployee()
        {
            InitializeComponent();
        }

        private async void frmEditEmployee_Load(object sender, EventArgs e)
        {
            GetData getData = null;
            if (string.IsNullOrEmpty(CompanyNameOverride))
            {
                getData = new GetData(DataAccess.APIs.SystemManagement, "Company/GetCompany");
                getData.QueryString = new MultiMap<string, string>()
                {
                    { "id", Employee.CompanyID.ToString() }
                };
                Company company = await getData.GetObject<Company>();
                txtCompany.Text = company?.Name;
            }
            else
            {
                txtCompany.Text = CompanyNameOverride;
            }

            getData = new GetData(DataAccess.APIs.SystemManagement, "User/GetUser");
            getData.QueryString = new MultiMap<string, string>()
            {
                { "userid", Employee.UserID.ToString() }
            };
            User user = await getData.GetObject<User>();

            if (user != null)
            {
                txtEmployee.Text = user.Username;
            }

            chkManageEmails.Checked = Employee.ManageEmails;
            chkManageEmployees.Checked = Employee.ManageEmployees;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            Employee.ManageEmails = chkManageEmails.Checked;
            Employee.ManageEmployees = chkManageEmployees.Checked;

            if (PerformDatabaseSave)
            {
                PutData put = new PutData(DataAccess.APIs.SystemManagement, "Company/PutEmployee", Employee);
                await put.ExecuteNoResult();

                if (!put.RequestSuccessful)
                {
                    return;
                }
            }

            DialogResult = DialogResult.OK;

            Close();
        }
    }
}

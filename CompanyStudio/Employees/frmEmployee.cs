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

            if (Employee == null)
            {
                Text += "- New";
            }
            else
            {
                cboEmployees.Enabled = false;
                txtEmployee.Text = Employee.EmployeeName;
                chkManageEmails.Checked = Employee.ManageEmails;
                chkManageEmployees.Checked = Employee.ManageEmployees;
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

        private void cmdSave_Click(object sender, EventArgs e)
        {
            
        }
    }
}

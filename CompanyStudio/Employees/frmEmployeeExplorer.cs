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

namespace CompanyStudio.Employees
{
    public partial class frmEmployeeExplorer : BaseCompanyStudioContent
    {
        public frmEmployeeExplorer()
        {
            InitializeComponent();
            OnThemeChange += OnThemeChanged;
        }

        private bool closeOnShown = false;
        private void frmEmployeeExplorer_Load(object sender, EventArgs e)
        {
            if (Company == null || Company.CompanyID == 0)
            {
                MessageBox.Show("You must select a company.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                closeOnShown = true;
                return;
            }

            Text += $" - {Company.Name.Replace("&", "&&")}";

            RefreshEmployeeExplorer();
        }

        private void frmEmployeeExplorer_Shown(object sender, EventArgs e)
        {
            if (closeOnShown)
            {
                Close();
            }
        }

        private void OnThemeChanged(object sender, WeifenLuo.WinFormsUI.Docking.ThemeBase e)
        {
            toolStripExtender.SetStyle(toolStrip, WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender.VsVersion.Vs2015, e);
        }

        public async void RefreshEmployeeExplorer()
        {
            loader.BringToFront();
            loader.Visible = true;

            treEmployees.Nodes.Clear();

            GetData get = new GetData(DataAccess.APIs.CompanyStudio, "Employee/GetByCompanyID");
            get.Headers.Add("CompanyID", Company.CompanyID.ToString());

            List<Employee> employees = await get.GetObject<List<Employee>>();
            if (employees != null)
            {
                foreach(Employee employee in employees.OrderBy(e => e.EmployeeName))
                {
                    TreeNode employeeNode = new TreeNode(employee.EmployeeName);
                    treEmployees.Nodes.Add(employeeNode);
                }
            }

            loader.Visible = false;
        }
    }
}

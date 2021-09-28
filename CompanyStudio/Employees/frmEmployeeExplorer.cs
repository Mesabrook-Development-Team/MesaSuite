using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompanyStudio.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;

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

        public async Task RefreshEmployeeExplorer()
        {
            loader.BringToFront();
            loader.Visible = true;

            treEmployees.Nodes.Clear();

            GetData get = new GetData(DataAccess.APIs.CompanyStudio, "Employee/GetAllForCompany");
            get.Headers.Add("CompanyID", Company.CompanyID.ToString());

            List<Employee> employees = await get.GetObject<List<Employee>>();
            if (employees != null)
            {
                foreach(Employee employee in employees.OrderBy(e => e.EmployeeName))
                {
                    TreeNode employeeNode = new TreeNode(employee.EmployeeName);
                    employeeNode.Tag = employee;
                    treEmployees.Nodes.Add(employeeNode);

                    TreeNode permissionsNode = new TreeNode("Permissions");
                    employeeNode.Nodes.Add(permissionsNode);

                    TreeNode manageEmployees = new TreeNode($"Manage Employees - {employee.ManageEmployees}");
                    manageEmployees.ContextMenuStrip = ctxPermission;
                    manageEmployees.Tag = nameof(Employee.ManageEmployees);
                    permissionsNode.Nodes.Add(manageEmployees);

                    TreeNode manageEmails = new TreeNode($"Manage Emails - {employee.ManageEmails}");
                    manageEmails.ContextMenuStrip = ctxPermission;
                    manageEmails.Tag = nameof(Employee.ManageEmails);
                    permissionsNode.Nodes.Add(manageEmails);
                }
            }

            loader.Visible = false;
        }

        private async void mnuTogglePermission_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = treEmployees.SelectedNode;
            string path = currentNode.FullPath;
            if (currentNode == null || !(currentNode.Parent?.Parent?.Tag is Employee employee) || !(currentNode.Tag is string property))
            {
                return;
            }

            path = path.Substring(0, path.LastIndexOf("\\"));

            PropertyInfo propertyInfo = typeof(Employee).GetProperty(property);
            bool value = (bool)propertyInfo.GetValue(employee);

            PatchData patchData = new PatchData(DataAccess.APIs.CompanyStudio, "Employee/Patch", PatchData.PatchMethods.Replace, employee.EmployeeID, new Dictionary<string, object>()
            {
                { property, !value }
            });
            patchData.Headers.Add("CompanyID", Company.CompanyID.ToString());

            loader.BringToFront();
            loader.Visible = true;
            await patchData.Execute();
            if (!patchData.RequestSuccessful)
            {
                loader.Visible = false;
                return;
            }
            else
            {
                await RefreshEmployeeExplorer();
                treEmployees.SelectedNode = treEmployees.Nodes.FindByPath(path);
                treEmployees.SelectedNode?.Expand();
            }
        }

        private void treEmployees_AfterSelect(object sender, TreeViewEventArgs e)
        {
            mnuAddEmployee.Enabled = e.Node != null;
            mnuRemoveEmployee.Enabled = e.Node != null;
        }

        private async void mnuRemoveEmployee_Click(object sender, EventArgs e)
        {
            if (treEmployees.SelectedNode == null || MessageBox.Show("Are you sure you want to delete this Employee?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            TreeNode parentNode = treEmployees.SelectedNode;
            while(parentNode.Parent != null)
            {
                parentNode = parentNode.Parent;
            }

            Employee employee = (Employee)parentNode.Tag;

            DeleteData deleteData = new DeleteData(DataAccess.APIs.CompanyStudio, "Employee/Delete");
            deleteData.Headers.Add("CompanyID", Company.CompanyID.ToString());
            deleteData.QueryString.Add("id", employee.EmployeeID.ToString());

            loader.BringToFront();
            loader.Visible = true;

            await deleteData.Execute();

            if (deleteData.RequestSuccessful)
            {
                RefreshEmployeeExplorer();
            }
            else
            {
                loader.Visible = false;
            }
        }
    }
}

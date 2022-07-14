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

            PermissionsManager.OnCompanyPermissionChange += PermissionsManager_OnPermissionChange;

            Text += $" - {Company.Name.Replace("&", "&&")}";

            RefreshEmployeeExplorer();
        }

        private void PermissionsManager_OnPermissionChange(object sender, PermissionsManager.CompanyWidePermissionChangeEventArgs e)
        {
            if (Company.CompanyID == e.CompanyID && e.Permission == PermissionsManager.CompanyWidePermissions.ManageEmployees && !e.Value)
            {
                MessageBox.Show($"You do not have access to Employee Explorer for {Company.Name}", "No Permission", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Close();
            }
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
                    employeeNode.ContextMenuStrip = ctxEmployee;
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

                    TreeNode manageAccounts = new TreeNode($"Manage Accounts - {employee.ManageAccounts}");
                    manageAccounts.ContextMenuStrip = ctxPermission;
                    manageAccounts.Tag = nameof(Employee.ManageAccounts);
                    permissionsNode.Nodes.Add(manageAccounts);

                    TreeNode manageLocations = new TreeNode($"Manage Locations - {employee.ManageLocations}");
                    manageLocations.ContextMenuStrip = ctxPermission;
                    manageLocations.Tag = nameof(Employee.ManageLocations);
                    permissionsNode.Nodes.Add(manageLocations);

                    TreeNode issueWireTransfers = new TreeNode($"Issue Wire Transfers - {employee.IssueWireTransfers}");
                    issueWireTransfers.ContextMenuStrip = ctxPermission;
                    issueWireTransfers.Tag = nameof(Employee.IssueWireTransfers);
                    permissionsNode.Nodes.Add(issueWireTransfers);
                }
            }

            loader.Visible = false;
        }

        private async void mnuTogglePermission_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = treEmployees.SelectedNode;
            if (currentNode == null || !(currentNode.Parent?.Parent?.Tag is Employee employee) || !(currentNode.Tag is string property))
            {
                return;
            }
            string path = currentNode.FullPath;

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
            mnuRemoveEmployee.Enabled = e.Node != null;
        }

        private async void mnuRemoveEmployee_Click(object sender, EventArgs e)
        {
            await RemoveEmployee();
        }

        private async Task RemoveEmployee()
        {
            if (treEmployees.SelectedNode == null || MessageBox.Show("Are you sure you want to fire this Employee?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            TreeNode parentNode = treEmployees.SelectedNode;
            while (parentNode.Parent != null)
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

        private void mnuAddEmployee_Click(object sender, EventArgs e)
        {
            AddEmployee();
        }

        private void AddEmployee()
        {
            frmEmployee employee = new frmEmployee();
            Studio.DecorateStudioContent(employee);
            employee.Company = Company;
            employee.OnSave += ChildForm_Save;
            employee.Show(Studio.dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        private async void ChildForm_Save(object sender, EventArgs e)
        {
            await RefreshEmployeeExplorer();
        }

        private void treEmployees_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode parentNode = e.Node;

            while(parentNode.Parent != null)
            {
                parentNode = parentNode.Parent;
            }

            Employee employee = (Employee)parentNode.Tag;

            frmEmployee editEmployee = new frmEmployee();
            editEmployee.Employee = employee;
            Studio.DecorateStudioContent(editEmployee);
            editEmployee.Company = Company;
            editEmployee.OnSave += ChildForm_Save;
            editEmployee.Show(Studio.dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        private void ctxAddEmployee_Click(object sender, EventArgs e)
        {
            AddEmployee();
        }

        private void ctxDeleteEmployee_Click(object sender, EventArgs e)
        {
            RemoveEmployee();
        }

        private void ctxEmployee_Opening(object sender, CancelEventArgs e)
        {
            ctxDeleteEmployee.Visible = treEmployees.SelectedNode != null && treEmployees.SelectedNode.Parent == null;
        }

        private void frmEmployeeExplorer_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnThemeChange -= OnThemeChanged;
            PermissionsManager.OnCompanyPermissionChange -= PermissionsManager_OnPermissionChange;
        }
    }
}

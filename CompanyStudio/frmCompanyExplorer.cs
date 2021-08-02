using CompanyStudio.Models;
using MesaSuite.Common.Collections;
using MesaSuite.Common.Data;
using System;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CompanyStudio
{
    public partial class frmCompanyExplorer : BaseCompanyStudioContent
    {
        public frmCompanyExplorer()
        {
            InitializeComponent();
            OnStudioChange += OnStudioChangeHandler;
            OnThemeChange += OnThemeChanged;
            //imlSmall.Images.Add("company");
        }

        private void OnThemeChanged(object sender, ThemeBase e)
        {
            visualStudioToolStripExtender.SetStyle(toolStrip1, VisualStudioToolStripExtender.VsVersion.Vs2015, e);
        }

        private void OnStudioChangeHandler(object sender, System.EventArgs e)
        {
            if (Studio != null)
            {
                Studio.OnCompanyAdded += Studio_OnCompanyChanged;
                Studio.OnCompanyRemoved += Studio_OnCompanyChanged;
            }
        }

        private void Studio_OnCompanyChanged(object sender, Company e)
        {
            SetupCompanies();
        }

        private void frmCompanyExplorer_Load(object sender, System.EventArgs e)
        {
            SetupCompanies();
        }

        private async void SetupCompanies()
        {
            loader.BringToFront();
            loader.Visible = true;
            lstCompanies.Items.Clear();

            foreach(Company company in Studio.Companies)
            {
                GetData get = new GetData(DataAccess.APIs.CompanyStudio, "Employee/GetForCompany");
                get.QueryString = new MultiMap<string, string>()
                {
                    { "id", company.CompanyID.ToString() }
                };

                Employee employee = await get.GetObject<Employee>();

                if (employee != null)
                {
                    ListViewItem item = new ListViewItem(company.Name);
                    item.Tag = (company, employee);
                    item.SubItems.Add(employee.ManageEmails.ToString());
                    item.SubItems.Add(employee.ManageEmployees.ToString());

                    lstCompanies.Items.Add(item);
                }
            }

            if (Studio.ActiveCompany == null && lstCompanies.Items.Count > 0)
            {
                Studio.ActiveCompany = ((ValueTuple<Company, Employee>)lstCompanies.Items[0].Tag).Item1;
                lstCompanies.Items[0].Selected = true;
            }

            loader.Visible = false;
        }

        private void mnuConnect_Click(object sender, System.EventArgs e)
        {
            Studio.GetForm<frmCompanyConnect>().Show();
        }

        private void mnuDisconnect_Click(object sender, System.EventArgs e)
        {
            if (lstCompanies.SelectedItems.Count > 0)
            {
                Company company = ((ValueTuple<Company, Employee>)lstCompanies.SelectedItems[0].Tag).Item1;
                Studio.RemoveCompany(company);

                mnuDisconnect.Enabled = lstCompanies.SelectedItems.Count > 0;
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            disconnectToolStripMenuItem.Enabled = lstCompanies.SelectedItems.Count > 0;
        }

        private void connectToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Studio.GetForm<frmCompanyConnect>().Show();
        }

        private void disconnectToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            mnuDisconnect.PerformClick();
        }

        private void lstCompanies_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            mnuDisconnect.Enabled = lstCompanies.SelectedItems.Count > 0;

            if (lstCompanies.SelectedItems.Count > 0)
            {
                Company company = ((ValueTuple<Company, Employee>)lstCompanies.SelectedItems[0].Tag).Item1;
                Studio.ActiveCompany = company;
            }
        }
    }
}

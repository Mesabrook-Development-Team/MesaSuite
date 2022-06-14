using CompanyStudio.Models;
using MesaSuite.Common.Collections;
using MesaSuite.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CompanyStudio.Email
{
    public partial class frmEmailExplorer : BaseCompanyStudioContent
    {
        public frmEmailExplorer()
        {
            InitializeComponent();
            OnThemeChange += OnThemeChanged;
        }

        private bool closeOnShown = false;
        private async void frmEmailExplorer_Load(object sender, EventArgs e)
        {
            if (Company == null || Company.CompanyID == 0)
            {
                MessageBox.Show("You must select a company.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                closeOnShown = true;
                return;
            }

            if (string.IsNullOrEmpty(Company.EmailDomain))
            {
                MessageBox.Show("Your company does not have an email domain.  Please contact a System Administrator to set this up for you.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                closeOnShown = true;
                return;
            }

            Text += $" - {Company.Name.Replace("&", "&&")}";

            PermissionsManager.OnCompanyPermissionChange += PermissionsManager_OnPermissionChange;

            await RefreshEmailExplorer();
        }


        private void OnThemeChanged(object sender, ThemeBase e)
        {
            visualStudioToolStripExtender.SetStyle(toolStrip, VisualStudioToolStripExtender.VsVersion.Vs2015, e);
        }

        private void PermissionsManager_OnPermissionChange(object sender, PermissionsManager.CompanyWidePermissionChangeEventArgs e)
        {
            if (Company.CompanyID == e.CompanyID && e.Permission == PermissionsManager.CompanyWidePermissions.ManageEmails && !e.Value)
            {
                MessageBox.Show($"You do not have access to Email Explorer for {Company.Name}", "No Permission", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Close();
            }
        }

        public async Task RefreshEmailExplorer()
        {
            loader.BringToFront();
            loader.Visible = true;

            treEmailExplorer.Nodes["nodAliases"].Nodes.Clear();
            treEmailExplorer.Nodes["nodDistLists"].Nodes.Clear();

            GetData get = new GetData(DataAccess.APIs.CompanyStudio, "Alias/GetByDomainName");
            get.QueryString = new MultiMap<string, string>()
            {
                { "domainName", Company.EmailDomain }
            };
            get.Headers = new Dictionary<string, string>()
            {
                { "CompanyID", Company.CompanyID.ToString() }
            };

            List<Alias> aliases = await get.GetObject<List<Alias>>();

            if (aliases != null)
            {
                foreach (Alias alias in aliases)
                {
                    TreeNode node = new TreeNode($"{alias.AliasName} -> {alias.AliasValue}");
                    node.Tag = alias;
                    treEmailExplorer.Nodes["nodAliases"].Nodes.Add(node);
                }
            }

            get = new GetData(DataAccess.APIs.CompanyStudio, "DistributionList/GetByDomainName");
            get.QueryString = new MultiMap<string, string>()
            {
                { "domainName", Company.EmailDomain }
            };
            get.Headers = new Dictionary<string, string>()
            {
                { "CompanyID", Company.CompanyID.ToString() }
            };

            List<DistributionList> distributionLists = await get.GetObject<List<DistributionList>>();

            if (distributionLists != null)
            {
                foreach (DistributionList list in distributionLists)
                {
                    string nodeText = $"{list.DistributionListAddress} ({list.Mode})";
                    if (list.DistributionListMode == 2)
                    {
                        nodeText += " (Sent By: " + list.DistributionListRequireAddress + ")";
                    }

                    TreeNode node = new TreeNode(nodeText);
                    node.Tag = list;

                    get = new GetData(DataAccess.APIs.CompanyStudio, "DistributionListRecipient/GetByDistributionListID");
                    get.QueryString = new MultiMap<string, string>()
                    {
                        { "id", list.DistributionListID.ToString() }
                    };
                    get.Headers = new Dictionary<string, string>()
                    {
                        { "CompanyID", Company.CompanyID.ToString() }
                    };

                    List<DistributionListRecipient> recipients = await get.GetObject<List<DistributionListRecipient>>();

                    if (recipients != null)
                    {
                        foreach (DistributionListRecipient recipient in recipients)
                        {
                            TreeNode childNode = new TreeNode(recipient.DistributionListRecipientAddress);
                            childNode.Tag = recipient;
                            node.Nodes.Add(childNode);
                        }
                    }

                    treEmailExplorer.Nodes["nodDistLists"].Nodes.Add(node);
                }
            }

            loader.Visible = false;
        }

        private void frmEmailExplorer_Shown(object sender, EventArgs e)
        {
            if (closeOnShown)
            {
                Close();
            }
        }

        private void toolAddAlias_Click(object sender, EventArgs e)
        {
            frmAlias alias = new frmAlias();
            Studio.DecorateStudioContent(alias);
            alias.Company = Company;
            alias.Text += " - New";
            alias.OnSave += ChildForm_OnSave;
            alias.Show(Studio.dockPanel, DockState.Document);
        }

        private void treEmailExplorer_DoubleClick(object sender, EventArgs e)
        {
            if (treEmailExplorer.SelectedNode == null)
            {
                return;
            }

            TreeNode currentNode = treEmailExplorer.SelectedNode;
            if (currentNode.Tag is Alias alias)
            {
                frmAlias aliasForm = new frmAlias();
                Studio.DecorateStudioContent(aliasForm);
                aliasForm.Company = Company;
                aliasForm.Alias = alias;
                aliasForm.OnSave += ChildForm_OnSave;
                aliasForm.Show(Studio.dockPanel, DockState.Document);
            }

            if (currentNode.Tag is DistributionList distributionList)
            {
                frmDistributionList distributionListForm = new frmDistributionList();
                Studio.DecorateStudioContent(distributionListForm);
                distributionListForm.Company = Company;
                distributionListForm.DistributionList = distributionList;
                distributionListForm.OnSave += ChildForm_OnSave;
                distributionListForm.Show(Studio.dockPanel, DockState.Document);
            }
        }

        private  void treEmailExplorer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                TreeNode selectedNode = treEmailExplorer.SelectedNode;

                if (selectedNode == null)
                {
                    return;
                }

                if (selectedNode.Tag is Alias alias && MessageBox.Show("Are you sure you want to delete this alias?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    mnuDeleteAlias_Click(sender, e);
                    return;
                }

                if (selectedNode.Tag is DistributionList distList && MessageBox.Show("Are you sure you want to delete this distribution list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    mnuDeleteDistList_Click(sender, e);
                }

                if (selectedNode.Tag is DistributionListRecipient recipient && MessageBox.Show("Are you sure you want to delete this distribution list recipient?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    mnuDeleteRecipient_Click(sender, e);
                }
            }
        }

        private void toolAddDistList_Click(object sender, EventArgs e)
        {
            frmDistributionList distList = new frmDistributionList();
            Studio.DecorateStudioContent(distList);
            distList.Company = Company;
            distList.OnSave += ChildForm_OnSave;

            distList.Show(Studio.dockPanel, DockState.Document);
        }

        private async void ChildForm_OnSave(object sender, EventArgs e)
        {
            await RefreshEmailExplorer();
        }

        private void ctxEmailExplorer_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach(ToolStripMenuItem item in ctxEmailExplorer.Items.OfType<ToolStripMenuItem>())
            {
                item.Visible = false;
            }

            TreeNode currentNode = treEmailExplorer.SelectedNode;
            if (currentNode == null || currentNode.Tag == null)
            {
                mnuAddAlias.Visible = true;
                mnuAddDistList.Visible = true;
                separator.Visible = false;
                return;
            }

            separator.Visible = true;

            if (currentNode.Tag is Alias)
            {
                mnuAddAlias.Visible = true;
                mnuDeleteAlias.Visible = true;
            }

            if (currentNode.Tag is DistributionList || currentNode.Tag is DistributionListRecipient)
            {
                mnuAddDistList.Visible = true;
                mnuAddRecipient.Visible = true;
                mnuDeleteDistList.Visible = true;
            }

            if (currentNode.Tag is DistributionListRecipient)
            {
                mnuDeleteRecipient.Visible = true;
            }
        }

        private void mnuAddAlias_Click(object sender, EventArgs e)
        {
            toolAddAlias.PerformClick();
        }

        private void mnuAddDistList_Click(object sender, EventArgs e)
        {
            toolAddDistList.PerformClick();
        }

        private void mnuDeleteAlias_Click(object sender, EventArgs e)
        {
            Alias alias = (Alias)treEmailExplorer.SelectedNode.Tag;
            DeleteItem("Alias", alias.AliasID);

            foreach(frmAlias frmAlias in Studio.dockPanel.Documents.OfType<frmAlias>().ToList())
            {
                if (frmAlias.Alias != null && frmAlias.Alias.AliasID == alias.AliasID)
                {
                    frmAlias.Close();
                }
            }
        }

        private void mnuDeleteDistList_Click(object sender, EventArgs e)
        {
            DistributionList distributionList = (DistributionList)treEmailExplorer.SelectedNode.Tag;
            DeleteItem("DistributionList", distributionList.DistributionListID);

            foreach(frmDistributionList frmDistList in Studio.dockPanel.Documents.OfType<frmDistributionList>().ToList())
            {
                if (frmDistList.DistributionList != null && frmDistList.DistributionList.DistributionListID == distributionList.DistributionListID)
                {
                    frmDistList.Close();
                }
            }
        }

        private void mnuDeleteRecipient_Click(object sender, EventArgs e)
        {
            DistributionListRecipient distributionListRecipient = (DistributionListRecipient)treEmailExplorer.SelectedNode.Tag;
            DeleteItem("DistributionListRecipient", distributionListRecipient.DistributionListRecipientID);
        }

        private async void mnuAddRecipient_Click(object sender, EventArgs e)
        {
            DistributionList distributionList;
            if (treEmailExplorer.SelectedNode.Tag is DistributionList list)
            {
                distributionList = list;
            }
            else
            {
                distributionList = (DistributionList)treEmailExplorer.SelectedNode.Parent.Tag;
            }

            frmAddRecipient addRecipient = new frmAddRecipient();
            Studio.DecorateStudioContent(addRecipient);
            addRecipient.DistributionListID = distributionList.DistributionListID;
            addRecipient.Company = Company;

            if (addRecipient.ShowDialog() == DialogResult.OK)
            {
                await RefreshEmailExplorer();
            }
        }

        private async void DeleteItem(string type, int id)
        {
            DeleteData delete = new DeleteData(DataAccess.APIs.CompanyStudio, $"{type}/Delete");
            delete.Headers.Add("companyid", Company.CompanyID.ToString());
            delete.QueryString.Add("id", id.ToString());
            await delete.Execute();

            await RefreshEmailExplorer();
        }

        private void frmEmailExplorer_FormClosed(object sender, FormClosedEventArgs e)
        {
            PermissionsManager.OnCompanyPermissionChange -= PermissionsManager_OnPermissionChange;
            OnThemeChange -= OnThemeChanged;
        }
    }
}

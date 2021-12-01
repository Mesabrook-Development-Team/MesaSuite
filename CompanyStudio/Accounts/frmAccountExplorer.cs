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
using MesaSuite.Common;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;

namespace CompanyStudio.Accounts
{
    public partial class frmAccountExplorer : BaseCompanyStudioContent
    {
        private List<Account> accounts = new List<Account>();
        private List<Category> categories = new List<Category>();

        private ViewOptions viewOptions = ViewOptions.AccountNumber | ViewOptions.Description;
        private Dictionary<ToolStripMenuItem, ViewOptions> viewOptionByMenuItem = new Dictionary<ToolStripMenuItem, ViewOptions>();
        private SortOptions sortOptions = SortOptions.Description;
        private Dictionary<ToolStripMenuItem, SortOptions> sortOptionByMenuItem = new Dictionary<ToolStripMenuItem, SortOptions>();
        private GroupOptions groupOptions = GroupOptions.None;
        private Dictionary<ToolStripMenuItem, GroupOptions> groupOptionByMenuItem = new Dictionary<ToolStripMenuItem, GroupOptions>();

        private string filter;

        private void LinkMenuItemsToOptions()
        {
            viewOptionByMenuItem = new Dictionary<ToolStripMenuItem, ViewOptions>()
            {
                { mnuViewAccountNumber, ViewOptions.AccountNumber },
                { mnuViewDescription, ViewOptions.Description },
                { mnuViewCategory, ViewOptions.Category },
                { mnuViewBalance, ViewOptions.Balance },
                { ctxViewAccountNumber, ViewOptions.AccountNumber },
                { ctxViewDescription, ViewOptions.Description },
                { ctxViewCategory, ViewOptions.Category },
                { ctxViewBalance, ViewOptions.Balance }
            };

            sortOptionByMenuItem = new Dictionary<ToolStripMenuItem, SortOptions>()
            {
                { mnuSortDescription, SortOptions.Description },
                { mnuSortCategory, SortOptions.Category },
                { mnuSortBalance, SortOptions.Balance },
                { ctxSortDescription, SortOptions.Description },
                { ctxSortCategory, SortOptions.Category },
                { ctxSortBalance, SortOptions.Balance }
            };

            groupOptionByMenuItem = new Dictionary<ToolStripMenuItem, GroupOptions>()
            {
                { mnuGroupNone, GroupOptions.None },
                { mnuGroupCategory, GroupOptions.Category },
                { ctxNoGrouping, GroupOptions.None },
                { ctxCategoryGrouping, GroupOptions.Category }
            };
        }

        public frmAccountExplorer()
        {
            InitializeComponent();
            OnThemeChange += OnThemeChanged;

            LinkMenuItemsToOptions();
        }

        private void frmAccountExplorer_Load(object sender, EventArgs e)
        {
            Text += " - " + Company.Name;
            PermissionsManager.OnPermissionChange += PermissionsManager_OnPermissionChange;
            Dictionary<string, object> configValues = UserPreferences.Get().Sections.GetOrDefault("company", new Dictionary<string, object>());
            if (configValues.ContainsKey("accountExplorerLastViewOptions"))
            {
                List<string> viewOptions = configValues["accountExplorerLastViewOptions"].Cast<List<string>>();
                bool isFirst = true;
                foreach(string viewOption in viewOptions)
                {
                    if (!Enum.TryParse(viewOption, true, out ViewOptions enumViewOption))
                    {
                        continue;
                    }

                    if (isFirst)
                    {
                        this.viewOptions = enumViewOption;
                        isFirst = false;
                    }
                    else
                    {
                        this.viewOptions |= enumViewOption;
                    }
                }
            }

            if (configValues.ContainsKey("accountExplorerLastSort") && Enum.TryParse(configValues["accountExplorerLastSort"].Cast<string>(), true, out SortOptions sortOption))
            {
                sortOptions = sortOption;
            }

            if (configValues.ContainsKey("accountExplorerLastGrouping") && Enum.TryParse(configValues["accountExplorerLastGrouping"].Cast<string>(), true, out GroupOptions groupOption))
            {
                groupOptions = groupOption;
            }

            FetchAccounts();
        }

        private void OnThemeChanged(object sender, WeifenLuo.WinFormsUI.Docking.ThemeBase e)
        {
            toolStripExtender.SetStyle(toolStrip1, WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender.VsVersion.Vs2015, Theme);
        }

        private void PermissionsManager_OnPermissionChange(object sender, PermissionsManager.PermissionChangeEventArgs e)
        {
            if (e.CompanyID != Company.CompanyID || e.Permission != PermissionsManager.Permissions.ManageAccounts)
            {
                return;
            }

            if (!e.Value)
            {
                MessageBox.Show($"You do not have access to Account Explorer for {Company.Name}", "No Permission", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Close();
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text.Equals("Search..."))
            {
                txtSearch.Clear();
                txtSearch.ForeColor = SystemColors.WindowText;
                txtSearch.Font = new Font(txtSearch.Font, FontStyle.Regular);
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                txtSearch.Text = "Search...";
                txtSearch.ForeColor = SystemColors.InactiveCaption;
                txtSearch.Font = new Font(txtSearch.Font, FontStyle.Italic);
            }
        }

        private async void FetchAccounts(bool doPopulate = true)
        {
            loader.BringToFront();
            loader.Visible = true;

            GetData get = new GetData(DataAccess.APIs.CompanyStudio, "Account/GetForCompany");
            get.Headers.Add("CompanyID", Company.CompanyID.ToString());
            accounts = await get.GetObject<List<Account>>() ?? new List<Account>();

            get.Resource = "Category/GetForCompany";
            categories = await get.GetObject<List<Category>>() ?? new List<Category>();
            categories = categories.OrderBy(cat => cat.Name).ToList();

            if (doPopulate)
            {
                PopulateTreeView();
            }

            loader.Visible = false;
        }

        private void PopulateTreeView()
        {
            treAccounts.Nodes.Clear();

            Dictionary<long, TreeNode> groupNodeByID = new Dictionary<long, TreeNode>();
            if (groupOptions == GroupOptions.Category)
            {
                foreach(Category category in categories)
                {
                    TreeNode categoryNode = new TreeNode();
                    categoryNode.Text = category.Name;
                    treAccounts.Nodes.Add(categoryNode);

                    groupNodeByID.Add(category.CategoryID, categoryNode);
                }

                TreeNode uncatergorizedNode = new TreeNode();
                uncatergorizedNode.Text = "Uncategorized";
                treAccounts.Nodes.Add(uncatergorizedNode);
                groupNodeByID.Add(0, uncatergorizedNode);
            }

            foreach (Account account in GetSortedAccounts())
            {
                TreeNode accountNode = new TreeNode();
                accountNode.Tag = account;

                StringBuilder accountTextBuilder = new StringBuilder();
                if (viewOptions.HasFlag(ViewOptions.AccountNumber))
                {
                    accountTextBuilder.Append(" - " + account.AccountNumber);
                }

                if (viewOptions.HasFlag(ViewOptions.Description))
                {
                    accountTextBuilder.Append(" - " + account.Description);
                }

                if (viewOptions.HasFlag(ViewOptions.Category))
                {
                    accountTextBuilder.Append(" - " + categories.FirstOrDefault(cat => cat.CategoryID == account.CategoryID)?.Name);
                }

                if (viewOptions.HasFlag(ViewOptions.Balance))
                {
                    accountTextBuilder.Append(" - " + account.Balance.ToString("N2"));
                }

                string accountText = accountTextBuilder.ToString();
                accountText = accountText.Substring(3);

                accountNode.Text = accountText;

                switch(groupOptions)
                {
                    case GroupOptions.None:
                        treAccounts.Nodes.Add(accountNode);
                        break;
                    case GroupOptions.Category:
                        groupNodeByID[account.CategoryID ?? 0].Nodes.Add(accountNode);
                        break;
                }
            }
        }

        private IOrderedEnumerable<Account> GetSortedAccounts()
        {
            Func<Account, object> sortFunc;
            switch(sortOptions)
            {
                case SortOptions.Balance:
                    sortFunc = a => a.Balance;
                    break;
                case SortOptions.Category:
                    sortFunc = a =>
                    {
                        Category category = categories.FirstOrDefault(c => c.CategoryID == a.CategoryID);
                        if (category == null)
                        {
                            return "";
                        }

                        return category.Name;
                    };
                    break;
                case SortOptions.Description:
                    sortFunc = a => a.Description;
                    break;
                default:
                    return accounts.OrderBy(a => a.AccountID);
            }

            return accounts.Where(acc => string.IsNullOrEmpty(filter) || acc.AccountNumber.Contains(filter) || acc.Description.Contains(filter)).OrderBy(sortFunc);
        }

        [Flags]
        private enum ViewOptions
        {
            AccountNumber = 1,
            Description = 2,
            Category = 4,
            Balance = 8
        }

        private enum SortOptions
        {
            Description,
            Category,
            Balance
        }

        private enum GroupOptions
        {
            None,
            Category
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search...")
            {
                filter = "";
            }
            else
            {
                filter = txtSearch.Text;
            }
            PopulateTreeView();
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            txtSearch_Leave(sender, e);
        }

        private void mnuView_DropDownOpening(object sender, EventArgs e)
        {
            foreach(KeyValuePair<ToolStripMenuItem, ViewOptions> kvp in viewOptionByMenuItem)
            {
                kvp.Key.Checked = viewOptions.HasFlag(kvp.Value);
            }
        }

        private void mnuViewColumn_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)e.ClickedItem;
            bool isChecking = !item.Checked;
            ViewOptions option = viewOptionByMenuItem[item];
            item.Checked = isChecking;

            if (isChecking)
            {
                viewOptions = viewOptions | option;
            }
            else
            {
                viewOptions = viewOptions ^ option;
            }

            List<string> lastViewOptions = new List<string>();
            foreach (ViewOptions viewOption in Enum.GetValues(typeof(ViewOptions)))
            {
                if (!viewOptions.HasFlag(viewOption))
                {
                    continue;
                }

                lastViewOptions.Add(viewOption.ToString());
            }

            UserPreferences userPreferences = UserPreferences.Get();
            userPreferences.Sections.GetOrSetDefault("company", new Dictionary<string, object>())["accountExplorerLastViewOptions"] = lastViewOptions;
            userPreferences.Save();

            PopulateTreeView();
        }

        private void mnuSort_DropDownOpening(object sender, EventArgs e)
        {
            foreach(KeyValuePair<ToolStripMenuItem, SortOptions> kvp in sortOptionByMenuItem)
            {
                kvp.Key.Checked = sortOptions == kvp.Value;
            }
        }

        private void mnuSort_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)e.ClickedItem;
            foreach(ToolStripMenuItem subItem in mnuSort.DropDownItems.OfType<ToolStripMenuItem>())
            {
                subItem.Checked = false;
            }
            item.Checked = true;

            sortOptions = sortOptionByMenuItem[item];

            UserPreferences userPreferences = UserPreferences.Get();
            userPreferences.Sections.GetOrSetDefault("company", new Dictionary<string, object>())["accountExplorerLastSort"] = sortOptions.ToString();
            userPreferences.Save();

            PopulateTreeView();
        }

        private void mnuGrouping_DropDownOpening(object sender, EventArgs e)
        {
            foreach (KeyValuePair<ToolStripMenuItem, GroupOptions> kvp in groupOptionByMenuItem)
            {
                kvp.Key.Checked = groupOptions == kvp.Value;
            }
        }

        private void mnuGrouping_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)e.ClickedItem;
            foreach (ToolStripMenuItem subItem in mnuGrouping.DropDownItems.OfType<ToolStripMenuItem>())
            {
                subItem.Checked = false;
            }
            item.Checked = true;

            groupOptions = groupOptionByMenuItem[item];

            UserPreferences userPreferences = UserPreferences.Get();
            userPreferences.Sections.GetOrSetDefault("company", new Dictionary<string, object>())["accountExplorerLastGrouping"] = groupOptions.ToString();
            userPreferences.Save();

            PopulateTreeView();
        }

        private void treAccounts_AfterSelect(object sender, TreeViewEventArgs e)
        {
            mnuCloseAccount.Enabled = e.Node != null;
            ctxClose.Enabled = e.Node != null;
        }

        private void treAccounts_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Account selectedAccount = GetSelectedAccount(e.Node);
            if (selectedAccount == null)
            {
                return;
            }

            frmAccount account = new frmAccount();
            account.Account = selectedAccount;
            Studio.DecorateStudioContent(account);
            account.Company = Company;
            account.OnSave += Account_OnSave;
            account.FormClosed += Account_FormClosed;
            account.Show(Studio.dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        private Account GetSelectedAccount(TreeNode node)
        {
            if (node == null)
            {
                return null;
            }

            while (!(node.Tag is Account))
            {
                node = node.Parent;
                if (node == null)
                {
                    break;
                }
            }

            if (node == null)
            {
                return null;
            }

            return (Account)node.Tag;
        }

        private void Account_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmAccount account = (frmAccount)sender;
            account.OnSave -= Account_OnSave;
            account.FormClosed -= Account_FormClosed;
        }

        private void Account_OnSave(object sender, EventArgs e)
        {
            FetchAccounts();
        }

        private void mnuCreateAccount_Click(object sender, EventArgs e)
        {
            frmAccount account = new frmAccount();
            Studio.DecorateStudioContent(account);
            account.Company = Company;
            account.OnSave += Account_OnSave;
            account.FormClosed += Account_FormClosed;
            account.Show(Studio.dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
        }

        private void mnuCloseAccount_Click(object sender, EventArgs e)
        {
            Account selectedAccount = GetSelectedAccount(treAccounts.SelectedNode);
            if (selectedAccount == null)
            {
                return;
            }

            frmCloseAccount closeAccount = new frmCloseAccount();
            closeAccount.CompanyID = Company.CompanyID;
            closeAccount.Theme = Theme;
            closeAccount.AccountToClose = selectedAccount;
            DialogResult res = closeAccount.ShowDialog();

            if (res != DialogResult.OK)
            {
                return;
            }

            foreach(frmAccount account in Studio.dockPanel.Documents.OfType<frmAccount>().ToList())
            {
                if (account.Account?.AccountID == selectedAccount.AccountID)
                {
                    account.Close();
                }
            }

            FetchAccounts();
        }

        private void frmAccountExplorer_FormClosing(object sender, FormClosingEventArgs e)
        {
            PermissionsManager.OnPermissionChange -= PermissionsManager_OnPermissionChange;
        }
    }
}

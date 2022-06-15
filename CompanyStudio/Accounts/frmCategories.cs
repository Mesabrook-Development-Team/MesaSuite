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
using WeifenLuo.WinFormsUI.Docking;

namespace CompanyStudio.Accounts
{
    public partial class frmCategories : Form
    {
        public Company Company { get; set; }
        public ThemeBase Theme { get; set; }
        public frmCategories()
        {
            InitializeComponent();
            PermissionsManager.OnCompanyPermissionChange += PermissionsManager_OnPermissionChange;
        }

        private void PermissionsManager_OnPermissionChange(object sender, PermissionsManager.CompanyWidePermissionChangeEventArgs e)
        {
            if (e.CompanyID == Company.CompanyID && e.Permission == PermissionsManager.CompanyWidePermissions.ManageAccounts && !e.Value)
            {
                Close();
            }
        }

        bool closeOnShown = false;
        private void frmCategories_Load(object sender, EventArgs e)
        {
            studioFormExtender.ApplyStyle(this, Theme);

            if (Company == null)
            {
                MessageBox.Show("Company is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                closeOnShown = true;
                return;
            }

            RefreshCategories();
        }

        private async void RefreshCategories()
        {
            loader.BringToFront();
            loader.Visible = true;

            lstCategories.Items.Clear();

            GetData getData = new GetData(DataAccess.APIs.CompanyStudio, "Category/GetForCompany");
            getData.Headers.Add("CompanyID", Company.CompanyID.ToString());
            List<Category> categories = await getData.GetObject<List<Category>>();
            if (categories == null)
            {
                return;
            }

            foreach(Category category in categories)
            {
                ListViewItem item = new ListViewItem(new string[] { category.Name, category.AccountCount.ToString() });
                item.Tag = category;
                lstCategories.Items.Add(item);
            }

            ListViewItem newItem = new ListViewItem("Click to add...");
            newItem.Font = new Font(newItem.Font, FontStyle.Italic);
            lstCategories.Items.Add(newItem);

            loader.Visible = false;
        }

        private void frmCategories_Shown(object sender, EventArgs e)
        {
            if (closeOnShown)
            {
                Close();
            }
        }

        private void lstCategories_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstCategories.SelectedItems.Count > 0 && lstCategories.SelectedItems[0].Font.Style.HasFlag(FontStyle.Italic))
            {
                ListViewItem editItem = lstCategories.SelectedItems[0];
                editItem.Text = "";
                editItem.BeginEdit();
            }
        }

        private async void lstCategories_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Label))
            {
                e.CancelEdit = true;
                lstCategories.Items[e.Item].Text = "Click to add...";
                return;
            }

            PostData post = new PostData(DataAccess.APIs.CompanyStudio, "Category/Post", new Category() { CompanyID = Company.CompanyID, Name = e.Label });
            post.Headers.Add("CompanyID", Company.CompanyID.ToString());
            await post.ExecuteNoResult();

            RefreshCategories();
        }

        private async void lstCategories_KeyUp(object sender, KeyEventArgs e)
        {
            if (lstCategories.SelectedItems.Count <= 0 || e.KeyCode != Keys.Delete)
            {
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this Category?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            Category category = (Category)lstCategories.SelectedItems[0].Tag;

            DeleteData deleteData = new DeleteData(DataAccess.APIs.CompanyStudio, "Category/Delete");
            deleteData.Headers.Add("CompanyID", Company.CompanyID.ToString());
            deleteData.QueryString.Add("id", category.CategoryID.ToString());
            await deleteData.Execute();

            RefreshCategories();
        }

        private void frmCategories_FormClosed(object sender, FormClosedEventArgs e)
        {
            PermissionsManager.OnCompanyPermissionChange -= PermissionsManager_OnPermissionChange;
        }
    }
}

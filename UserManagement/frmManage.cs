using MesaSuite.Common;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserManagement.Models;

namespace UserManagement
{
    public partial class frmManage : Form
    {
        List<Permission> permissions = new List<Permission>();
        List<User> users = new List<User>();
        public frmManage()
        {
            InitializeComponent();
        }

        private async void frmManage_Load(object sender, EventArgs e)
        {
            await LoadSecurities();
            txtSearch.Focus();
        }

        private async Task LoadSecurities()
        {
            Enabled = false;
            lstSecurities.Items.Clear();
            GetData getData = new GetData(DataAccess.APIs.UserManagement, "Permission/GetPermissionKeys");
            permissions = await getData.GetObject<List<Permission>>() ?? new List<Permission>();

            foreach (Permission permission in permissions)
            {
                AddPermission(permission);
            }

            getData = new GetData(DataAccess.APIs.UserManagement, "User/GetAllUsers");
            users = await getData.GetObject<List<User>>() ?? new List<User>();

            foreach (User user in users)
            {
                AddUser(user);
            }

            cmdAddUser.Enabled = Authentication.GetPermissionsByModule("User").Contains("User/ManageUsers");

            Enabled = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lstSecurities.Items.Clear();
            foreach(Permission permission in permissions.Where(p => p.Name.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase)))
            {
                AddPermission(permission);
            }

            foreach (User user in users.Where(p => p.Username.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase)))
            {
                AddUser(user);
            }
        }

        private void AddPermission(Permission permission)
        {
            ListViewItem item = new ListViewItem();
            item.Text = permission.Name;
            item.Tag = permission.PermissionID;
            item.Group = lstSecurities.Groups["grpPermissions"];
            item.ImageKey = "permission";

            lstSecurities.Items.Add(item);
        }

        private void AddUser(User user)
        {
            ListViewItem item = new ListViewItem();
            item.Text = user.Username;
            item.Tag = user.UserID;
            item.Group = lstSecurities.Groups["grpUsers"];
            item.ImageKey = "user";

            lstSecurities.Items.Add(item);
        }

        private void lstSecurities_DoubleClick(object sender, EventArgs e)
        {
            if (lstSecurities.SelectedItems.Count <= 0 || !Authentication.GetPermissionsByModule("User").Contains("User/ManageUsers"))
            {
                return;
            }

            foreach(ListViewItem item in lstSecurities.SelectedItems)
            {
                if (item.Group.Name == "grpUsers")
                {
                    OpenEditUserForm(item.Tag as long?);
                }

                if (item.Group.Name == "grpPermissions")
                {
                    frmViewPermission permission = new frmViewPermission();
                    permission.PermissionID = item.Tag as long?;
                    permission.Show();
                }
            }
        }

        private void ListViewTypeUpdate(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            foreach(ToolStripMenuItem viewItem in mnuView.DropDownItems)
            {
                viewItem.Checked = false;
            }

            item.Checked = true;

            switch(item.Name)
            {
                case "mnuLargeIcon":
                    lstSecurities.View = View.LargeIcon;
                    break;
                case "mnuSmallIcon":
                    lstSecurities.View = View.SmallIcon;
                    break;
                case "mnuList":
                    lstSecurities.View = View.List;
                    break;
                case "mnuTile":
                    lstSecurities.View = View.Tile;
                    break;
                case "mnuDetails":
                    lstSecurities.View = View.Details;
                    break;
            }
        }

        private void cmdAddUser_Click(object sender, EventArgs e)
        {
            frmNewUser newUser = new frmNewUser();
            newUser.ManageForm = this;
            newUser.Show();

            newUser.FormClosed += new FormClosedEventHandler(UserFormClosed);
        }

        private async void UserFormClosed(object sender, FormClosedEventArgs e)
        {
            await LoadSecurities();

            Form form = (Form)sender;
            form.FormClosed -= UserFormClosed;
        }

        private void ctxSecurities_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mnuDeleteUser.Enabled = Authentication.GetPermissionsByModule("User").Contains("User/ManageUsers") && lstSecurities.SelectedItems.Cast<ListViewItem>().Any(lvi => lvi.Group.Name == "grpUsers");
        }

        private async void mnuDeleteUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete these user(s)?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            foreach(ListViewItem item in lstSecurities.SelectedItems.Cast<ListViewItem>().Where(lsv => lsv.Group.Name == "grpUsers"))
            {
                DeleteData delete = new DeleteData(DataAccess.APIs.UserManagement, "User/DeleteUser");
                delete.QueryString.Add("id", ((long?)item.Tag).ToString());
                await delete.Execute();
            }

            await LoadSecurities();
        }

        internal void OpenEditUserForm(long? userID)
        {
            frmEditUser user = new frmEditUser();
            user.UserID = userID;
            user.Show();

            user.FormClosed += new FormClosedEventHandler(UserFormClosed);
        }

        private void lstSecurities_KeyDown(object sender, KeyEventArgs e)
        {
            if (lstSecurities.Items.Cast<ListViewItem>().Any(lvi => lvi.Group.Name == "grpUsers") && e.KeyCode == Keys.Delete)
            {
                mnuDeleteUser_Click(sender, e);
            }
        }
    }
}

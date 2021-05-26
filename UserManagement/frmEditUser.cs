using MesaSuite.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserManagement.Models;

namespace UserManagement
{
    public partial class frmEditUser : Form
    {
        public long? UserID { get; set; }
        public frmEditUser()
        {
            InitializeComponent();
        }

        private async void frmUser_Load(object sender, EventArgs e)
        {
            if (UserID == null)
            {
                throw new ArgumentNullException("UserID is required");
            }

            GetData getUserInfo = new GetData(DataAccess.APIs.UserManagement, "User/GetUser");
            getUserInfo.QueryString = new Dictionary<string, string>()
            {
                { "userid", UserID.Value.ToString() }
            };
            User user = await getUserInfo.GetObject<User>();

            if (user == null)
            {
                return;
            }

            txtUsername.Text = user.Username;
            txtEmail.Text = user.Email;
            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;

            await LoadPermissions();
            await LoadSecurityGroups(user);

            txtFirstName.Focus();

            Enabled = true;
        }

        private async Task LoadPermissions()
        {
            lstPermissions.Items.Clear();

            GetData getUserInfo = new GetData(DataAccess.APIs.UserManagement, "Permission/GetPermissionsForUser");
            getUserInfo.QueryString = new Dictionary<string, string>()
            {
                { "userid", UserID.Value.ToString() }
            };
            List<Permission> permissions = await getUserInfo.GetObject<List<Permission>>() ?? new List<Permission>();

            foreach (Permission permission in permissions)
            {
                AddPermission(permission);
            }
        }

        private void AddPermission(Permission permission)
        {
            ListViewItem item = new ListViewItem();
            item.Text = permission.Name;
            item.Tag = permission.PermissionID;
            item.ImageKey = "permission";
            item.Group = lstPermissions.Groups["grpPermissions"];

            lstPermissions.Items.Add(item);
        }

        private async Task LoadSecurityGroups(User user = null)
        {
            if (user == null)
            {
                GetData getUser = new GetData(DataAccess.APIs.UserManagement, "User/GetUser");
                getUser.QueryString = new Dictionary<string, string>()
                {
                    { "userid", UserID.Value.ToString() }
                };
                user = await getUser.GetObject<User>();
            }

            if (user == null)
            {
                return;
            }

            lstSecurityGroups.Items.Clear();
            foreach(string securityGroup in user.MemberOf)
            {
                ListViewItem item = new ListViewItem();
                item.Text = securityGroup;
                item.ImageKey = "permission";

                lstSecurityGroups.Items.Add(item);
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            txtEmail.Text = $"{txtUsername.Text}@mesabrook.com";
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            Enabled = false;

            User user = new User()
            {
                UserID = UserID.Value,
                Username = txtUsername.Text,
                Email = txtEmail.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text
            };

            PutData data = new PutData(DataAccess.APIs.UserManagement, "User/UpdateUser", user);
            await data.ExecuteNoResult();
            if (!data.RequestSuccessful)
            {
                return;
            }

            Close();
        }

        private void cmdSelectPerms_Click(object sender, EventArgs e)
        {
            frmSelectPermissions select = new frmSelectPermissions();
            select.UserID = UserID;
            select.FormClosed += PermissionsFormClosed;
            select.Show();
        }

        private async void PermissionsFormClosed(object sender, FormClosedEventArgs e)
        {
            Form form = (Form)sender;
            form.FormClosed -= PermissionsFormClosed;

            await LoadPermissions();
        }

        private void lstPermissions_KeyDown(object sender, KeyEventArgs e)
        {
            if (lstPermissions.SelectedItems.Count > 0 && e.KeyCode == Keys.Delete && MessageBox.Show("Are you sure you want to remove these permissions from this user?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DeletePermissions();
            }
        }

        private async void DeletePermissions()
        {
            Enabled = false;

            foreach(ListViewItem item in lstPermissions.Items)
            {
                long permissionID = (long)item.Tag;

                DeleteData deleteData = new DeleteData(DataAccess.APIs.UserManagement, "Permission/DeletePermissionForUser");
                deleteData.QueryString = new Dictionary<string, string>()
                {
                    { "userid", UserID.Value.ToString() },
                    { "permissionid", permissionID.ToString() }
                };
                await deleteData.Execute();
            }

            await LoadPermissions();

            Enabled = true;
        }

        private void cmdSelectSecurityGroups_Click(object sender, EventArgs e)
        {
            frmSelectSecurityGroups selectSecurityGroups = new frmSelectSecurityGroups();
            selectSecurityGroups.UserID = UserID;
            selectSecurityGroups.FormClosed += SelectSecurityGroupsFormClosed;
            selectSecurityGroups.Show();
        }

        private async void SelectSecurityGroupsFormClosed(object sender, FormClosedEventArgs e)
        {
            Form form = (Form)sender;
            form.FormClosed -= SelectSecurityGroupsFormClosed;

            await LoadSecurityGroups();
        }

        private void lstSecurityGroups_KeyDown(object sender, KeyEventArgs e)
        {
            if (lstSecurityGroups.SelectedItems.Count > 0 && e.KeyCode == Keys.Delete && MessageBox.Show("Are you sure you want to remove these security groups from this user?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DeleteSecurityGroups();
            }
        }

        private async void DeleteSecurityGroups()
        {
            Enabled = false;

            PatchData patch = new PatchData(DataAccess.APIs.UserManagement, "User/PatchUser", PatchData.PatchMethods.Remove, UserID, new Dictionary<string, object>()
            {
                { "MemberOf", lstSecurityGroups.SelectedItems.Cast<ListViewItem>().Select(lvi => lvi.Text).ToList() }
            });
            await patch.Execute();
            await LoadSecurityGroups();

            Enabled = true;
        }
    }
}

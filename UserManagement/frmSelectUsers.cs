using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserManagement.Models;

namespace UserManagement
{
    public partial class frmSelectUsers : Form
    {
        List<User> _allUsers;
        List<User> _selectedUsers;
        List<User> _initiallySelectedUsers;

        public long? PermissionID { get; set; }
        public frmSelectUsers()
        {
            InitializeComponent();
        }

        private async void frmSelectUsers_Load(object sender, EventArgs e)
        {
            imlSmall.Images.Add("user", Properties.Resources.user);
            imlLarge.Images.Add("user", Properties.Resources.user_large);

            if (PermissionID == null)
            {
                throw new ArgumentNullException("PermissionID is required");
            }

            GetData getData = new GetData(DataAccess.APIs.UserManagement, "User/GetAllUsers");
            _allUsers = await getData.GetObject<List<User>>() ?? new List<User>();

            getData = new GetData(DataAccess.APIs.UserManagement, "Permission/GetUsersForPermission");
            getData.QueryString = new Dictionary<string, string>()
            {
                { "permissionid", PermissionID.Value.ToString() }
            };
            List<User> usersForPermission = await getData.GetObject<List<User>>() ?? new List<User>();
            _selectedUsers = _allUsers.Where(u => usersForPermission.Any(ufp => ufp.UserID == u.UserID)).ToList();
            _initiallySelectedUsers = _selectedUsers.Select(u => u).ToList();

            SetupUsers();

            txtSearch.Focus();

            Enabled = true;
        }

        private void SetupUsers()
        {
            lstUsers.Items.Clear();

            foreach (User user in _allUsers.Where(u => string.IsNullOrEmpty(txtSearch.Text) ? true : u.Username.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase)))
            {
                ListViewItem item = new ListViewItem();
                item.Text = user.Username;
                item.Tag = user;
                item.ImageKey = "user";
                item.Checked = _selectedUsers.Contains(user);

                lstUsers.Items.Add(item);
            }
        }

        private void lstUsers_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Checked)
            {
                _selectedUsers.Add(e.Item.Tag as User);
            }
            else
            {
                _selectedUsers.Remove(e.Item.Tag as User);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SetupUsers();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            Enabled = false;

            List<User> deletedUsers = _initiallySelectedUsers.Except(_selectedUsers).ToList();

            foreach(User user in deletedUsers)
            {
                DeleteData deleteData = new DeleteData(DataAccess.APIs.UserManagement, "Permission/DeletePermissionForUser");
                deleteData.QueryString.Add("userid", user.UserID.ToString());
                deleteData.QueryString.Add("permissionid", PermissionID.Value.ToString());
                await deleteData.Execute();
            }

            List<User> addedUsers = _selectedUsers.Except(_initiallySelectedUsers).ToList();
            if (addedUsers.Any())
            {
                List<UserPermission> userPermissions = addedUsers.Select(u => new UserPermission() { UserID = u.UserID, PermissionID = PermissionID.Value }).ToList();

                PostData post = new PostData(DataAccess.APIs.UserManagement, "Permission/SetPermissionsForUser");
                post.ObjectToPost = userPermissions;
                await post.ExecuteNoResult();
            }

            Close();
        }
    }
}

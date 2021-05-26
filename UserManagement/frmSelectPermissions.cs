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
    public partial class frmSelectPermissions : Form
    {
        public long? UserID { get; set; }
        public List<Permission> PreselectedPermissions { get; set; }
        List<Permission> _allPermissions;
        List<Permission> _selectedPermissions;
        List<Permission> _initialSelectedPermissions;
        public frmSelectPermissions()
        {
            InitializeComponent();
        }

        private async void frmSelectPermissions_Load(object sender, EventArgs e)
        {
            imlList.Images.Add("permission", Properties.Resources.permission);
            if (UserID == null && PreselectedPermissions == null)
            {
                throw new ArgumentNullException("UserID or PreselectedPermissions is required");
            }
            GetData get = new GetData(DataAccess.APIs.UserManagement, "Permission/GetPermissionKeys");
            _allPermissions = await get.GetObject<List<Permission>>() ?? new List<Permission>();

            if (PreselectedPermissions == null)
            {
                get = new GetData(DataAccess.APIs.UserManagement, "Permission/GetPermissionsForUser");
                get.QueryString = new Dictionary<string, string>()
                {
                    { "userid", UserID.Value.ToString() }
                };
                List<Permission> permissionsForUser = await get.GetObject<List<Permission>>() ?? new List<Permission>();

                _selectedPermissions = _allPermissions.Where(p => permissionsForUser.Any(pfu => pfu.PermissionID == p.PermissionID)).ToList();
                _initialSelectedPermissions = _selectedPermissions.Select(p => p).ToList();
            }
            else
            {
                _selectedPermissions = _allPermissions.Where(p => PreselectedPermissions.Any(pp => p.Key == pp.Key)).ToList();
                _initialSelectedPermissions = _selectedPermissions.ToList();
            }

            FillPermissionsList();

            txtSearch.Focus();

            Enabled = true;
        }

        private void FillPermissionsList()
        {
            lstPermissions.Items.Clear();

            foreach(Permission permission in _allPermissions.Where(p => p.Name.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase)))
            {
                ListViewItem item = new ListViewItem();
                item.ImageKey = "permission";
                item.Text = permission.Name;
                item.Tag = permission;
                item.Checked = _selectedPermissions.Contains(permission);
                lstPermissions.Items.Add(item);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillPermissionsList();
        }

        private void lstPermissions_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            Permission permission = (Permission)e.Item.Tag;
            if (e.Item.Checked)
            {
                _selectedPermissions.Add(permission);
            }
            else
            {
                _selectedPermissions.Remove(permission);
            }
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            Enabled = false;

            if (PreselectedPermissions == null)
            {
                List<Permission> unselectedPermission = _initialSelectedPermissions.Except(_selectedPermissions).ToList();
                List<Permission> newlySelectedPermissions = _selectedPermissions.Except(_initialSelectedPermissions).ToList();

                foreach (Permission deletedPermission in unselectedPermission)
                {
                    UserPermission userPermission = new UserPermission()
                    {
                        UserID = UserID.Value,
                        PermissionID = deletedPermission.PermissionID
                    };

                    DeleteData delete = new DeleteData(DataAccess.APIs.UserManagement, "Permission/DeletePermissionForUser");
                    delete.QueryString.Add("userid", UserID.Value.ToString());
                    delete.QueryString.Add("permissionid", deletedPermission.PermissionID.ToString());
                    await delete.Execute();
                }

                if (newlySelectedPermissions.Any())
                {
                    PostData post = new PostData(DataAccess.APIs.UserManagement, "Permission/SetPermissionsForUser");
                    post.ObjectToPost = newlySelectedPermissions.Select(p => new UserPermission() { UserID = UserID.Value, PermissionID = p.PermissionID }).ToList();
                    await post.ExecuteNoResult();
                }
            }
            else
            {
                PreselectedPermissions = _selectedPermissions;
            }

            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

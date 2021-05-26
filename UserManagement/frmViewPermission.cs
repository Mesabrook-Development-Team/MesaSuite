using MesaSuite.Common.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserManagement.Models;

namespace UserManagement
{
    public partial class frmViewPermission : Form
    {
        public long? PermissionID { get; set; }
        public frmViewPermission()
        {
            InitializeComponent();
        }

        private async void frmViewPermission_Load(object sender, EventArgs e)
        {
            if (PermissionID == null)
            {
                throw new ArgumentNullException("PermissionID is required.");
            }

            GetData getData = new GetData(DataAccess.APIs.UserManagement, "Permission/GetPermission");
            getData.QueryString = new Dictionary<string, string>()
            {
                { "permissionid", PermissionID.Value.ToString() }
            };

            Permission permission = await getData.GetObject<Permission>();
            if (permission == null)
            {
                return;
            }
            txtName.Text = permission.Name;
            txtKey.Text = permission.Key;

            await LoadUsers();

            txtName.Focus();

            Enabled = true;
        }

        private async Task LoadUsers()
        {
            lstUsers.Items.Clear();

            GetData getData = new GetData(DataAccess.APIs.UserManagement, "Permission/GetUsersForPermission");
            getData.QueryString = new Dictionary<string, string>()
            {
                { "permissionid", PermissionID.Value.ToString() }
            };

            List<User> users = await getData.GetObject<List<User>>() ?? new List<User>();

            foreach(User user in users)
            {
                ListViewItem item = new ListViewItem();
                item.Text = user.Username;
                item.Tag = user.UserID;
                item.ImageKey = "user";
                lstUsers.Items.Add(item);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdSelect_Click(object sender, EventArgs e)
        {
            frmSelectUsers selectUsers = new frmSelectUsers();
            selectUsers.PermissionID = PermissionID;
            selectUsers.FormClosed += new FormClosedEventHandler(SelectUsersFormClosed);
            selectUsers.Show();
        }

        private async void SelectUsersFormClosed(object sender, FormClosedEventArgs e)
        {
            Form form = (Form)sender;
            form.FormClosed -= SelectUsersFormClosed;

            await LoadUsers();
        }

        private void lstUsers_KeyDown(object sender, KeyEventArgs e)
        {
            if (lstUsers.SelectedItems.Count > 0 && e.KeyCode == Keys.Delete && MessageBox.Show("Are you sure you want to remove these User(s) from this Permission?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DeleteUsers();
            }
        }

        private async void DeleteUsers()
        {
            Enabled = false;

            foreach (ListViewItem item in lstUsers.SelectedItems)
            {
                long userID = (long)item.Tag;
                DeleteData deleteData = new DeleteData(DataAccess.APIs.UserManagement, "Permission/DeletePermissionForUser");
                deleteData.QueryString = new Dictionary<string, string>()
                {
                    { "userid", userID.ToString() },
                    { "permissionid", PermissionID.Value.ToString() }
                };

                await deleteData.Execute();
            }

            await LoadUsers();

            Enabled = true;
        }
    }
}

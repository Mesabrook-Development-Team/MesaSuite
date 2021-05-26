using MesaSuite.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserManagement.Models;

namespace UserManagement
{
    public partial class frmNewUser : Form
    {
        public frmManage ManageForm { get; set; }
        public frmNewUser()
        {
            InitializeComponent();
        }

        private async void frmNewUser_Load(object sender, EventArgs e)
        {
            imlList.Images.Add("permission", Properties.Resources.permission);
            GetData getData = new GetData(DataAccess.APIs.UserManagement, "ActiveDirectoryUser/GetAllActiveDirectoryUsers");

            List<string> users = await getData.GetObject<List<string>>() ?? new List<string>();
            if (!getData.RequestSuccessful)
            {
                return;
            }

            cboUsers.Items.Add("");

            foreach(string user in users)
            {
                cboUsers.Items.Add(user);
            }

            cboUsers.Focus();

            Enabled = true;
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            Enabled = false;
            string user = cboUsers.SelectedItem as string;

            if (!string.IsNullOrEmpty(user))
            {
                await SaveExistingADUser();
            }
            else
            {
                await SaveNewADUser();
            }
        }

        private async Task SaveExistingADUser()
        {
            string user = cboUsers.SelectedItem as string;

            User userObject = new User()
            {
                Username = user,
                Email = $"{user}@mesabrook.com"
            };

            PostData post = new PostData(DataAccess.APIs.UserManagement, "User/PostUserExisting", userObject);
            await post.ExecuteNoResult();

            if (post.RequestSuccessful)
            {
                Close();
            }
            else
            {
                Enabled = true;
            }
        }

        private async Task SaveNewADUser()
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtLastName.Text))
            {
                MessageBox.Show("Username, First Name, and Last Name are required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string password = Guid.NewGuid().ToString("N");
            User userObject = new User()
            {
                Username = txtUsername.Text,
                Email = $"{txtUsername.Text}@mesabrook.com",
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Password = password,
                MemberOf = lstSecurityGroups.Items.Cast<ListViewItem>().Select(lvi => lvi.Text).ToList()
            };

            PostData post = new PostData(DataAccess.APIs.UserManagement, "User/PostUserNew", userObject);
            userObject = await post.Execute<User>();

            if (post.RequestSuccessful)
            {
                List<UserPermission> userPermissions = new List<UserPermission>();
                foreach(Permission permission in lstPermissions.Items.Cast<ListViewItem>().Select(lvi => (Permission)lvi.Tag))
                {
                    userPermissions.Add(new UserPermission()
                    {
                        UserID = userObject.UserID,
                        PermissionID = permission.PermissionID
                    });
                }

                if (userPermissions.Any())
                {
                    post = new PostData(DataAccess.APIs.UserManagement, "Permission/SetPermissionsForUser", userPermissions);
                    await post.ExecuteNoResult();

                    if (!post.RequestSuccessful)
                    {
                        MessageBox.Show("The user saved successfully, however, the permissions did not.  Recommend manually checking permissions.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                Clipboard.SetText(password);
                MessageBox.Show($"This user's new password is {password}.\r\n\r\nIt has been copied to your clipboard.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
            else
            {
                Enabled = true;
            }
        }

        private void DetectExistingOrNew(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) && 
                string.IsNullOrEmpty(txtFirstName.Text) &&
                string.IsNullOrEmpty(txtLastName.Text) &&
                lstSecurityGroups.Items.Count == 0 &&
                lstPermissions.Items.Count == 0)
            {
                cboUsers.Enabled = true;
            }
            else
            {
                cboUsers.Enabled = false;
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            txtEmail.Text = txtUsername.Text + "@mesabrook.com";

            DetectExistingOrNew(sender, e);
        }

        private void cboUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool hasSelectedItem = !string.IsNullOrEmpty(cboUsers.SelectedItem as string);

            txtUsername.Enabled = !hasSelectedItem;
            txtFirstName.Enabled = !hasSelectedItem;
            txtLastName.Enabled = !hasSelectedItem;
            cmdSelectSG.Enabled = !hasSelectedItem;
            cmdSelectP.Enabled = !hasSelectedItem;
        }

        private void cmdSelectSG_Click(object sender, EventArgs e)
        {
            frmSelectSecurityGroups selectSGs = new frmSelectSecurityGroups();
            selectSGs.PreselectedSecurityGroups = lstSecurityGroups.Items.Cast<ListViewItem>().Select(lvi => lvi.Text).ToList();
            selectSGs.FormClosed += SelectSGsFormClosed;
            selectSGs.Show();
        }

        private void SelectSGsFormClosed(object sender, FormClosedEventArgs e)
        {
            frmSelectSecurityGroups selectSGs = (frmSelectSecurityGroups)sender;
            lstSecurityGroups.Items.Clear();
            
            foreach(string securityGroup in selectSGs.PreselectedSecurityGroups)
            {
                ListViewItem item = new ListViewItem();
                item.ImageKey = "permission";
                item.Text = securityGroup;

                lstSecurityGroups.Items.Add(item);
            }

            DetectExistingOrNew(sender, e);
        }

        private void cmdSelectP_Click(object sender, EventArgs e)
        {
            frmSelectPermissions selectPermissions = new frmSelectPermissions();
            selectPermissions.PreselectedPermissions = lstPermissions.Items.Cast<ListViewItem>().Select(lvi => (Permission)lvi.Tag).ToList();
            selectPermissions.FormClosed += SelectPermissionsFormClosed;
            selectPermissions.Show();
        }

        private void SelectPermissionsFormClosed(object sender, FormClosedEventArgs e)
        {
            frmSelectPermissions selectPermissions = (frmSelectPermissions)sender;
            lstPermissions.Items.Clear();

            foreach(Permission permission in selectPermissions.PreselectedPermissions)
            {
                ListViewItem item = new ListViewItem();
                item.ImageKey = "permission";
                item.Tag = permission;
                item.Text = permission.Name;
                lstPermissions.Items.Add(item);
            }

            DetectExistingOrNew(sender, e);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

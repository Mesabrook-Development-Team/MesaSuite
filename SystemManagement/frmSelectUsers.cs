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
using SystemManagement.Models;

namespace SystemManagement
{
    public partial class frmSelectUsers : Form
    {
        List<User> _allUsers;
        List<User> _selectedUsers;

        public List<long> SelectedUserIDs = new List<long>();
        public frmSelectUsers()
        {
            InitializeComponent();
        }

        private async void frmSelectUsers_Load(object sender, EventArgs e)
        {
            imlSmall.Images.Add("user", Properties.Resources.user);
            imlLarge.Images.Add("user", Properties.Resources.user_large);

            Enabled = false;

            GetData getData = new GetData(DataAccess.APIs.SystemManagement, "User/GetAllUsers");
            _allUsers = await getData.GetObject<List<User>>() ?? new List<User>();

            _selectedUsers = _allUsers.Where(u => SelectedUserIDs.Contains(u.UserID)).ToList();

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
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            SelectedUserIDs = _selectedUsers.Select(u => u.UserID).ToList();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

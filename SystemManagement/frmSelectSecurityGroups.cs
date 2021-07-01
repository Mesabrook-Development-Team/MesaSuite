using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SystemManagement.Models;

namespace SystemManagement
{
    public partial class frmSelectSecurityGroups : Form
    {
        public long? UserID { get; set; }
        public List<string> PreselectedSecurityGroups { get; set; }
        List<string> _allGroups;
        List<string> _selectedGroups;
        List<string> _initiallySelectedGroups;
        public frmSelectSecurityGroups()
        {
            InitializeComponent();
        }

        private async void frmSelectSecurityGroups_Load(object sender, EventArgs e)
        {
            imlList.Images.Add("security", Properties.Resources.security);
            if (UserID == null && PreselectedSecurityGroups == null)
            {
                throw new ArgumentNullException("UserID or PreselectedSecurityGroups is required");
            }

            GetData get = new GetData(DataAccess.APIs.SystemManagement, "ActiveDirectoryGroup/GetGroups");
            _allGroups = await get.GetObject<List<string>>() ?? new List<string>();

            if (PreselectedSecurityGroups == null)
            {
                get = new GetData(DataAccess.APIs.SystemManagement, "User/GetUser");
                get.QueryString = new Dictionary<string, string>()
                {
                    { "userid", UserID.Value.ToString() }
                };
                User user = await get.GetObject<User>();
                if (user == null)
                {
                    return;
                }
                _selectedGroups = user.MemberOf.Intersect(_allGroups).ToList();
                _initiallySelectedGroups = _selectedGroups.Select(g => g).ToList();
            }
            else
            {
                _selectedGroups = PreselectedSecurityGroups.ToList();
                _initiallySelectedGroups = PreselectedSecurityGroups.ToList();
            }

            FillList();

            txtSearch.Focus();

            Enabled = true;
        }

        private void FillList()
        {
            lstGroups.Items.Clear();

            foreach(string group in _allGroups.Where(g => g.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase)))
            {
                ListViewItem item = new ListViewItem();
                item.Text = group;
                item.ImageKey = "security";
                item.Checked = _selectedGroups.Contains(group);

                lstGroups.Items.Add(item);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillList();
        }

        private void lstGroups_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Checked)
            {
                _selectedGroups.Add(e.Item.Text);
            }
            else
            {
                _selectedGroups.Remove(e.Item.Text);
            }
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            Enabled = false;

            if (PreselectedSecurityGroups == null)
            {
                PatchData patch = new PatchData(DataAccess.APIs.SystemManagement, "User/PatchUser", PatchData.PatchMethods.Replace, UserID, new Dictionary<string, object>()
                {
                    { "MemberOf", _selectedGroups }
                });

                await patch.Execute();
            }
            else
            {
                PreselectedSecurityGroups = _selectedGroups;
            }

            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

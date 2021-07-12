using MesaSuite.Common.Collections;
using MesaSuite.Common.Data;
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
    public partial class frmNewGovernment : Form
    {
        private List<Official> _officials = new List<Official>();

        public frmNewGovernment()
        {
            InitializeComponent();
            imlSmall.Images.Add("user", Properties.Resources.user);
        }

        private async void cmdSelectOfficials_Click(object sender, EventArgs e)
        {
            frmSelectUsers selectUsers = new frmSelectUsers();
            selectUsers.SelectedUserIDs = _officials.Select(o => o.UserID).ToList();
            DialogResult diagResult = selectUsers.ShowDialog();

            if (diagResult != DialogResult.OK)
            {
                return;
            }

            foreach(long newUserID in selectUsers.SelectedUserIDs.Where(uid => !_officials.Any(o => o.UserID == uid)))
            {
                Official official = new Official();
                official.UserID = newUserID;
                _officials.Add(official);
            }

            _officials.RemoveAll(o => !selectUsers.SelectedUserIDs.Any(uid => uid == o.UserID));

            await SetupOfficialsList();
        }

        public async Task SetupOfficialsList()
        {
            Enabled = false;

            lstOfficials.Items.Clear();
            GetData getUsers = new GetData(DataAccess.APIs.SystemManagement, "User/GetUsers");

            MultiMap<string, string> queryString = new MultiMap<string, string>();
            foreach(Official official in _officials)
            {
                queryString.Add("userids", official.UserID.ToString());
            }
            getUsers.QueryString = queryString;

            Dictionary<long, User> users = (await getUsers.GetObject<List<User>>()).ToDictionary(u => u.UserID);
            foreach(Official official in _officials)
            {
                ListViewItem item = new ListViewItem();
                item.Text = users[official.UserID].Username;
                item.ImageKey = "user";
                item.Tag = official;
                item.SubItems.Add(official.ManageEmails.ToString());
                item.SubItems.Add(official.ManageOfficials.ToString());

                lstOfficials.Items.Add(item);
            }

            Enabled = true;
        }

        private async void lstOfficials_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstOfficials.SelectedItems.Count <= 0)
            {
                return;
            }

            Official official = (Official)lstOfficials.SelectedItems[0].Tag;

            frmEditOfficial editOfficial = new frmEditOfficial();
            editOfficial.Official = official;
            editOfficial.PerformDatabaseSave = false;
            editOfficial.GovernmentNameOverride = txtName.Text;
            DialogResult res = editOfficial.ShowDialog();

            if (res != DialogResult.OK)
            {
                return;
            }

            await SetupOfficialsList();
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            Government government = new Government();
            government.Name = txtName.Text;
            PostData put = new PostData(DataAccess.APIs.SystemManagement, "Government/PostGovernment", government);
            government = await put.Execute<Government>();

            if (!put.RequestSuccessful)
            {
                return;
            }

            bool officialSaveSuccessful = true;
            foreach(Official official in _officials)
            {
                official.GovernmentID = government.GovernmentID;

                put = new PostData(DataAccess.APIs.SystemManagement, "Government/PostOfficial", official);
                await put.ExecuteNoResult();

                officialSaveSuccessful = officialSaveSuccessful && put.RequestSuccessful;
            }

            if (!officialSaveSuccessful)
            {
                MessageBox.Show("The Government save was successful, but at least one Official did not save successfully.  Recommend reviewing officials and trying again through the Government Edit screen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

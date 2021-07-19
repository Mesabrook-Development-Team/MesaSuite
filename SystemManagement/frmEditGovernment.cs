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
    public partial class frmEditGovernment : Form
    {
        public long GovernmentID { get; set; }
        private List<Official> _officials = new List<Official>();
        public frmEditGovernment()
        {
            InitializeComponent();
            imlSmall.Images.Add("user", Properties.Resources.user);
        }

        private async void frmEditGovernment_Load(object sender, EventArgs e)
        {
            await SetupGovernmentInfo();
        }

        private async Task SetupGovernmentInfo()
        {
            Enabled = false;

            GetData getData = new GetData(DataAccess.APIs.SystemManagement, "Government/Get");
            getData.QueryString = new MultiMap<string, string>()
            {
                { "id", GovernmentID.ToString() }
            };

            Government government = await getData.GetObject<Government>();
            txtName.Text = government.Name;

            await SetupOfficialInfo();

            Enabled = true;

            BringToFront();
        }

        private async Task SetupOfficialInfo()
        {
            lstOfficials.Items.Clear();

            GetData getData = new GetData(DataAccess.APIs.SystemManagement, "Official/GetOfficialsForGovernment");
            getData.QueryString = new MultiMap<string, string>()
            {
                { "id", GovernmentID.ToString() }
            };
            _officials = await getData.GetObject<List<Official>>();
            List<User> users = new List<User>();

            if (_officials.Any())
            {
                getData = new GetData(DataAccess.APIs.SystemManagement, "User/GetUsers");
                MultiMap<string, string> queryString = new MultiMap<string, string>();
                foreach (Official official in _officials)
                {
                    queryString.Add("userids", official.UserID.ToString());
                }
                getData.QueryString = queryString;
                users = await getData.GetObject<List<User>>();
            }

            foreach (Official official in _officials)
            {
                User user = users.FirstOrDefault(u => u.UserID == official.UserID);

                ListViewItem item = new ListViewItem();
                item.Text = user?.Username;
                item.ImageKey = "user";
                item.Tag = official;
                item.SubItems.Add(official.ManageEmails.ToString());
                item.SubItems.Add(official.ManageOfficials.ToString());

                lstOfficials.Items.Add(item);
            }
        }

        private void lstOfficials_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach(ListViewItem item in lstOfficials.SelectedItems)
            {
                Official official = (Official)item.Tag;

                frmEditOfficial editOfficial = new frmEditOfficial();
                editOfficial.Official = official;
                editOfficial.FormClosed += EditOfficial_FormClosed;
                editOfficial.Show();
            }
        }

        private async void EditOfficial_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmEditOfficial editOfficial = (frmEditOfficial)sender;
            editOfficial.FormClosed -= EditOfficial_FormClosed;

            Enabled = false;

            await SetupOfficialInfo();

            Enabled = true;
            BringToFront();
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Name is a required field.");
                return;
            }

            Government government = new Government()
            {
                GovernmentID = GovernmentID,
                Name = txtName.Text
            };

            PutData put = new PutData(DataAccess.APIs.SystemManagement, "Government/Put", government);
            await put.ExecuteNoResult();

            if (!put.RequestSuccessful)
            {
                return;
            }

            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void cmdSelectOfficials_Click(object sender, EventArgs e)
        {
            frmSelectUsers selectUsers = new frmSelectUsers();
            selectUsers.SelectedUserIDs = _officials.Select(o => o.UserID).ToList();
            DialogResult result = selectUsers.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            Enabled = false;

            foreach(long userID in selectUsers.SelectedUserIDs.Except(_officials.Select(o => o.OfficialID)))
            {
                Official official = new Official();
                official.GovernmentID = GovernmentID;
                official.UserID = userID;

                PostData post = new PostData(DataAccess.APIs.SystemManagement, "Official/Post", official);
                await post.ExecuteNoResult();
            }

            foreach(Official official in _officials.Where(o => !selectUsers.SelectedUserIDs.Contains(o.UserID)))
            {
                DeleteData delete = new DeleteData(DataAccess.APIs.SystemManagement, "Official/Delete");
                delete.QueryString = new Dictionary<string, string>()
                {
                    { "id", official.OfficialID.ToString() }
                };
                await delete.Execute();
            }

            await SetupOfficialInfo();

            Enabled = true;
            BringToFront();
        }
    }
}

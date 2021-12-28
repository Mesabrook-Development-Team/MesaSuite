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

            getData = new GetData(DataAccess.APIs.SystemManagement, "Domain/GetAll");
            List<Domain> domains = await getData.GetObject<List<Domain>>();
            foreach(Domain domain in domains)
            {
                cboDomain.Items.Add(domain.DomainName);
            }
            cboDomain.Text = government.EmailDomain;

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

            foreach (Official official in _officials)
            {
                ListViewItem item = new ListViewItem();
                item.Text = official.OfficialName;
                item.ImageKey = "user";
                item.Tag = official;

                lstOfficials.Items.Add(item);
            }
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
                Name = txtName.Text,
                EmailDomain = cboDomain.Text
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
                GetData existingOfficialLookup = new GetData(DataAccess.APIs.SystemManagement, $"Official/GetByUserID");
                existingOfficialLookup.QueryString = new MultiMap<string, string>()
                {
                    { "userID", userID.ToString() },
                    { "governmentID", GovernmentID.ToString() }
                };
                Official officialToUpdate = await existingOfficialLookup.GetObject<Official>();
                if (!existingOfficialLookup.RequestSuccessful)
                {
                    continue;
                }

                if (officialToUpdate != null)
                {
                    PatchData patchData = new PatchData(DataAccess.APIs.SystemManagement, "Official/Patch", PatchData.PatchMethods.Replace, officialToUpdate.OfficialID, new Dictionary<string, object>()
                    {
                        { "ManageOfficials", true }
                    });
                    await patchData.Execute();
                }
                else
                {
                    officialToUpdate = new Official();
                    officialToUpdate.GovernmentID = GovernmentID;
                    officialToUpdate.UserID = userID;
                    officialToUpdate.ManageOfficials = true;

                    PostData post = new PostData(DataAccess.APIs.SystemManagement, "Official/Post", officialToUpdate);
                    await post.ExecuteNoResult();
                }
            }

            foreach(Official official in _officials.Where(o => !selectUsers.SelectedUserIDs.Contains(o.UserID)))
            {
                PatchData patchData = new PatchData(DataAccess.APIs.SystemManagement, "Official/Patch", PatchData.PatchMethods.Replace, official.OfficialID, new Dictionary<string, object>()
                {
                    { "ManageOfficials", false }
                });
                await patchData.Execute();
            }

            await SetupOfficialInfo();

            Enabled = true;
            BringToFront();
        }
    }
}

using MesaSuite.Common.Collections;
using MesaSuite.Common.Data;
using System;
using System.Windows.Forms;
using SystemManagement.Models;

namespace SystemManagement
{
    public partial class frmEditOfficial : Form
    {
        public string GovernmentNameOverride { get; set; }
        public bool PerformDatabaseSave { get; set; } = true;
        public Official Official { get; set; }
        public frmEditOfficial()
        {
            InitializeComponent();
        }

        private async void frmEditOfficial_Load(object sender, EventArgs e)
        {
            GetData getData = new GetData(DataAccess.APIs.SystemManagement, "User/GetUser");
            getData.QueryString = new MultiMap<string, string>()
            {
                { "userid", Official.UserID.ToString() }
            };
            User user = await getData.GetObject<User>();
            txtOfficial.Text = user.Username;

            if (!string.IsNullOrEmpty(GovernmentNameOverride))
            {
                txtGovernment.Text = GovernmentNameOverride;
            }
            else
            {
                // Get data
                GetData get = new GetData(DataAccess.APIs.SystemManagement, "Government/GetGovernment");
                get.QueryString = new MultiMap<string, string>()
                {
                    { "id", Official.GovernmentID.ToString() }
                };
                Government government = await get.GetObject<Government>();
                if (government != null)
                {
                    txtGovernment.Text = government.Name;
                }
            }

            chkManageEmails.Checked = Official.ManageEmails;
            chkManageOfficials.Checked = Official.ManageOfficials;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            Official.ManageEmails = chkManageEmails.Checked;
            Official.ManageOfficials = chkManageOfficials.Checked;

            DialogResult = DialogResult.OK;

            if (PerformDatabaseSave)
            {
                PutData put = new PutData(DataAccess.APIs.SystemManagement, "Government/PutOfficial", Official);
                await put.ExecuteNoResult();

                if (!put.RequestSuccessful)
                {
                    return;
                }
            }

            Close();
        }
    }
}

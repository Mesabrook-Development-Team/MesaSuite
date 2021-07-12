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

            GetData getData = new GetData(DataAccess.APIs.SystemManagement, "Government/GetGovernment");
            getData.QueryString = new MultiMap<string, string>()
            {
                { "id", GovernmentID.ToString() }
            };

            Government government = await getData.GetObject<Government>();
            txtName.Text = government.Name;

            await SetupOfficialInfo();

            Enabled = true;
        }

        private async Task SetupOfficialInfo()
        {
            lstOfficials.Items.Clear();

            GetData getData = new GetData(DataAccess.APIs.SystemManagement, "Government/GetOfficialsForGovernment");
            getData.QueryString = new MultiMap<string, string>()
            {
                { "id", GovernmentID.ToString() }
            };
            List<Official> officials = await getData.GetObject<List<Official>>();
            List<User> users = new List<User>();

            if (officials.Any())
            {
                getData = new GetData(DataAccess.APIs.SystemManagement, "User/GetUsers");
                MultiMap<string, string> queryString = new MultiMap<string, string>();
                foreach (Official official in officials)
                {
                    queryString.Add("userids", official.UserID.ToString());
                }
                getData.QueryString = queryString;
                users = await getData.GetObject<List<User>>();
            }

            foreach (Official official in officials)
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
        }
    }
}

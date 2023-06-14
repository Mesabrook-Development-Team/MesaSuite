using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;

namespace MesaSuite
{
    public partial class frmClients : Form
    {
        public frmClients()
        {
            InitializeComponent();
        }

        private async Task ReloadClients(long? selectedClientID = null)
        {
            dgvApps.Rows.Clear();
            toolDelete.Enabled = false;

            GetData get = new GetData(DataAccess.APIs.SystemManagement, "Client/GetAll");
            List<Client> clients = await get.GetObject<List<Client>>() ?? new List<Client>();
            foreach (Client client in clients)
            {
                int rowIndex = dgvApps.Rows.Add();
                DataGridViewRow row = dgvApps.Rows[rowIndex];
                row.Cells[colName.Name].Value = client.ClientName;
                row.Cells[colUserCount.Name].Value = client.UserCount;
                row.Tag = client.ClientID;
            }

            foreach(DataGridViewRow row in dgvApps.Rows)
            {
                row.Selected = ((long?)row.Tag) == selectedClientID;
            }
        }

        private async void frmClients_Load(object sender, EventArgs e)
        {
            await ReloadClients();
        }

        public class Client
        {
            public long? ClientID { get; set; }
            public Guid? ClientIdentifier { get; set; }
            public string RedirectionURI { get; set; }
            public enum Types
            {
                BrowserEnabled,
                Device
            }
            public Types Type { get; set; }
            public string ClientName { get; set; }
            public int UserCount { get; set; }
        }

        private async void dgvApps_SelectionChanged(object sender, EventArgs e)
        {
            pnlDetail.Visible = false;
            toolSave.Enabled = false;

            if (dgvApps.SelectedRows.Count <= 0)
            {
                return;
            }

            toolDelete.Enabled = true;
            DataGridViewRow row = dgvApps.SelectedRows[0];
            long? clientID = row.Tag as long?;
            if (clientID == null)
            {
                return;
            }

            GetData get = new GetData(DataAccess.APIs.SystemManagement, $"Client/Get/{clientID}");
            Client client = await get.GetObject<Client>();
            if (client == null)
            {
                return;
            }

            LoadPanel(client);
        }

        private void LoadPanel(Client client)
        {
            pnlDetail.Visible = true;
            toolSave.Enabled = true;
            txtIdentifier.Text = client?.ClientIdentifier?.ToString();
            txtAppName.Text = client?.ClientName;
            rdoBrowserEnabled.Checked = client?.Type == Client.Types.BrowserEnabled;
            rdoDevice.Checked = client?.Type == Client.Types.Device;
            txtRedirectURI.Text = client?.RedirectionURI;
            lblRedirectURI.Visible = rdoBrowserEnabled.Checked;
            txtRedirectURI.Visible = rdoBrowserEnabled.Checked;
        }

        private void toolNew_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dgvApps.Rows)
            {
                row.Selected = false;
            }

            LoadPanel(null);
        }

        private async void toolDelete_Click(object sender, EventArgs e)
        {
            if (dgvApps.SelectedRows.Count <= 0 || !(dgvApps.SelectedRows[0].Tag is long?) || !this.Confirm("Are you sure you want to delete this Client?"))
            {
                return;
            }

            long? clientID = dgvApps.SelectedRows[0].Tag as long?;

            DeleteData delete = new DeleteData(DataAccess.APIs.SystemManagement, $"Client/Delete/{clientID}");
            await delete.Execute();

            await ReloadClients();
        }

        private async void toolSave_Click(object sender, EventArgs e)
        {
            if (dgvApps.SelectedRows.Count == 0)
            {
                Client newClient = new Client()
                {
                    ClientName = txtAppName.Text,
                    Type = rdoDevice.Checked ? Client.Types.Device : Client.Types.BrowserEnabled,
                    RedirectionURI = rdoBrowserEnabled.Checked ? txtRedirectURI.Text : null
                };

                PostData post = new PostData(DataAccess.APIs.SystemManagement, "Client/Post", newClient);
                Client postedClient = await post.Execute<Client>();
                if (post.RequestSuccessful)
                {
                    await ReloadClients(postedClient.ClientID);
                }
            }
            else
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { nameof(Client.ClientName), txtAppName.Text },
                    { nameof(Client.Type), (rdoDevice.Checked ? Client.Types.Device : Client.Types.BrowserEnabled).ToString() },
                    { nameof(Client.RedirectionURI), rdoBrowserEnabled.Checked ? txtRedirectURI.Text : null }
                };

                long? clientID = (long?)dgvApps.SelectedRows[0].Tag;
                PatchData patch = new PatchData(DataAccess.APIs.SystemManagement, "Client/Patch", PatchData.PatchMethods.Replace, clientID, values);
                await patch.Execute();
                if (patch.RequestSuccessful)
                {
                    await ReloadClients(clientID);
                }
            }
        }

        private void rdoBrowserEnabled_CheckedChanged(object sender, EventArgs e)
        {
            lblRedirectURI.Visible = rdoBrowserEnabled.Checked;
            txtRedirectURI.Visible = rdoBrowserEnabled.Checked;
        }
    }
}

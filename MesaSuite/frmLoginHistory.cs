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

namespace MesaSuite
{
    public partial class frmLoginHistory : Form
    {
        public frmLoginHistory()
        {
            InitializeComponent();
        }

        private async void frmLoginHistory_Load(object sender, EventArgs e)
        {
            await LoadApps();
        }

        bool isLoading = false;
        private async Task LoadApps()
        {
            try
            {
                isLoading = true;

                dgvApps.Rows.Clear();

                GetData get = new GetData(DataAccess.APIs.SystemManagement, "LoginHistory/GetAppsForUser");
                List<App> apps = await get.GetObject<List<App>>() ?? new List<App>();
                foreach (App app in apps)
                {
                    int rowIndex = dgvApps.Rows.Add();
                    DataGridViewRow row = dgvApps.Rows[rowIndex];
                    row.Cells[colName.Name].Value = app.ClientName;
                    row.Cells[colCurrentlyLoggedIn.Name].Value = app.CurrentlyLoggedIn ? "Yes" : "No";
                    row.Tag = app.ClientID;
                }

                foreach (DataGridViewRow row in dgvApps.Rows)
                {
                    row.Selected = false;
                }
            }
            finally
            {
                isLoading = false;
            }

            if (dgvApps.Rows.Count > 0)
            {
                dgvApps.Rows[0].Selected = true;
            }
        }

        public class App
        {
            public long? ClientID { get; set; }
            public string ClientName { get; set; }
            public bool CurrentlyLoggedIn { get; set; }
        }

        public class History
        {
            public long? ClientID { get; set; }
            public string ClientName { get; set; }
            public DateTime? GrantTime { get; set; }
            public DateTime? RevokeTime { get; set; }
            public bool WasRefreshed { get; set; }
            public string RevokeReason { get; set; }
        }

        private async void dgvApps_SelectionChanged(object sender, EventArgs e)
        {
            await LoadAppDetails();
        }

        private async Task LoadAppDetails()
        {
            if (isLoading)
            {
                return;
            }

            dgvGrantRefresh.Rows.Clear();
            dgvRevocation.Rows.Clear();

            suppressLoggedInCheckedChange = true;
            chkLoggedIn.Checked = false;
            chkLoggedIn.Tag = chkLoggedIn.Checked;
            suppressLoggedInCheckedChange = false;

            DataGridViewRow row = dgvApps.SelectedRows.OfType<DataGridViewRow>().FirstOrDefault();
            pnlDetail.Visible = row != null;
            mnuLogOut.Enabled = row != null;
            mnuRemoveApp.Enabled = row != null;

            if (row == null)
            {
                return;
            }

            GetData get = new GetData(DataAccess.APIs.SystemManagement, $"LoginHistory/GetLoginHistoryForApp/{row.Tag}");
            List<History> histories = await get.GetObject<List<History>>() ?? new List<History>();
            foreach (History history in histories)
            {
                int rowIndex = dgvGrantRefresh.Rows.Add();
                DataGridViewRow historyRow = dgvGrantRefresh.Rows[rowIndex];
                historyRow.Cells[colGrantTime.Name].Value = history.GrantTime?.ToString("MM/dd/yyyy HH:mm:ss");
                historyRow.Cells[colType.Name].Value = history.WasRefreshed ? "Refreshed" : history.RevokeTime != null ? "Revoked" : "Current";
            }

            suppressLoggedInCheckedChange = true;
            chkLoggedIn.Checked = histories.Any(h => h.RevokeTime == null && !h.WasRefreshed);
            chkLoggedIn.Tag = chkLoggedIn.Checked;
            suppressLoggedInCheckedChange = false;

            get = new GetData(DataAccess.APIs.SystemManagement, $"LoginHistory/GetAllRevokesForApp/{row.Tag}");
            histories = await get.GetObject<List<History>>() ?? new List<History>();
            foreach (History history in histories)
            {
                int rowIndex = dgvRevocation.Rows.Add();
                DataGridViewRow revokeRow = dgvRevocation.Rows[rowIndex];
                revokeRow.Cells[colRevokeGrantTime.Name].Value = history.GrantTime?.ToString("MM/dd/yyyy HH:mm:ss");
                revokeRow.Cells[colRevokeTime.Name].Value = history.RevokeTime?.ToString("MM/dd/yyyy HH:mm:ss");
                revokeRow.Cells[colReason.Name].Value = history.RevokeReason;
            }
        }

        bool suppressLoggedInCheckedChange = false;
        private void chkLoggedIn_CheckedChanged(object sender, EventArgs e)
        {
            if (suppressLoggedInCheckedChange)
            {
                return;
            }
            
            suppressLoggedInCheckedChange = true;
            chkLoggedIn.Checked = (bool)chkLoggedIn.Tag;
            suppressLoggedInCheckedChange = false;
        }

        private async void mnuLogOut_Click(object sender, EventArgs e)
        {
            if (dgvApps.SelectedRows.Count <= 0)
            {
                return;
            }

            long? clientID = dgvApps.SelectedRows[0].Tag as long?;
            PutData put = new PutData(DataAccess.APIs.SystemManagement, "LogOutFromApp/" + clientID, new object());
            await put.ExecuteNoResult();

            await LoadAppDetails();
        }

        private async void mnuRemoveApp_Click(object sender, EventArgs e)
        {
            if (dgvApps.SelectedRows.Count <= 0)
            {
                return;
            }

            long? clientID = dgvApps.SelectedRows[0].Tag as long?;
            PutData put = new PutData(DataAccess.APIs.SystemManagement, "RemoveApp/" + clientID, new object());
            await put.ExecuteNoResult();
            await LoadApps();
        }
    }
}

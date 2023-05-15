using MesaSuite.Common;
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

namespace MesaSuite
{
    public partial class frmPersonalAccessTokens : Form
    {
        public frmPersonalAccessTokens()
        {
            InitializeComponent();
        }

        private async void frmPersonalAccessTokens_Load(object sender, EventArgs e)
        {
            await ReloadGrid();
        }

        bool gridLoading = false;
        private async Task ReloadGrid(long? selectedID = null)
        {
            try
            {
                gridLoading = true;
                dgvPATs.Rows.Clear();

                GetData get = new GetData(DataAccess.APIs.SystemManagement, "PersonalAccessToken/GetAll");
                List<PersonalAccessToken> personalAccessTokens = await get.GetObject<List<PersonalAccessToken>>() ?? new List<PersonalAccessToken>();

                foreach (PersonalAccessToken token in personalAccessTokens)
                {
                    int rowIndex = dgvPATs.Rows.Add();
                    DataGridViewRow row = dgvPATs.Rows[rowIndex];
                    row.Cells[nameof(colName)].Value = token.Name;
                    row.Cells[nameof(colExpiration)].Value = token.Expiration?.ToString("dddd MMM dd',' yyyy '@' HH:mm") ?? "Never";
                    row.Tag = token.PersonalAccessTokenID;
                }

                dgvPATs.Sort(colName, ListSortDirection.Ascending);

                foreach(DataGridViewRow row in dgvPATs.Rows)
                {
                    row.Selected = false;
                }

                if (selectedID != null)
                {
                    DataGridViewRow row = dgvPATs.Rows.Cast<DataGridViewRow>().FirstOrDefault(dgvr => dgvr.Tag is long? && ((long?)dgvr.Tag) == selectedID);
                    if (row != null)
                    {
                        row.Selected = true;
                    }
                }
                else if (dgvPATs.Rows.Count > 0)
                {
                    dgvPATs.Rows[0].Selected = true;
                }
            }
            finally
            {
                gridLoading = false;
            }

            if (dgvPATs.SelectedRows.Count > 0)
            {
                mnuDeletePAT.Enabled = true;
                LoadDetails();
            }
            else
            {
                mnuDeletePAT.Enabled = false;
                pnlDetail.Visible = false;
            }
        }

        private class PersonalAccessToken
        {
            public long? PersonalAccessTokenID { get; set; }
            public long? UserID { get; set; }
            public string Name { get; set; }
            public string Token { get; set; }
            public DateTime? Expiration { get; set; }
            public bool CanRefreshInactivity { get; set; }
            public bool CanPerformNetworkPrinting { get; set; }
        }

        private void dgvPATs_SelectionChanged(object sender, EventArgs e)
        {
            LoadDetails();
            mnuDeletePAT.Enabled = true;
        }

        private async void LoadDetails()
        {
            if (gridLoading)
            {
                return;
            }

            txtName.Clear();
            dtpExpiration.Value = DateTime.Now;
            chkNeverExpires.Checked = false;
            chkInactivity.Checked = false;
            chkNetworkPrinting.Checked = false;

            pnlDetail.Visible = true;

            txtName.Focus();

            if (dgvPATs.SelectedRows.Count <= 0)
            {
                return;
            }

            DataGridViewRow selectedRow = dgvPATs.SelectedRows[0];

            GetData get = new GetData(DataAccess.APIs.SystemManagement, $"PersonalAccessToken/Get/{(long?)selectedRow.Tag}");
            PersonalAccessToken token = await get.GetObject<PersonalAccessToken>();
            if (token == null)
            {
                return;
            }

            txtName.Text = token.Name;
            dtpExpiration.Value = token.Expiration ?? DateTime.Now;
            chkNeverExpires.Checked = token.Expiration == null;
            chkInactivity.Checked = token.CanRefreshInactivity;
            chkNetworkPrinting.Checked = token.CanPerformNetworkPrinting;
        }

        private void mnuAddPAT_Click(object sender, EventArgs e)
        {
            dgvPATs.ClearSelection();

            LoadDetails();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (dgvPATs.SelectedRows.Count <= 0)
            {
                SaveCreate();
            }
            else
            {
                SaveUpdate();
            }
        }

        private async void SaveCreate()
        {
            PersonalAccessToken personalAccessToken = new PersonalAccessToken()
            {
                Name = txtName.Text,
                Expiration = chkNeverExpires.Checked ? (DateTime?)null : dtpExpiration.Value,
                CanRefreshInactivity = chkInactivity.Checked,
                CanPerformNetworkPrinting = chkNetworkPrinting.Checked
            };

            PostData post = new PostData(DataAccess.APIs.SystemManagement, "PersonalAccessToken/Post", personalAccessToken);
            pnlDetail.Enabled = false;
            PersonalAccessToken pat = await post.Execute<PersonalAccessToken>();
            pnlDetail.Enabled = true;
            if (post.RequestSuccessful)
            {
                Clipboard.SetText(pat.Token);
                MessageBox.Show("Your personal access token has been copied to your clipboard.\r\n\r\nIMPORTANT: You will not able to retrieve this token again! Paste your token in a secure location now!", "Personal Access Token", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ReloadGrid(pat.PersonalAccessTokenID);
            }
        }

        private async void SaveUpdate()
        {
            DataGridViewRow row = dgvPATs.SelectedRows[0];
            long? patID = (long?)row.Tag;

            Dictionary<string, object> updateFields = new Dictionary<string, object>()
            {
                { nameof(PersonalAccessToken.Name), txtName.Text },
                { nameof(PersonalAccessToken.Expiration), chkNeverExpires.Checked ? (DateTime?)null : dtpExpiration.Value },
                { nameof(PersonalAccessToken.CanRefreshInactivity), chkInactivity.Checked },
                { nameof(PersonalAccessToken.CanPerformNetworkPrinting), chkNetworkPrinting.Checked }
            };

            PatchData patch = new PatchData(DataAccess.APIs.SystemManagement, "PersonalAccessToken/Patch", PatchData.PatchMethods.Replace, patID, updateFields);
            pnlDetail.Enabled = false;
            await patch.Execute();
            pnlDetail.Enabled = true;

            if (patch.RequestSuccessful)
            {
                this.ShowInformation("Save successful!");
                ReloadGrid(patID);
            }
        }

        private void chkNeverExpires_CheckedChanged(object sender, EventArgs e)
        {
            dtpExpiration.Enabled = !chkNeverExpires.Checked;
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            LoadDetails();
        }

        private async void mnuDeletePAT_Click(object sender, EventArgs e)
        {
            if (dgvPATs.SelectedRows.Count <= 0 || !this.Confirm("Are you sure you want to delete this Personal Access Token?"))
            {
                return;
            }

            DataGridViewRow row = dgvPATs.SelectedRows[0];
            long? id = (long?)row.Tag;

            DeleteData delete = new DeleteData(DataAccess.APIs.SystemManagement, $"PersonalAccessToken/Delete/{id}");
            pnlDetail.Enabled = false;
            await delete.Execute();
            pnlDetail.Enabled = true;
            if (delete.RequestSuccessful)
            {
                ReloadGrid();
            }
        }
    }
}

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
    public partial class frmAuditingView : Form
    {
        public frmAuditingView()
        {
            InitializeComponent();
        }

        private async void cmdGo_Click(object sender, EventArgs e)
        {
            cmdGo.Enabled = false;
            lstAuditData.Items.Clear();

            try
            {
                GetData get = new GetData(DataAccess.APIs.SystemManagement, "BlockAudit/Query");
                get.QueryString.Add("minimumDate", dtpMinimum.Value.ToString("O"));
                get.QueryString.Add("maximumDate", dtpMaximum.Value.ToString("O"));

                if (int.TryParse(txtFromX.Text, out int minimumX))
                {
                    get.QueryString.Add("minimumX", minimumX.ToString());
                }
                if (int.TryParse(txtToX.Text, out int maximumX))
                {
                    get.QueryString.Add("maximumX", maximumX.ToString());
                }
                if (int.TryParse(txtFromY.Text, out int minimumY))
                {
                    get.QueryString.Add("minimumY", minimumY.ToString());
                }
                if (int.TryParse(txtToY.Text, out int maximumY))
                {
                    get.QueryString.Add("maximumY", maximumY.ToString());
                }
                if (int.TryParse(txtFromZ.Text, out int minimumZ))
                {
                    get.QueryString.Add("minimumZ", minimumZ.ToString());
                }
                if (int.TryParse(txtToZ.Text, out int maximumZ))
                {
                    get.QueryString.Add("maximumZ", maximumZ.ToString());
                }

                if (!string.IsNullOrEmpty(txtBlockNames.Text))
                {
                    get.QueryString.Add("blockNames", txtBlockNames.Text);
                }

                if (!string.IsNullOrEmpty(txtPlayers.Text))
                {
                    get.QueryString.Add("playerNames", txtPlayers.Text);
                }

                get.QueryString.Add("skip", numSkip.Value.ToString());
                get.QueryString.Add("take", numTake.Value.ToString());

                List<BlockAudit> blockAudits = await get.GetObject<List<BlockAudit>>() ?? new List<BlockAudit>();

                foreach (BlockAudit blockAudit in blockAudits)
                {
                    ListViewItem listViewItem = new ListViewItem(new string[]
                    {
                        blockAudit.AuditTime?.ToString("MM/dd/yyyy HH:mm:ss.fff"),
                        blockAudit.BlockPos,
                        blockAudit.BlockName,
                        blockAudit.PlayerName,
                        blockAudit.AuditType.ToString()
                    });
                    lstAuditData.Items.Add(listViewItem);
                }
            }
            finally
            {
                cmdGo.Enabled = true;
            }
        }

        private void lstAuditData_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompanyStudio.Extensions;
using CompanyStudio.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;

namespace CompanyStudio.WireTransfers
{
    public partial class frmWireTransferHistoryExplorer : BaseCompanyStudioContent
    {
        public frmWireTransferHistoryExplorer()
        {
            InitializeComponent();
        }

        private async void frmWireTransferHistoryExplorer_Load(object sender, System.EventArgs e)
        {
            Text += " - " + Company.Name;
            await ReloadHistory();
            PermissionsManager.OnCompanyPermissionChange += PermissionsManager_OnCompanyPermissionChange;
        }

        private void PermissionsManager_OnCompanyPermissionChange(object sender, PermissionsManager.CompanyWidePermissionChangeEventArgs e)
        {
            if (e.CompanyID == Company.CompanyID && e.Permission == PermissionsManager.CompanyWidePermissions.IssueWireTransfers && !e.Value)
            {
                this.ShowError("You no longer have permission to use Wire Transfers for " + Company.Name);
                Close();
            }
        }

        private async Task ReloadHistory()
        {
            loader.BringToFront();
            loader.Visible = true;

            GetData get = new GetData(DataAccess.APIs.CompanyStudio, "WireTransferHistory/GetAll");
            get.AddCompanyHeader(Company.CompanyID);
            List<WireTransferHistory> wireTransferHistories = await get.GetObject<List<WireTransferHistory>>() ?? new List<WireTransferHistory>();
            
            lstWireTransfers.Items.Clear();
            foreach(WireTransferHistory wireTransferHistory in wireTransferHistories.OrderByDescending(wth => wth.TransferTime))
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = wireTransferHistory.TransferTime?.ToString("MM/dd/yyyy HH:mm");
                listViewItem.SubItems.Add(wireTransferHistory.GovernmentFrom?.Name ?? wireTransferHistory.CompanyFrom?.Name);
                listViewItem.SubItems.Add(wireTransferHistory.GovernmentTo?.Name ?? wireTransferHistory.CompanyTo?.Name);
                listViewItem.SubItems.Add(wireTransferHistory.AccountFromHistorical ?? wireTransferHistory.AccountFromMasked);
                listViewItem.SubItems.Add(wireTransferHistory.AccountToMasked ?? wireTransferHistory.AccountToHistorical);
                listViewItem.SubItems.Add(wireTransferHistory.Amount?.ToString("N2"));
                listViewItem.SubItems.Add(wireTransferHistory.Memo);
                lstWireTransfers.Items.Add(listViewItem);
            }

            loader.Visible = false;
        }

        private void frmWireTransferHistoryExplorer_FormClosing(object sender, FormClosingEventArgs e)
        {
            PermissionsManager.OnCompanyPermissionChange -= PermissionsManager_OnCompanyPermissionChange;
        }

        private void toolSendWireTransfer_Click(object sender, System.EventArgs e)
        {
            frmSendWireTransfer send = new frmSendWireTransfer();
            send.Theme = Theme;
            send.Company = Company;
            send.ShowDialog();

            ReloadHistory();
        }
    }
}

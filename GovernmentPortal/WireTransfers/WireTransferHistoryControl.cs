using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GovernmentPortal.Models;
using MesaSuite.Common.Extensions;

namespace GovernmentPortal.WireTransfers
{
    public partial class WireTransferHistoryControl : UserControl, IExplorerControl<WireTransferHistory>
    {
        public event EventHandler IsDirtyChanged;
        public WireTransferHistoryControl()
        {
            InitializeComponent();
        }

        public bool IsDirty
        {
            get => false;
            set { }
        }

        public WireTransferHistory Model { get; set; }

        private frmGenericExplorer<WireTransferHistory> _explorer = null;
        public frmGenericExplorer<WireTransferHistory> Explorer { set => _explorer = value; }

        public void OnDeleteClicked()
        {
            this.ShowError("Wire Transfer History records may not be deleted.");
        }

        public void OnSaveClicked()
        {
            this.ShowError("Wire Transfer History records may not be saved.");
        }

        private void WireTransferHistoryControl_Load(object sender, EventArgs e)
        {
            if (Model == null)
            {
                this.ShowError("Wire Transfer Histories may not be created.");
                Dispose();
                return;
            }

            txtDate.Text = Model.TransferTime.Value.ToString("MM/dd/yyyy");
            txtFrom.Text = Model.GovernmentFrom?.Name ?? Model.CompanyFrom?.Name;
            txtTo.Text = Model.GovernmentTo?.Name ?? Model.CompanyTo?.Name;
            txtFromAccount.Text = Model.AccountFromHistorical ?? Model.AccountFromMasked;
            txtToAccount.Text = Model.AccountToHistorical ?? Model.AccountToMasked;
            txtAmount.Text = Model.Amount.Value.ToString("N2");
            txtMemo.Text = Model.Memo;
        }
    }
}

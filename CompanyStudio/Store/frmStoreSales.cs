using CompanyStudio.Extensions;
using CompanyStudio.Models;
using CompanyStudio.Store.Reports;
using MesaSuite.Common.Collections;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyStudio.Store
{
    public partial class frmStoreSales : Form
    {
        private StepConfigurationCollection Steps;

        public Company Company { get; set; }
        public Location LocationModel { get; set; }

        public frmStudio StudioForm { get; set; }

        public frmStoreSales()
        {
            InitializeComponent();

            Steps = new StepConfigurationCollection()
            {
                { lstNav.Items[0], pnlWelcome, null, false, true },
                { lstNav.Items[1], pnlSelectRegisters, ValidateRegisters },
                { lstNav.Items[2], pnlSelectItems, ValidateItems },
                { lstNav.Items[3], pnlTimeRange, ValidateDateRange },
                { lstNav.Items[4], pnlReview, null, true, false }
            };
        }

        private void dgvItems_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == colRemove.Index)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.cancel.Width;
                var h = Properties.Resources.cancel.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.cancel, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private bool _isLoading;
        private async void frmStoreSales_Load(object sender, EventArgs e)
        {
            PermissionsManager.OnLocationPermissionChange += PermissionsManager_OnLocationPermissionChange;

            imageList.Images.Add("cancel", Properties.Resources.cancel);
            imageList.Images.Add("accept", Properties.Resources.accept);

            foreach(ListViewItem item in lstNav.Items)
            {
                item.ImageKey = "cancel";
            }

            pnlWelcome.BringToFront();
            pnlWelcome.Visible = true;

            _isLoading = true;
            _previousItem = lstNav.Items[0];
            lstNav.Items[0].Selected = true;
            foreach(KeyValuePair<ListViewItem, StepConfiguration> kvp in Steps)
            {
                StepConfiguration configuration = kvp.Value;
                string imageKey = "accept";
                if (configuration.Validate != null && !configuration.Validate.Invoke())
                {
                    imageKey = "cancel";
                }

                kvp.Key.ImageKey = imageKey;
            }
            _isLoading = false;

            try
            {
                GetData get = new GetData(DataAccess.APIs.CompanyStudio, "Register/GetAll");
                get.AddLocationHeader(Company.CompanyID, LocationModel.LocationID);
                List<Register> registers = await get.GetObject<List<Register>>() ?? new List<Register>();
                foreach(Register register in registers)
                {
                    DropDownItem<Register> ddi = new DropDownItem<Register>(register, register.Name);
                    chkRegisters.Items.Add(ddi);
                }
            }
            catch { }
        }

        private void PermissionsManager_OnLocationPermissionChange(object sender, PermissionsManager.LocationWidePermissionChangeEventArgs e)
        {
            if (e.LocationID == LocationModel.LocationID && e.Permission == PermissionsManager.LocationWidePermissions.ManagePrices && !e.Value)
            {
                Close();
            }
        }

        private async void cmdAddItem_Click(object sender, EventArgs e)
        {
            if (itmSelector.SelectedID == null)
            {
                return;
            }

            int rowIndex = dgvItems.Rows.Add();
            DataGridViewRow row = dgvItems.Rows[rowIndex];
            row.Cells[colItem.Name].Value = itmSelector.SelectedText;
            long? itemID = itmSelector.SelectedID;
            row.Tag = itemID ?? 0;

            try
            {
                GetData get = new GetData(DataAccess.APIs.CompanyStudio, $"Item/Get/{itemID}");
                Item item = await get.GetObject<Item>();
                if (item != null)
                {
                    row.Cells[colItemImage.Name].Value = item.GetImage();
                }
            }
            catch { }
        }

        private void chkShowAll_CheckedChanged(object sender, EventArgs e)
        {
            itmSelector.Enabled = !chkShowAll.Checked;
            dgvItems.Enabled = !chkShowAll.Checked;
            cmdAddItem.Enabled = !chkShowAll.Checked;
        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colRemove.Index)
            {
                return;
            }

            dgvItems.Rows.RemoveAt(e.RowIndex);
        }

        private void pnlReview_VisibleChanged(object sender, EventArgs e)
        {
            StringBuilder reviewText = new StringBuilder();
            reviewText.AppendLine("Registers To Show:");
            foreach (DropDownItem<Register> register in chkRegisters.CheckedItems.OfType<DropDownItem<Register>>())
            {
                reviewText.AppendLine("├─ " + register.Object.Name);
            }

            reviewText.AppendLine("Items to show: " + (chkShowAll.Checked ? "All" : "Select"));
            if (!chkShowAll.Checked)
            {
                foreach (DataGridViewRow row in dgvItems.Rows)
                {
                    reviewText.AppendLine("├─ " + row.Cells[colItem.Name].Value);
                }
            }

            reviewText.AppendLine("Transaction Range: " + dtpStart.Value.ToString("MM/dd/yyyy") + " - " + dtpEnd.Value.ToString("MM/dd/yyyy"));

            txtReview.Text = reviewText.ToString();
        }

        private async void cmdRun_Click(object sender, EventArgs e)
        {
            cmdRun.Enabled = false;

            try
            {
                GetData get = new GetData(DataAccess.APIs.CompanyStudio, "StoreSaleItem/Get");
                if (chkRegisters.CheckedItems.Count > 0)
                {
                    foreach(DropDownItem<Register> register in chkRegisters.CheckedItems.OfType<DropDownItem<Register>>())
                    {
                        get.QueryString.Add("registerid", register.Object.RegisterID.ToString());
                    }
                }

                foreach(DataGridViewRow row in dgvItems.Rows)
                {
                    if (row.Tag is long itemID)
                    {
                        get.QueryString.Add("itemid", itemID.ToString());
                    }
                }

                get.QueryString.Add("startdate", dtpStart.Value.Ticks.ToString());
                get.QueryString.Add("enddate", dtpEnd.Value.Ticks.ToString());
                get.AddLocationHeader(Company.CompanyID, LocationModel.LocationID);
                List<StoreSaleItem> storeSaleItems = await get.GetObject<List<StoreSaleItem>>() ?? new List<StoreSaleItem>();

                MultiMap<DateTime, StoreSaleItem> salesByMonth = new MultiMap<DateTime, StoreSaleItem>();
                foreach(StoreSaleItem storeSaleItem in storeSaleItems)
                {
                    DateTime firstDayOfMonth = new DateTime(storeSaleItem.SaleTime.Value.Year, storeSaleItem.SaleTime.Value.Month, 1);
                    salesByMonth.Add(firstDayOfMonth, storeSaleItem);
                }

                List<MonthlySummary> monthlySummaries = new List<MonthlySummary>();
                foreach(KeyValuePair<DateTime, HashSet<StoreSaleItem>> itemsByMonth in salesByMonth)
                {
                    MonthlySummary summary = new MonthlySummary()
                    {
                        StartDate = itemsByMonth.Key,
                        Amount = itemsByMonth.Value.Sum(ssi => ssi.SoldPrice.Value)
                    };
                    monthlySummaries.Add(summary);
                }

                frmReportViewer reportViewer = new frmReportViewer();
                StudioForm.DecorateStudioContent(reportViewer);
                reportViewer.Company = Company;
                reportViewer.ReportName = "CompanyStudio.Store.Reports.StoreSalesReport.rdlc";
                reportViewer.AddDataSet("SalesByItem.SalesByItemDS", storeSaleItems);
                reportViewer.AddDataSet("SalesByRegister.SalesByRegisterDS", storeSaleItems);
                reportViewer.AddDataSet("SalesGraph.SalesGraphDS", monthlySummaries);
                reportViewer.AddParameter("StoreName", Company.Name);
                reportViewer.AddParameter("StartDate", dtpStart.Value.ToString("MM/dd/yyyy"));
                reportViewer.AddParameter("EndDate", dtpEnd.Value.ToString("MM/dd/yyyy"));
                reportViewer.AddParameter("SelectedRegisters", chkRegisters.CheckedItems.Count.ToString());
                reportViewer.AddParameter("TotalRegisters", chkRegisters.Items.Count.ToString());
                reportViewer.AddParameter("SelectedItems", chkShowAll.Checked ? "all" : dgvItems.Rows.Count.ToString());
                reportViewer.Show(StudioForm.dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
                Close();
            }
            finally
            {
                cmdRun.Enabled = true;
            }
        }

        #region Step Validations
        private bool ValidateRegisters()
        {
            if (chkRegisters.CheckedItems.Count <= 0)
            {
                if (!_isLoading)
                {
                    this.ShowError("You must select at least one Register");
                }

                return false;
            }

            return true;
        }

        private bool ValidateItems()
        {
            if (!chkShowAll.Checked && dgvItems.Rows.Count <= 0)
            {
                if (!_isLoading)
                {
                    this.ShowError("You must either check Show All Items or select at least 1 item.");
                }

                return false;
            }

            return true;
        }

        private bool ValidateDateRange()
        {
            if (dtpStart.Value.Date > dtpEnd.Value.Date.AddDays(1).AddSeconds(-1))
            {
                if (!_isLoading)
                {
                    this.ShowError("Start Date must be before End Date.");
                }

                return false;
            }

            return true;
        }
        #endregion

        #region Fancy Step Stuff
        private class StepConfiguration
        {
            public bool AllowPrevious { get; set; } = true;
            public bool AllowNext { get; set; } = true;

            public Panel StepPanel { get; set; }
            public Func<bool> Validate { get; set; }
        }

        private class StepConfigurationCollection : Dictionary<ListViewItem, StepConfiguration>
        {
            public void Add(ListViewItem item, Panel panel, Func<bool> validate, bool allowPrevious, bool allowNext)
            {
                Add(item, new StepConfiguration() { Validate = validate, StepPanel = panel, AllowPrevious = allowPrevious, AllowNext = allowNext });
            }

            public void Add(ListViewItem item, Panel panel, Func<bool> validate)
            {
                Add(item, panel, validate, true, true);
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private ListViewItem _previousItem;
        private void cmdBack_Click(object sender, EventArgs e)
        {
            int prevIndex = lstNav.SelectedItems[0].Index - 1;
            lstNav.SelectedItems.Clear();
            lstNav.Items[prevIndex].Selected = true;
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            int nextIndex = lstNav.SelectedItems[0].Index + 1;
            lstNav.SelectedItems.Clear();
            lstNav.Items[nextIndex].Selected = true;
        }

        private void lstNav_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (_isLoading || _previousItem == null || lstNav.SelectedItems.Count != 1 || !e.IsSelected)
            {
                return;
            }

            ListViewItem currentItem = e.Item;
            if (currentItem == _previousItem)
            {
                return;
            }

            StepConfiguration previousConfiguration = Steps[_previousItem];
            if (previousConfiguration.Validate != null && !previousConfiguration.Validate.Invoke())
            {
                lstNav.SelectedItems.Clear();
                lstNav.Items[_previousItem.Index].ImageKey = "cancel";
                lstNav.Items[_previousItem.Index].Selected = true;
                return;
            }

            lstNav.Items[_previousItem.Index].ImageKey = "accept";
            previousConfiguration.StepPanel.Visible = false;

            StepConfiguration currentConfiguration = Steps[currentItem];
            currentConfiguration.StepPanel.Visible = true;

            _previousItem = currentItem;

            cmdBack.Enabled = currentConfiguration.AllowPrevious;
            cmdNext.Enabled = currentConfiguration.AllowNext;
        }
        #endregion

        private void frmStoreSales_FormClosed(object sender, FormClosedEventArgs e)
        {
            PermissionsManager.OnLocationPermissionChange -= PermissionsManager_OnLocationPermissionChange;
        }
    }
}

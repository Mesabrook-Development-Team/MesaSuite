using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FleetTracking.Interop;
using MesaSuite.Common.Data;

namespace FleetTracking.Roster
{
    public partial class RailcarList : UserControl, IFleetTrackingControl
    {
        private const int take = 15;
        private int skip = 0;
        private int total = 0;

        Dictionary<string, Models.Railcar> stockByReportingMark = new Dictionary<string, Models.Railcar>();

        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }
        public event EventHandler<Models.Railcar> RailcarSelected;

        public IReadOnlyCollection<Models.Railcar> SelectedRailcars => dgvRailcars.SelectedRows.OfType<DataGridViewRow>().Select(row => row.Tag).OfType<Models.Railcar>().ToList();

        public bool AllowMultiSelect { get; set; } = true;

        public Func<Models.Railcar, bool> Filter { private get; set; }
        private string _reportingMarkFilter;
        public string ReportingMarkFilter
        {
            get => _reportingMarkFilter;
            set
            {
                _reportingMarkFilter = value;
                ReportingMarkFilterChanged();
            }
        }

        public RailcarList()
        {
            InitializeComponent();
            dataGridViewStylizer.ApplyStyle(dgvRailcars);

            dgvRailcars.MultiSelect = AllowMultiSelect;
        }

        private async void RailcarList_Load(object sender, EventArgs e)
        {
            await RetrieveData();
        }

        public async Task RetrieveData(string selectedReportingMark = null)
        {
            loader.BringToFront();
            loader.Visible = true;

            try
            {
                dgvRailcars.Rows.Clear();
                stockByReportingMark = new Dictionary<string, Models.Railcar>();

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = $"Railcar/GetAll";

                List<Models.Railcar> railcars = await get.GetObject<List<Models.Railcar>>() ?? new List<Models.Railcar>();
                if (Filter != null)
                {
                    railcars = railcars.Where(Filter).ToList();
                }
                stockByReportingMark = railcars.ToDictionary(r => r.FormattedReportingMark);
                total = railcars.Count;
                PopulateGrid(selectedReportingMark);
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private async Task PopulateGrid(string selectedReportingMark = null)
        {
            try
            {
                dgvRailcars.Rows.Clear();

                Dictionary<string, Models.Railcar> filteredStock = stockByReportingMark.OrderBy(kvp => kvp.Key).Skip(skip).Take(take).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                lblRecordCount.Text = $"Displaying {skip + 1}-{(skip + take > total ? total : skip + take)} of {total}";

                cmdFirst.Enabled = skip > 0;
                cmdPrevious.Enabled = skip > 0;
                cmdNext.Enabled = skip + take < total;
                cmdLast.Enabled = skip + take < total;

                foreach (KeyValuePair<string, Models.Railcar> kvp in filteredStock)
                {
                    int rowIndex = dgvRailcars.Rows.Add();
                    DataGridViewRow row = dgvRailcars.Rows[rowIndex];

                    row.Cells[colReportingMark.Name].Value = kvp.Key;

                    Models.Railcar railcar = kvp.Value;
                    row.Cells[colModel.Name].Value = railcar.RailcarModel.Name;
                    row.Cells[colCurrentLocation.Name].Value = railcar.Location;
                    row.Cells[colDestination.Name].Value = railcar.TrackDestination?.Name;
                    row.Cells[colLoad.Name].Value = railcar.FormattedRailcarLoads;
                    row.Cells[colOwner.Name].Value = $"{railcar.CompanyOwner?.Name ?? railcar.GovernmentOwner?.Name}";
                    row.Tag = railcar;

                    if (string.Equals(kvp.Key, selectedReportingMark, StringComparison.OrdinalIgnoreCase))
                    {
                        row.Selected = true;
                    }
                }

                dgvRailcars.ClearSelection();
                if (string.IsNullOrEmpty(selectedReportingMark) && dgvRailcars.Rows.Count > 0)
                {
                    dgvRailcars.Sort(colReportingMark, ListSortDirection.Ascending);
                    dgvRailcars.Rows[0].Selected = true;

                    if (dgvRailcars.SelectedRows[0].Tag is Models.Railcar selectedRailcar)
                    {
                        RailcarSelected?.Invoke(this, selectedRailcar);
                    }
                }
                else if (!string.IsNullOrEmpty(selectedReportingMark))
                {
                    DataGridViewRow row = dgvRailcars.Rows.Cast<DataGridViewRow>().FirstOrDefault(fodRow => fodRow.Tag is Models.Railcar railcar && string.Equals(selectedReportingMark, $"{railcar.ReportingMark}{railcar.ReportingNumber}"));
                    if (row != null)
                    {
                        row.Selected = true;
                    }
                }

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;

                foreach (DataGridViewRow row in dgvRailcars.Rows)
                {
                    Models.Railcar railcar = row.Tag as Models.Railcar;
                    if (railcar == null)
                    {
                        continue;
                    }

                    get.Resource = $"Railcar/GetImageThumbnail/{railcar.RailcarID}";
                    byte[] imageData = await get.GetObject<byte[]>();

                    if (imageData != null)
                    {
                        using (MemoryStream memoryStream = new MemoryStream(imageData))
                        {
                            Image image = Image.FromStream(memoryStream);
                            row.Cells[colImage.Name].Value = image;
                        }
                    }
                }
            }
            catch { }
        }

        private void dgvRailcars_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRailcars.SelectedRows.Count <= 0 || !(dgvRailcars.SelectedRows[0].Tag is Models.Railcar railcar))
            {
                return;
            }

            RailcarSelected?.Invoke(this, railcar);
        }

        private void ReportingMarkFilterChanged()
        {
            foreach (DataGridViewRow row in dgvRailcars.Rows)
            {
                string reportingMark = row.Cells[colReportingMark.Name].Value as string;
                row.Visible = string.IsNullOrEmpty(reportingMark) || string.IsNullOrEmpty(ReportingMarkFilter) || reportingMark.Contains(ReportingMarkFilter);
            }
        }

        private void cmdFirst_Click(object sender, EventArgs e)
        {
            skip = 0;
            PopulateGrid();
        }

        private void cmdPrevious_Click(object sender, EventArgs e)
        {
            skip -= take;
            if (skip < 0)
            {
                skip = 0;
            }

            PopulateGrid();
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            skip += take;
            PopulateGrid();
        }

        private void cmdLast_Click(object sender, EventArgs e)
        {
            skip = total - take;
            if (skip < 0)
            {
                skip = 0;
            }
            PopulateGrid();
        }
    }
}

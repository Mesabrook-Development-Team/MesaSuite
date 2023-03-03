using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FleetTracking.Attributes;
using FleetTracking.Interop;
using FleetTracking.Models;
using MesaSuite.Common.Data;

namespace FleetTracking.Roster
{
    [SecuredControl(SecuredControlAttribute.Permissions.AllowSetup, SecuredControlAttribute.Permissions.IsTrainCrew, SecuredControlAttribute.Permissions.IsYardmaster)]
    public partial class RollingStockList : UserControl, IFleetTrackingControl
    {
        private const int take = 15;
        private int skip = 0;
        private int total = 0;

        Dictionary<string, object> stockByReportingMark = new Dictionary<string, object>();

        public event EventHandler<Locomotive> LocomotiveSelected;
        public event EventHandler<Railcar> RailcarSelected;

        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public Func<Locomotive, bool> LocomotiveFilter { get; set; }
        public Func<Railcar, bool> RailcarFilter { get; set; }

        public IReadOnlyCollection<Locomotive> SelectedLocomotives => dgvRollingStock.SelectedRows.OfType<DataGridViewRow>().Select(row => row.Tag).OfType<Locomotive>().ToList();
        public IReadOnlyCollection<Railcar> SelectedRailcars => dgvRollingStock.SelectedRows.OfType<DataGridViewRow>().Select(row => row.Tag).OfType<Railcar>().ToList();

        public RollingStockList()
        {
            InitializeComponent();
        }

        private async void RollingStockList_Load(object sender, EventArgs e)
        {
            dataGridViewStylizer.ApplyStyle(dgvRollingStock);
            dgvRollingStock.MultiSelect = true;

            await RetrieveData();
        }

        public async Task RetrieveData(string selectedReportingMark = null)
        {
            try
            {
                loader.BringToFront();
                loader.Visible = true;

                dgvRollingStock.Rows.Clear();
                stockByReportingMark = new Dictionary<string, object>();
                stockByReportingMark = stockByReportingMark.Concat(await LoadLocomotives(selectedReportingMark)).Concat(await LoadRailcars(selectedReportingMark)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                total = stockByReportingMark.Count;
                PopulateGrid(selectedReportingMark);
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private async void PopulateGrid(string selectedReportingMark = null)
        {
            try
            {
                dgvRollingStock.Rows.Clear();

                Dictionary<string, object> filteredStock = stockByReportingMark.OrderBy(kvp => kvp.Key).Skip(skip).Take(take).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                lblRecordCount.Text = $"Displaying {skip + 1}-{(skip + take > total ? total : skip + take)} of {total}";

                cmdFirst.Enabled = skip > 0;
                cmdPrevious.Enabled = skip > 0;
                cmdNext.Enabled = skip + take < total;
                cmdLast.Enabled = skip + take < total;

                foreach (KeyValuePair<string, object> kvp in filteredStock)
                {
                    int rowIndex = dgvRollingStock.Rows.Add();
                    DataGridViewRow row = dgvRollingStock.Rows[rowIndex];

                    row.Cells[colReportingMark.Name].Value = kvp.Key;

                    if (kvp.Value is Locomotive locomotive)
                    {
                        row.Cells[colModel.Name].Value = locomotive.LocomotiveModel.Name;
                        row.Cells[colCurrentLocation.Name].Value = locomotive.Location;
                        row.Cells[colOwner.Name].Value = locomotive.CompanyOwner?.Name ?? locomotive.GovernmentOwner?.Name;
                        row.Cells[colType.Name].Value = "Locomotive";
                        row.Tag = locomotive;
                    }
                    else if (kvp.Value is Railcar railcar)
                    {
                        row.Cells[colModel.Name].Value = railcar.RailcarModel.Name;
                        row.Cells[colCurrentLocation.Name].Value = railcar.Location;
                        row.Cells[colOwner.Name].Value = railcar.CompanyOwner?.Name ?? railcar.GovernmentOwner?.Name;
                        row.Cells[colDestination.Name].Value = railcar.TrackDestination?.Name;
                        row.Cells[colType.Name].Value = "Railcar";
                        row.Tag = railcar;
                    }
                }

                dgvRollingStock.ClearSelection();
                if (string.IsNullOrEmpty(selectedReportingMark) && dgvRollingStock.Rows.Count > 0)
                {
                    dgvRollingStock.Rows[0].Selected = true;
                    if (dgvRollingStock.SelectedRows[0].Tag is Locomotive locomotive)
                    {
                        LocomotiveSelected?.Invoke(this, locomotive);
                    }

                    if (dgvRollingStock.SelectedRows[0].Tag is Railcar railcar)
                    {
                        RailcarSelected?.Invoke(this, railcar);
                    }
                }
                else if (!string.IsNullOrEmpty(selectedReportingMark))
                {
                    foreach (DataGridViewRow row in dgvRollingStock.Rows)
                    {
                        string reportingMark = "";
                        if (row.Tag is Locomotive locomotive)
                        {
                            reportingMark = $"{locomotive.ReportingMark}{locomotive.ReportingNumber}";
                        }

                        if (row.Tag is Railcar railcar)
                        {
                            reportingMark = $"{railcar.ReportingMark}{railcar.ReportingNumber}";
                        }

                        if (string.Equals(reportingMark, selectedReportingMark, StringComparison.OrdinalIgnoreCase))
                        {
                            row.Selected = true;
                        }
                    }
                }
                GetData getImage = _application.GetAccess<GetData>();
                getImage.API = DataAccess.APIs.FleetTracking;

                foreach (DataGridViewRow row in dgvRollingStock.Rows)
                {
                    byte[] imageData = null;
                    if (row.Tag is Locomotive locomotive)
                    {
                        getImage.Resource = $"Locomotive/GetImage/{locomotive.LocomotiveID}";

                        imageData = await getImage.GetObject<byte[]>();
                    }
                    else if (row.Tag is Railcar railcar)
                    {
                        getImage.Resource = $"Railcar/GetImage/{railcar.RailcarID}";

                        imageData = await getImage.GetObject<byte[]>();
                    }

                    if (imageData != null)
                    {
                        using (MemoryStream stream = new MemoryStream(imageData))
                        {
                            Image image = Image.FromStream(stream);
                            row.Cells[colImage.Name].Value = image;
                        }
                    }
                }
            }
            catch { }
        }

        private async Task<Dictionary<string, object>> LoadLocomotives(string selectedReportingMark)
        {
            GetData getLocomotives = _application.GetAccess<GetData>();
            getLocomotives.API = DataAccess.APIs.FleetTracking;
            getLocomotives.Resource = "Locomotive/GetAll";
            List<Locomotive> locomotives = await getLocomotives.GetObject<List<Locomotive>>() ?? new List<Locomotive>();

            if (LocomotiveFilter != null)
            {
                locomotives = locomotives.Where(LocomotiveFilter).ToList();
            }

            return locomotives.ToDictionary(l => l.FormattedReportingMark, l => (object)l);
        }

        private async Task<Dictionary<string, object>> LoadRailcars(string selectedReportingMark)
        {
            GetData getLocomotives = _application.GetAccess<GetData>();
            getLocomotives.API = DataAccess.APIs.FleetTracking;
            getLocomotives.Resource = "Railcar/GetAll";
            List<Railcar> railcars = await getLocomotives.GetObject<List<Railcar>>() ?? new List<Railcar>();

            if (RailcarFilter != null)
            {
                railcars = railcars.Where(RailcarFilter).ToList();
            }

            return railcars.ToDictionary(r => r.FormattedReportingMark, r => (object)r);
        }

        private void dgvRollingStock_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRollingStock.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvRollingStock.SelectedRows[0];
                if (selectedRow.Tag is Locomotive locomotive)
                {
                    LocomotiveSelected?.Invoke(this, locomotive);
                }
                else if (selectedRow.Tag is Railcar railcar)
                {
                    RailcarSelected?.Invoke(this, railcar);
                }
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

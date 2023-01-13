using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FleetTracking.Interop;
using FleetTracking.Models;
using MesaSuite.Common.Data;

namespace FleetTracking.Roster
{
    public partial class RollingStockList : UserControl, IFleetTrackingControl
    {
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

            await LoadData();
        }

        public async Task LoadData(string selectedReportingMark = null)
        {
            try
            {
                loader.BringToFront();
                loader.Visible = true;

                dgvRollingStock.Rows.Clear();
                await LoadLocomotives(selectedReportingMark);
                await LoadRailcars(selectedReportingMark);

                dgvRollingStock.Sort(colReportingMark, System.ComponentModel.ListSortDirection.Ascending);

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
                    foreach(DataGridViewRow row in dgvRollingStock.Rows)
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
            }
            finally
            {
                loader.Visible = false;
            }

            try
            {
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

        private async Task LoadLocomotives(string selectedReportingMark)
        {
            GetData getLocomotives = _application.GetAccess<GetData>();
            getLocomotives.API = DataAccess.APIs.FleetTracking;
            getLocomotives.Resource = "Locomotive/GetAll";
            List<Locomotive> locomotives = await getLocomotives.GetObject<List<Locomotive>>() ?? new List<Locomotive>();

            if (LocomotiveFilter != null)
            {
                locomotives = locomotives.Where(LocomotiveFilter).ToList();
            }

            foreach (Locomotive locomotive in locomotives)
            {
                int rowIndex = dgvRollingStock.Rows.Add();
                DataGridViewRow row = dgvRollingStock.Rows[rowIndex];

                string reportingMark = locomotive.ReportingMark + locomotive.ReportingNumber;
                row.Cells[colReportingMark.Name].Value = reportingMark;
                row.Cells[colModel.Name].Value = locomotive.LocomotiveModel?.Name;
                row.Cells[colOwner.Name].Value = locomotive.CompanyOwner?.Name ?? locomotive.GovernmentOwner?.Name;
                row.Cells[colCurrentLocation.Name].Value = locomotive.Location;
                row.Cells[colType.Name].Value = "Locomotive";
                row.Tag = locomotive;
            }
        }

        private async Task LoadRailcars(string selectedReportingMark)
        {
            GetData getLocomotives = _application.GetAccess<GetData>();
            getLocomotives.API = DataAccess.APIs.FleetTracking;
            getLocomotives.Resource = "Railcar/GetAll";
            List<Railcar> railcars = await getLocomotives.GetObject<List<Railcar>>() ?? new List<Railcar>();

            if (RailcarFilter != null)
            {
                railcars = railcars.Where(RailcarFilter).ToList();
            }

            foreach (Railcar railcar in railcars)
            {
                int rowIndex = dgvRollingStock.Rows.Add();
                DataGridViewRow row = dgvRollingStock.Rows[rowIndex];

                string reportingMark = railcar.ReportingMark + railcar.ReportingNumber;
                row.Cells[colReportingMark.Name].Value = reportingMark;
                row.Cells[colModel.Name].Value = railcar.RailcarModel?.Name;
                row.Cells[colOwner.Name].Value = railcar.CompanyOwner?.Name ?? railcar.GovernmentOwner?.Name;
                row.Cells[colCurrentLocation.Name].Value = railcar.Location;
                row.Cells[colDestination.Name].Value = railcar.TrackDestination?.Name;
                row.Cells[colType.Name].Value = "Railcar";
                row.Tag = railcar;

                if (!string.IsNullOrEmpty(reportingMark) && string.Equals(reportingMark, selectedReportingMark, StringComparison.OrdinalIgnoreCase))
                {
                    row.Selected = true;
                }
            }
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
    }
}

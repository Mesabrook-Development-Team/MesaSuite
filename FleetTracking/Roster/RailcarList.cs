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
            await LoadData();
        }

        public async Task LoadData(string selectedReportingMark = null)
        {
            loader.BringToFront();
            loader.Visible = true;

            try
            {
                dgvRailcars.Rows.Clear();

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = $"Railcar/GetAll";

                List<Models.Railcar> railcars = await get.GetObject<List<Models.Railcar>>() ?? new List<Models.Railcar>();
                if (Filter != null)
                {
                    railcars = railcars.Where(Filter).ToList();
                }

                foreach (Models.Railcar railcar in railcars)
                {
                    int rowIndex = dgvRailcars.Rows.Add();
                    DataGridViewRow row = dgvRailcars.Rows[rowIndex];

                    string reportingMark = $"{railcar.ReportingMark}{railcar.ReportingNumber}";
                    row.Cells[colReportingMark.Name].Value = reportingMark;
                    row.Cells[colModel.Name].Value = railcar.RailcarModel.Name;
                    row.Cells[colCurrentLocation.Name].Value = railcar.Location;
                    row.Cells[colDestination.Name].Value = railcar.TrackDestination?.Name;
                    row.Cells[colLoad.Name].Value = railcar.FormattedRailcarLoads;
                    row.Cells[colOwner.Name].Value = $"{railcar.CompanyOwner?.Name ?? railcar.GovernmentOwner?.Name}";
                    row.Tag = railcar;

                    if (string.Equals(reportingMark, selectedReportingMark, StringComparison.OrdinalIgnoreCase))
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
            }
            finally
            {
                loader.Visible = false;
            }

            try
            {
                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;

                foreach (DataGridViewRow row in dgvRailcars.Rows)
                {
                    Models.Railcar railcar = row.Tag as Models.Railcar;
                    if (railcar == null)
                    {
                        continue;
                    }

                    get.Resource = $"Railcar/GetImage/{railcar.RailcarID}";
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
    }
}

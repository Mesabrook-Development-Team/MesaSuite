using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class LocomotiveList : UserControl, IFleetTrackingControl
    {
        private const int take = 15;
        private int skip = 0;
        private int total = 0;

        Dictionary<string, Locomotive> stockByReportingMark = new Dictionary<string, Locomotive>();

        public event EventHandler<Locomotive> LocomotiveSelected;
        public Func<Locomotive, bool> Filter { get; set; }
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

        private FleetTrackingApplication _application;

        public FleetTrackingApplication Application { set => _application = value; }

        public IReadOnlyCollection<Models.Locomotive> SelectedLocomotives => dgvLocomotives.SelectedRows.OfType<DataGridViewRow>().Select(row => row.Tag).OfType<Models.Locomotive>().ToList();

        public bool AllowMultiSelect { get; set; } = true;


        public LocomotiveList()
        {
            InitializeComponent();
            dataGridViewStylizer.ApplyStyle(dgvLocomotives);

            dgvLocomotives.MultiSelect = AllowMultiSelect;
        }

        private async void LocomotiveList_Load(object sender, EventArgs e)
        {
            dataGridViewStylizer.ApplyStyle(dgvLocomotives);
            dgvLocomotives.MultiSelect = true;

            await RetrieveData();
        }

        public async Task RetrieveData(string selectedReportingMark = null)
        {
            try
            {
                loader.BringToFront();
                loader.Visible = true;

                dgvLocomotives.Rows.Clear();

                GetData getLocomotives = _application.GetAccess<GetData>();
                getLocomotives.API = DataAccess.APIs.FleetTracking;
                getLocomotives.Resource = "Locomotive/GetAll";
                List<Locomotive> locomotives = await getLocomotives.GetObject<List<Locomotive>>() ?? new List<Locomotive>();

                if (Filter != null)
                {
                    locomotives = locomotives.Where(Filter).ToList();
                }
                stockByReportingMark = locomotives.ToDictionary(l => l.FormattedReportingMark);
                total = locomotives.Count;
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
                dgvLocomotives.Rows.Clear();

                Dictionary<string, Locomotive> filteredStock = stockByReportingMark.OrderBy(kvp => kvp.Key).Skip(skip).Take(take).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                lblRecordCount.Text = $"Displaying {skip + 1}-{(skip + take > total ? total : skip + take)} of {total}";

                cmdFirst.Enabled = skip > 0;
                cmdPrevious.Enabled = skip > 0;
                cmdNext.Enabled = skip + take < total;
                cmdLast.Enabled = skip + take < total;

                foreach (KeyValuePair<string, Locomotive> kvp in filteredStock)
                {
                    int rowIndex = dgvLocomotives.Rows.Add();
                    DataGridViewRow row = dgvLocomotives.Rows[rowIndex];

                    row.Cells[colReportingMark.Name].Value = kvp.Key;
                    Locomotive locomotive = kvp.Value;

                    row.Cells[colModel.Name].Value = locomotive.LocomotiveModel?.Name;
                    row.Cells[colOwner.Name].Value = locomotive.CompanyOwner?.Name ?? locomotive.GovernmentOwner?.Name;
                    row.Cells[colCurrentLocation.Name].Value = locomotive.Location;
                    row.Tag = locomotive;

                    if (!string.IsNullOrEmpty(kvp.Key) && string.Equals(kvp.Key, selectedReportingMark, StringComparison.OrdinalIgnoreCase))
                    {
                        row.Selected = true;
                    }
                }

                dgvLocomotives.Sort(colReportingMark, System.ComponentModel.ListSortDirection.Ascending);
                dgvLocomotives.ClearSelection();
                if (string.IsNullOrEmpty(selectedReportingMark) && dgvLocomotives.Rows.Count > 0)
                {
                    dgvLocomotives.Rows[0].Selected = true;
                    Locomotive locomotive = dgvLocomotives.Rows[0].Tag as Locomotive;
                    if (locomotive != null)
                    {
                        LocomotiveSelected?.Invoke(this, locomotive);
                    }
                }
                else if (!string.IsNullOrEmpty(selectedReportingMark))
                {
                    DataGridViewRow row = dgvLocomotives.Rows.Cast<DataGridViewRow>().FirstOrDefault(fodRow => fodRow.Tag is Models.Locomotive locomotive && string.Equals(selectedReportingMark, $"{locomotive.ReportingMark}{locomotive.ReportingNumber}"));
                    if (row != null)
                    {
                        row.Selected = true;
                    }
                }

                GetData getImage = _application.GetAccess<GetData>();
                getImage.API = DataAccess.APIs.FleetTracking;

                foreach (DataGridViewRow row in dgvLocomotives.Rows)
                {
                    Locomotive locomotive = row.Tag as Locomotive;
                    if (locomotive == null)
                    {
                        continue;
                    }

                    getImage.Resource = $"Locomotive/GetImage/{locomotive.LocomotiveID}";
                    byte[] imageData = await getImage.GetObject<byte[]>();

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

        private void dgvLocomotives_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLocomotives.SelectedRows.Count > 0 && dgvLocomotives.SelectedRows[0].Tag is Locomotive locomotive)
            {
                LocomotiveSelected?.Invoke(this, locomotive);
            }
        }

        private void ReportingMarkFilterChanged()
        {
            foreach(DataGridViewRow row in dgvLocomotives.Rows)
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

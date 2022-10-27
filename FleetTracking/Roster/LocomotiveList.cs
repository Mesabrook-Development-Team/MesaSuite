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


        public LocomotiveList()
        {
            InitializeComponent();
        }

        private async void LocomotiveList_Load(object sender, EventArgs e)
        {
            dataGridViewStylizer.ApplyStyle(dgvLocomotives);
            dgvLocomotives.MultiSelect = true;

            await LoadData();
        }

        public async Task LoadData(string selectedReportingMark = null)
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

                foreach (Locomotive locomotive in locomotives)
                {
                    int rowIndex = dgvLocomotives.Rows.Add();
                    DataGridViewRow row = dgvLocomotives.Rows[rowIndex];

                    string reportingMark = locomotive.ReportingMark + locomotive.ReportingNumber;
                    row.Cells[colReportingMark.Name].Value = reportingMark;
                    row.Cells[colModel.Name].Value = locomotive.LocomotiveModel?.Name;
                    row.Cells[colOwner.Name].Value = locomotive.CompanyOwner?.Name ?? locomotive.GovernmentOwner?.Name;
                    row.Cells[colCurrentLocation.Name].Value = "Your mom's house";
                    row.Tag = locomotive;

                    if (!string.IsNullOrEmpty(reportingMark) && string.Equals(reportingMark, selectedReportingMark, StringComparison.OrdinalIgnoreCase))
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
            }
            finally
            {
                loader.Visible = false;
            }

            try
            {
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
    }
}

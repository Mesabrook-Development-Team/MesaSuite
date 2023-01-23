using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FleetTracking.Interop;
using MesaSuite.Common.Data;

namespace FleetTracking.Reports.TrainManifest
{
    public partial class SelectTrains : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }
        public SelectTrains()
        {
            InitializeComponent();
            dataGridViewStylizer.ApplyStyle(dgvTrains);
            dgvTrains.ReadOnly = false;
            colStartTime.ReadOnly = true;
            colEndTime.ReadOnly = true;
            colSymbol.ReadOnly = true;
            colOperator.ReadOnly = true;
            colCheck.ValueType = typeof(bool?);
        }

        private async void SelectTrains_Load(object sender, EventArgs e)
        {
            try
            {
                ParentForm.Text = "Select Trains To Print";

                loader.BringToFront();
                loader.Visible = true;

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = "Train/GetFiltered";
                get.QueryString.Add("operableonly", bool.FalseString);
                var response = new
                {
                    maxItems = 0,
                    trains = new List<Models.Train>()
                };
                response = await get.GetAnonymousObject(response);
                List<Models.Train> trains = response?.trains ?? new List<Models.Train>();

                foreach (Models.Train train in trains)
                {
                    int rowIndex = dgvTrains.Rows.Add();
                    DataGridViewRow row = dgvTrains.Rows[rowIndex];
                    row.Cells[colStartTime.Name].Value = train.TimeOnDuty?.ToString("MM/dd/yyyy HH:mm") ?? "--/--/---- --:--";
                    row.Cells[colEndTime.Name].Value = train.TrainDutyTransactions?.OrderByDescending(tdt => tdt.TimeOffDuty).FirstOrDefault()?.TimeOffDuty?.ToString("MM/dd/yyyy HH:mm") ?? "--/--/---- --:--";
                    row.Cells[colSymbol.Name].Value = train.TrainSymbol?.Name;
                    row.Cells[colOperator.Name].Value = train.TrainSymbol?.CompanyOperator?.Name ?? train.TrainSymbol?.GovernmentOperator?.Name;
                    row.Tag = train;
                }
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private void dgvTrains_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvTrains.Rows.Count || e.ColumnIndex != colCheck.Index)
            {
                return;
            }

            dgvTrains[e.ColumnIndex, e.RowIndex].Value = !((dgvTrains[e.ColumnIndex, e.RowIndex].Value as bool?) ?? false);
        }

        private void toolCheckAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTrains.Rows.OfType<DataGridViewRow>().Where(dgvr => dgvr.Visible))
            {
                row.Cells[colCheck.Name].Value = true;
            }
        }

        private void toolUncheckAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTrains.Rows.OfType<DataGridViewRow>().Where(dgvr => dgvr.Visible))
            {
                row.Cells[colCheck.Name].Value = false;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTrains.Rows)
            {
                bool visible = true;
                if (!string.IsNullOrEmpty(txtSearch.Text))
                {
                    visible = (row.Cells[colStartTime.Name].Value?.ToString().Contains(txtSearch.Text) ?? false) ||
                              (row.Cells[colEndTime.Name].Value?.ToString().Contains(txtSearch.Text) ?? false) ||
                              (row.Cells[colSymbol.Name].Value?.ToString().Contains(txtSearch.Text) ?? false) ||
                              (row.Cells[colOperator.Name].Value?.ToString().Contains(txtSearch.Text) ?? false);
                }

                row.Visible = visible;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            ParentForm?.Close();
            Dispose();
        }

        private void cmdRunReport_Click(object sender, EventArgs e)
        {
            List<long?> trainIDs = new List<long?>();
            foreach (DataGridViewRow row in dgvTrains.Rows)
            {
                if (!(row.Cells[colCheck.Name].Value as bool? ?? false) || !(row.Tag is Models.Train train))
                {
                    continue;
                }

                trainIDs.Add(train.TrainID);
            }

            PrintableReport report = new PrintableReport()
            {
                Application = _application,
                ReportContext = new TrainManifestReportContext(_application, trainIDs) { Application = _application }
            };
            _application.OpenForm(report);
            ParentForm?.Close();
            Dispose();
        }
    }
}

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
using FleetTracking.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;

namespace FleetTracking.Leasing
{
    public partial class SubmitBidsDetail : UserControl, IFleetTrackingControl
    {
        public SubmitBidsDetail()
        {
            InitializeComponent();

            dataGridViewStylizer.ApplyStyle(dgvRequests);
            dgvRequests.MultiSelect = true;
        }

        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public IEnumerable<LeaseRequest> SelectedLeaseRequests
        {
            get
            {
                foreach(DataGridViewRow row in dgvRequests.SelectedRows)
                {
                    yield return row.Tag as LeaseRequest;
                }
            }
        }

        public IEnumerable<LeaseRequest> AllLeaseRequests
        {
            get
            {
                foreach (DataGridViewRow row in dgvRequests.Rows)
                {
                    yield return row.Tag as LeaseRequest;
                }
            }
        }

        private async void dgvRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != colRollingStock.Index)
            {
                return;
            }

            LeaseRequest request = dgvRequests.Rows[e.RowIndex].Tag as LeaseRequest;
            if (request == null)
            {
                return;
            }

            SubmitBidsStockPicker stockPicker = new SubmitBidsStockPicker()
            {
                Application = _application,
                LeaseType = request.LeaseType
            };
            Form pickerForm = _application.OpenForm(stockPicker, FleetTrackingApplication.OpenFormOptions.Dialog | FleetTrackingApplication.OpenFormOptions.ResizeToControl);
            if (pickerForm.DialogResult != DialogResult.OK)
            {
                return;
            }

            DataGridViewButtonCell buttonCell = (DataGridViewButtonCell)dgvRequests[e.ColumnIndex, e.RowIndex];
            buttonCell.Tag = stockPicker.SelectedRollingStockID;

            if (stockPicker.SelectedRollingStockID == null)
            {
                buttonCell.Value = "[click to select]";
            }
            else
            {
                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;

                switch (request.LeaseType)
                {
                    case LeaseRequest.LeaseTypes.Locomotive:
                        get.Resource = $"Locomotive/Get/{stockPicker.SelectedRollingStockID}";
                        Locomotive locomotive = await get.GetObject<Locomotive>();
                        buttonCell.Value = locomotive?.FormattedReportingMark ?? "[click to select]";
                        break;
                    case LeaseRequest.LeaseTypes.Railcar:
                        get.Resource = $"Railcar/Get/{stockPicker.SelectedRollingStockID}";
                        Railcar railcar = await get.GetObject<Railcar>();
                        buttonCell.Value = railcar?.FormattedReportingMark ?? "[click to select]";
                        break;
                }
            }
        }

        private void dgvRequests_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvRequests.Rows[e.RowIndex];
            LeaseRequest request = row.Tag as LeaseRequest;
            if (request == null)
            {
                return;
            }

            LeaseRequestDetail detail = new LeaseRequestDetail()
            {
                Application = _application,
                LeaseRequestID = request.LeaseRequestID
            };
            _application.OpenForm(detail);
        }

        public void AddLeaseRequest(LeaseRequest leaseRequest)
        {
            int rowIndex = dgvRequests.Rows.Add();

            DataGridViewRow row = dgvRequests.Rows[rowIndex];
            row.Cells[colLeaseRequest.Name].Value = $"({leaseRequest.LeaseRequestID}) {leaseRequest.CompanyRequester.Name}{leaseRequest.GovernmentRequester.Name}";
            row.Cells[colType.Name].Value = leaseRequest.LeaseType.ToString().ToDisplayName();
            row.Cells[colEndTime.Name].Value = leaseRequest.BidEndTime?.ToString("MM/dd/yyyy HH:mm");
            row.Cells[colPurpose.Name].Value = leaseRequest.Purpose;
            row.Cells[colRollingStock.Name].Value = "[click to select]";
            row.Tag = leaseRequest;
        }

        public void RemoveSelectedRequests()
        {
            foreach(DataGridViewRow row in dgvRequests.SelectedRows.OfType<DataGridViewRow>().ToList())
            {
                dgvRequests.Rows.Remove(row);
            }
        }
    }
}

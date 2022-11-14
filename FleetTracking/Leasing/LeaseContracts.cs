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
using FleetTracking.Models;
using MesaSuite.Common.Data;

namespace FleetTracking.Leasing
{
    public partial class LeaseContracts : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public LeaseContracts()
        {
            InitializeComponent();
            dataGridViewStylizer.ApplyStyle(dgvContracts);
        }
        private async void LeaseContracts_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                loader.BringToFront();
                loader.Visible = true;

                dgvContracts.Rows.Clear();

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = "LeaseContract/GetAll";

                List<LeaseContract> leaseContracts = await get.GetObject<List<LeaseContract>>() ?? new List<LeaseContract>();
                foreach (LeaseContract leaseContract in leaseContracts)
                {
                    int rowIndex = dgvContracts.Rows.Add();
                    DataGridViewRow row = dgvContracts.Rows[rowIndex];

                    row.Cells[colReportingMark.Name].Value = leaseContract.Railcar?.FormattedReportingMark ?? leaseContract.Locomotive?.FormattedReportingMark;
                    row.Cells[colLeasedTo.Name].Value = leaseContract.CompanyLessee?.Name ?? leaseContract.GovernmentLessee?.Name;
                    row.Cells[colLeaseStart.Name].Value = leaseContract.LeaseTimeStart?.ToString("MM/dd/yyyy");
                    row.Cells[colLeaseEnd.Name].Value = leaseContract.LeaseTimeEnd?.ToString("MM/dd/yyyy");
                    row.Tag = leaseContract;
                }

                Filter_CheckedChanged(rdoCurrent, EventArgs.Empty);
            }
            finally
            {
                loader.Visible = false;
            }

            try
            {
                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                foreach(DataGridViewRow row in dgvContracts.Rows)
                {
                    LeaseContract leaseContract = row.Tag as LeaseContract;
                    if (leaseContract == null)
                    {
                        continue;
                    }

                    byte[] imageData = null;
                    if (leaseContract.RailcarID != null)
                    {
                        get.Resource = $"Railcar/GetImage/{leaseContract.RailcarID}";
                        imageData = await get.GetObject<byte[]>();
                    }
                    else if (leaseContract.LocomotiveID != null)
                    {
                        get.Resource = $"Locomotive/GetImage/{leaseContract.LocomotiveID}";
                        imageData = await get.GetObject<byte[]>();
                    }

                    if (imageData == null)
                    {
                        continue;
                    }

                    using (MemoryStream stream = new MemoryStream(imageData))
                    {
                        Image image = Image.FromStream(stream);
                        row.Cells[colImage.Name].Value = image;
                    }
                }
            }
            catch { }
        }

        private void Filter_CheckedChanged(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked)
            {
                return;
            }

            foreach(DataGridViewRow row in dgvContracts.Rows)
            {
                row.Visible = true;

                LeaseContract contract = row.Tag as LeaseContract;
                if (contract == null)
                {
                    continue;
                }

                if (rdoCurrent.Checked)
                {
                    row.Visible = contract.LeaseTimeEnd == null;
                }
                else if (rdoHistoric.Checked)
                {
                    row.Visible = contract.LeaseTimeEnd != null;
                }
            }
        }

        private void dgvContracts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvContracts.Rows.Count)
            {
                return;
            }

            DataGridViewRow row = dgvContracts.Rows[e.RowIndex];
            LeaseContract contract = row.Tag as LeaseContract;
            if (contract == null)
            {
                return;
            }

            LeaseContractDetails detailsScreen = new LeaseContractDetails()
            {
                Application = _application,
                LeaseContractID = contract.LeaseContractID,
            };
            detailsScreen.OnSave += DetailsScreen_OnSave;
            Form form = _application.OpenForm(detailsScreen);
            form.Text = "Lease Contract";
            form.FormClosed += (s, ea) => LoadData();
        }

        private void DetailsScreen_OnSave(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FleetTracking.Attributes;
using FleetTracking.Interop;
using FleetTracking.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;

namespace FleetTracking.CarLoading
{
    [SecuredControl(SecuredControlAttribute.Permissions.AllowLoadUnload)]
    public partial class LoadOnTrack : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public LoadOnTrack()
        {
            InitializeComponent();
            dataGridViewStylizer.ApplyStyle(dgvRailcars);
            dataGridViewStylizer.ApplyStyle(dgvLoads);
            dgvRailcars.ReadOnly = false;
            dgvLoads.ReadOnly = false;
            colQuantity.ValueType = typeof(decimal?);

            colReportingMark.ReadOnly = true;
            colCurrentLoad.ReadOnly = true;
            colClear.ReadOnly = true;
            colItem.ReadOnly = true;
        }

        private void LoadOnTrack_Paint(object sender, PaintEventArgs e)
        {
            int y = lblMassLoadDetails.Top + (lblMassLoadDetails.Height / 2);
            int x = lblMassLoadDetails.Right + 2;
            e.Graphics.DrawLine(Pens.Black, x, y, Width - 4, y);

            y = lblRailcars.Top + (lblRailcars.Height / 2);
            x = lblRailcars.Right + 2;
            e.Graphics.DrawLine(Pens.Black, x, y, Width - 4, y);
        }

        private async void LoadOnTrack_Load(object sender, EventArgs e)
        {
            try
            {
                loader.BringToFront();
                loader.Visible = true;

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                (long?, long?) companyGovernmentID = _application.GetCurrentCompanyIDGovernmentID();
                if (companyGovernmentID.Item1 != null)
                {
                    get.Resource = $"Track/GetByCompany/{companyGovernmentID.Item1}";
                }
                else
                {
                    get.Resource = $"Track/GetByGovernment/{companyGovernmentID.Item2}";
                }

                List<Track> tracks = await get.GetObject<List<Track>>() ?? new List<Track>();
                foreach(Track track in tracks)
                {
                    DropDownItem<Track> trackDDI = new DropDownItem<Track>(track, track.Name);
                    cboTrack.Items.Add(trackDDI);
                }
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private async void cboTrack_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadRailcars();
        }

        private async Task LoadRailcars()
        {
            DropDownItem<Track> track = cboTrack.SelectedItem as DropDownItem<Track>;
            if (track == null)
            {
                return;
            }

            long? selectedRailcarID = null;
            if (dgvRailcars.SelectedRows.Count > 0)
            {
                selectedRailcarID = (dgvRailcars.SelectedRows[0].Tag as Railcar)?.RailcarID;
            }

            try
            {
                loader.BringToFront();
                loader.Visible = true;

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = $"Railcar/GetReleasedByTrack/{track.Object.TrackID}";
                List<Railcar> railcars = await get.GetObject<List<Railcar>>() ?? new List<Railcar>();

                dgvRailcars.Rows.Clear();
                foreach (Railcar railcar in railcars)
                {
                    int rowIndex = dgvRailcars.Rows.Add();
                    DataGridViewRow row = dgvRailcars.Rows[rowIndex];
                    row.Cells[colReportingMark.Name].Value = railcar.FormattedReportingMark;
                    row.Cells[colCurrentLoad.Name].Value = railcar.FormattedRailcarLoads;
                    row.Tag = railcar;
                }

                if (selectedRailcarID != null)
                {
                    foreach(DataGridViewRow row in dgvRailcars.Rows)
                    {
                        row.Selected = row.Tag is Railcar railcar && railcar.RailcarID == selectedRailcarID;

                        if (row.Selected)
                        {
                            break;
                        }
                    }
                }
            }
            finally
            {
                loader.Visible = false;
            }

            LoadIndividualLoads();
        }

        private void toolCheckAll_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dgvRailcars.Rows)
            {
                row.Cells[colCheck.Name].Value = true;
            }
        }

        private void toolUncheckAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvRailcars.Rows)
            {
                row.Cells[colCheck.Name].Value = false;
            }
        }

        private void dgvRailcars_SelectionChanged(object sender, EventArgs e)
        {
            LoadIndividualLoads();
        }

        private void LoadIndividualLoads()
        {
            long? selectedLoadID = null;
            if (dgvLoads.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvLoads.SelectedRows[0];
                RailcarLoad load = row.Tag as RailcarLoad;

                selectedLoadID = load?.RailcarLoadID;
            }

            dgvLoads.Rows.Clear();

            if (dgvRailcars.SelectedRows.Count <= 0)
            {
                return;
            }

            DataGridViewRow selectedRow = dgvRailcars.SelectedRows[0];
            Railcar railcar = selectedRow.Tag as Railcar;
            if (railcar?.RailcarLoads == null)
            {
                return;
            }

            foreach (RailcarLoad load in railcar.RailcarLoads)
            {
                int rowIndex = dgvLoads.Rows.Add();
                DataGridViewRow row = dgvLoads.Rows[rowIndex];
                row.Cells[colImage.Name].Value = load.Item?.GetImage();
                row.Cells[colItem.Name].Value = load.Item?.Name;
                row.Cells[colQuantity.Name].Value = load.Quantity;
                row.Tag = load;
            }

            if (selectedLoadID != null)
            {
                foreach (DataGridViewRow row in dgvLoads.Rows)
                {
                    RailcarLoad load = row.Tag as RailcarLoad;
                    row.Selected = load != null && load.RailcarLoadID == selectedLoadID;

                    if (row.Selected)
                    {
                        break;
                    }
                }
            }
        }

        private async void dgvRailcars_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvRailcars.Rows.Count)
            {
                return;
            }

            if (e.ColumnIndex == colClear.Index)
            {
                await ClearForRailcarRow(dgvRailcars.Rows[e.RowIndex]);
                await LoadRailcars();
            }

            if (e.ColumnIndex == colCheck.Index)
            {
                dgvRailcars[e.ColumnIndex, e.RowIndex].Value = !(dgvRailcars[e.ColumnIndex, e.RowIndex].Value as bool? ?? false);
            }
        }

        private async Task ClearForRailcarRow(DataGridViewRow row)
        {
            Railcar railcar = row.Tag as Railcar;
            if (railcar == null)
            {
                return;
            }

            try
            {
                loader.BringToFront();
                loader.Visible = true;

                DeleteData delete = _application.GetAccess<DeleteData>();
                delete.API = DataAccess.APIs.FleetTracking;
                delete.Resource = $"RailcarLoad/DeleteForRailcar/{railcar.RailcarID}";
                await delete.Execute();
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private async void dgvLoads_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != colIndClear.Index || e.RowIndex < 0 || e.RowIndex >= dgvLoads.Rows.Count)
            {
                return;
            }

            DataGridViewRow row = dgvLoads.Rows[e.RowIndex];
            RailcarLoad load = row.Tag as RailcarLoad;
            if (load == null)
            {
                return;
            }

            try
            {
                loader.BringToFront();
                loader.Visible = true;

                DeleteData delete = _application.GetAccess<DeleteData>();
                delete.API = DataAccess.APIs.FleetTracking;
                delete.Resource = $"RailcarLoad/Delete/{load.RailcarLoadID}";
                await delete.Execute();
            }
            finally
            {
                loader.Visible = false;
            }

            await LoadRailcars();
        }

        private async void toolClearLoads_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dgvRailcars.Rows)
            {
                bool isChecked = row.Cells[colCheck.Name].Value as bool? ?? false;
                if (!isChecked)
                {
                    continue;
                }

                await ClearForRailcarRow(row);
            }

            await LoadRailcars();
        }

        private async void toolApplyLoad_Click(object sender, EventArgs e)
        {
            if (itemSelect.SelectedID == null || string.IsNullOrEmpty(txtQuantity.Text) || !decimal.TryParse(txtQuantity.Text, out decimal quantity))
            {
                this.ShowError("Mass Load Details must be filled out and valid");
                return;
            }

            try
            {
                loader.BringToFront();
                loader.Visible = true;

                PostData post = _application.GetAccess<PostData>();
                post.API = DataAccess.APIs.FleetTracking;
                post.Resource = "RailcarLoad/Post";

                foreach (DataGridViewRow row in dgvRailcars.Rows)
                {
                    bool isChecked = row.Cells[colCheck.Name].Value as bool? ?? false;
                    if (!isChecked)
                    {
                        continue;
                    }

                    Railcar railcar = row.Tag as Railcar;
                    if (railcar == null)
                    {
                        continue;
                    }

                    RailcarLoad newLoad = new RailcarLoad()
                    {
                        RailcarID = railcar.RailcarID,
                        ItemID = itemSelect.SelectedID,
                        Quantity = quantity
                    };

                    post.ObjectToPost = newLoad;
                    await post.ExecuteNoResult();
                }
            }
            finally
            {
                loader.Visible = false;
            }

            await LoadRailcars();
        }

        private async void dgvLoads_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != colQuantity.Index || e.RowIndex < 0 || e.RowIndex >= dgvLoads.Rows.Count)
            {
                return;
            }

            DataGridViewRow row = dgvLoads.Rows[e.RowIndex];
            RailcarLoad load = row.Tag as RailcarLoad;
            if (load == null)
            {
                return;
            }

            load.Quantity = dgvLoads[e.ColumnIndex, e.RowIndex].Value as decimal?;

            try
            {
                loader.BringToFront();
                loader.Visible = true;

                PutData put = _application.GetAccess<PutData>();
                put.API = DataAccess.APIs.FleetTracking;
                put.Resource = "RailcarLoad/Put";
                put.ObjectToPut = load;
                await put.ExecuteNoResult();
            }
            finally
            {
                loader.Visible = false;
            }

            await LoadRailcars();
        }
    }
}

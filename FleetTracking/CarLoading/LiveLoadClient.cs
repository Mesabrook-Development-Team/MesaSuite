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

namespace FleetTracking.CarLoading
{
    [SecuredControl(SecuredControlAttribute.Permissions.AllowLoadUnload)]
    public partial class LiveLoadClient : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        private long? SessionID { get; set; }
        private long? TrainID { get; set; }
        public string LiveLoadCode { get; set; }

        public LiveLoadClient()
        {
            InitializeComponent();
            dataGridViewStylizer.ApplyStyle(dgvRailcars);
            dgvRailcars.ReadOnly = false;
            colReportingMark.ReadOnly = true;
            colCurrentLoad.ReadOnly = true;

            dataGridViewStylizer.ApplyStyle(dgvLoads);
            dgvLoads.ReadOnly = false;
            colItem.ReadOnly = true;
            colQuantity.ValueType = typeof(decimal?);
        }

        private async void LiveLoadClient_Load(object sender, EventArgs e)
        {
            ParentForm.FormClosing += ParentForm_FormClosing;
            try
            {
                loader.BringToFront();
                loader.Visible = true;

                PostData post = _application.GetAccess<PostData>();
                post.API = DataAccess.APIs.FleetTracking;
                post.Resource = "LiveLoadSession/GenerateSession";
                post.ObjectToPost = new { Code = LiveLoadCode };
                LiveLoadSession session = await post.Execute<LiveLoadSession>();
                if (session == null)
                {
                    ParentForm?.Close();
                    Dispose();
                    return;
                }

                SessionID = session.LiveLoadSessionID;
                TrainID = session.LiveLoad?.TrainID;
                txtTrain.Text = session.LiveLoad?.Train?.TimeOnDuty?.ToString("MM/dd/yyyy HH:mm") + " - " + session.LiveLoad?.Train?.TrainSymbol?.Name;
                tmrSession.Enabled = true;

                LoadRailcars();
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private async void LoadRailcars()
        {
            try
            {
                loader.BringToFront();
                loader.Visible = true;

                long? selectedRailcarID = null;
                if (dgvRailcars.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvRailcars.SelectedRows[0];
                    Railcar railcar = row.Tag as Railcar;
                    selectedRailcarID = railcar?.RailcarID;
                }

                GetData getRailcars = _application.GetAccess<GetData>();
                getRailcars.API = DataAccess.APIs.FleetTracking;
                getRailcars.Resource = $"RailLocation/GetByTrain/{TrainID}";
                List<Railcar> railcars = (await getRailcars.GetObject<List<RailLocation>>() ?? new List<RailLocation>()).Where(rl => rl.RailcarID != null).Select(rl => rl.Railcar).ToList();

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
                    foreach (DataGridViewRow row in dgvRailcars.Rows)
                    {
                        Railcar railcar = row.Tag as Railcar;
                        if (railcar?.RailcarID == selectedRailcarID)
                        {
                            row.Selected = true;
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

        private void LoadIndividualLoads()
        {
            if (dgvRailcars.SelectedRows.Count <= 0)
            {
                return;
            }

            dgvLoads.Rows.Clear();
            Railcar railcar = dgvRailcars.SelectedRows[0].Tag as Railcar;
            if (railcar == null || railcar.RailcarLoads == null)
            {
                return;
            }

            foreach(RailcarLoad load in railcar.RailcarLoads)
            {
                int rowIndex = dgvLoads.Rows.Add();
                DataGridViewRow row = dgvLoads.Rows[rowIndex];

                row.Cells[colImage.Name].Value = load.Item?.GetImage();
                row.Cells[colItem.Name].Value = load.Item?.Name;
                row.Cells[colQuantity.Name].Value = load.Quantity;
                row.Tag = load;
            }
        }

        private async void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeleteData delete = _application.GetAccess<DeleteData>();
            delete.API = DataAccess.APIs.FleetTracking;
            delete.Resource = $"LiveLoadSession/Delete/{SessionID}";
            delete.SuppressErrors = true;
            await delete.Execute();
        }

        private async void tmrSession_Tick(object sender, EventArgs e)
        {
            tmrSession.Enabled = false;

            PutData put = _application.GetAccess<PutData>();
            put.API = DataAccess.APIs.FleetTracking;
            put.Resource = "LiveLoadSession/Heartbeat";
            put.ObjectToPut = new { SessionID };
            await put.ExecuteNoResult();

            if (!put.RequestSuccessful)
            {
                ParentForm?.Close();
                Dispose();
                return;
            }

            tmrSession.Enabled = true;
        }

        private void dgvRailcars_SelectionChanged(object sender, EventArgs e)
        {
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

        private async void dgvRailcars_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvRailcars.Rows.Count)
            {
                return;
            }

            if (e.ColumnIndex == colCheck.Index)
            {
                dgvRailcars[e.ColumnIndex, e.RowIndex].Value = true;
            }
            else if (e.ColumnIndex == colClear.Index)
            {
                DataGridViewRow row = dgvRailcars.Rows[e.RowIndex];
                Railcar railcar = row.Tag as Railcar;
                if (railcar == null)
                {
                    return;
                }

                try
                {
                    loader.BringToFront();
                    loader.Visible = true;
                    await ClearRailcarLoad(railcar.RailcarID);
                }
                finally
                {
                    loader.Visible = false;
                }

                LoadRailcars();
            }
        }

        private async Task ClearRailcarLoad(long? railcarID)
        {
            DeleteData deleteForCar = _application.GetAccess<DeleteData>();
            deleteForCar.API = DataAccess.APIs.FleetTracking;
            deleteForCar.Resource = $"RailcarLoad/DeleteForRailcar/{railcarID}";
            await deleteForCar.Execute();
        }

        private async void toolClearLoads_Click(object sender, EventArgs e)
        {
            try
            {
                loader.BringToFront();
                loader.Visible = true;

                foreach (DataGridViewRow row in dgvRailcars.Rows)
                {
                    bool isChecked = row.Cells[colCheck.Name].Value as bool? ?? false;
                    if (!isChecked)
                    {
                        continue;
                    }

                    Railcar railcar = row.Tag as Railcar;
                    await ClearRailcarLoad(railcar.RailcarID);
                }
            }
            finally
            {
                loader.Visible = false;
            }

            LoadRailcars();
        }

        private async void toolApplyLoad_Click(object sender, EventArgs e)
        {
            if (itemSelect.SelectedID == null || string.IsNullOrEmpty(txtQuantity.Text) || !decimal.TryParse(txtQuantity.Text, out decimal quantity))
            {
                this.ShowError("All Mass Load Details must be completed");
                return;
            }

            try
            {
                loader.BringToFront();
                loader.Visible = true;

                foreach (DataGridViewRow row in dgvRailcars.Rows)
                {
                    bool isChecked = row.Cells[colCheck.Name].Value as bool? ?? false;
                    if (!isChecked)
                    {
                        continue;
                    }

                    Railcar railcar = row.Tag as Railcar;

                    RailcarLoad load = new RailcarLoad()
                    {
                        RailcarID = railcar?.RailcarID,
                        ItemID = itemSelect.SelectedID,
                        Quantity = quantity
                    };

                    PostData post = _application.GetAccess<PostData>();
                    post.API = DataAccess.APIs.FleetTracking;
                    post.Resource = "RailcarLoad/Post";
                    post.ObjectToPost = load;
                    await post.ExecuteNoResult();
                }
            }
            finally
            {
                loader.Visible = false;
            }

            LoadRailcars();
        }

        private async void dgvLoads_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != colQuantity.Index)
            {
                return;
            }

            DataGridViewRow row = dgvLoads.Rows[e.RowIndex];
            RailcarLoad railcarLoad = row.Tag as RailcarLoad;

            railcarLoad.Quantity = dgvLoads[e.ColumnIndex, e.RowIndex].Value as decimal? ?? 0;

            try
            {
                loader.BringToFront();
                loader.Visible = true;

                PutData put = _application.GetAccess<PutData>();
                put.API = DataAccess.APIs.FleetTracking;
                put.Resource = "RailcarLoad/Put";
                put.ObjectToPut = railcarLoad;
                await put.ExecuteNoResult();
            }
            finally
            {
                loader.Visible = false;
            }

            LoadRailcars();
        }

        private async void dgvLoads_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != colIndClear.Index || e.RowIndex < 0 || e.RowIndex >= dgvLoads.Rows.Count)
            {
                return;
            }

            DataGridViewRow row = dgvLoads.Rows[e.RowIndex];
            RailcarLoad load = row.Tag as RailcarLoad;

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

            LoadRailcars();
        }
    }
}

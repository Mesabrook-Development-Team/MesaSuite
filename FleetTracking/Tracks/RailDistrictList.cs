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

namespace FleetTracking.Tracks
{
    [SecuredControl(SecuredControlAttribute.Permissions.AllowSetup, SecuredControlAttribute.Permissions.IsYardmaster)]
    public partial class RailDistrictList : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public RailDistrictList()
        {
            InitializeComponent();
            dataGridViewStylizer.ApplyStyle(dgvDistricts);
            dgvDistricts.MultiSelect = true;
        }

        private void RailDistrictList_Load(object sender, EventArgs e)
        {
            LoadDistricts();
        }

        private async void LoadDistricts()
        {
            try
            {
                loader.BringToFront();
                loader.Visible = true;

                dgvDistricts.Rows.Clear();

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = "RailDistrict/GetAll";
                List<RailDistrict> railDistricts = await get.GetObject<List<RailDistrict>>() ?? new List<RailDistrict>();

                foreach(RailDistrict railDistrict in railDistricts)
                {
                    int rowIndex = dgvDistricts.Rows.Add();
                    DataGridViewRow row = dgvDistricts.Rows[rowIndex];

                    row.Cells[colName.Name].Value = railDistrict.Name;
                    row.Cells[colOperator.Name].Value = railDistrict.CompanyOperator?.Name ?? railDistrict.GovernmentOperator?.Name;
                    row.Tag = railDistrict;
                }

                dgvDistricts_SelectionChanged(dgvDistricts, EventArgs.Empty);
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private void dgvDistricts_SelectionChanged(object sender, EventArgs e)
        {
            List<RailDistrict> selectedDistricts = dgvDistricts.SelectedRows.Cast<DataGridViewRow>().Where(dgvr => dgvr.Tag is RailDistrict).Select(dgvr => dgvr.Tag as RailDistrict).ToList();

            toolDeleteDistricts.Enabled = selectedDistricts.Any(dis => _application.IsCurrentEntity(dis.CompanyIDOperator, dis.GovernmentIDOperator));
        }

        private async void toolDeleteDistricts_Click(object sender, EventArgs e)
        {
            List<RailDistrict> selectedDistricts = dgvDistricts.SelectedRows.Cast<DataGridViewRow>().Where(dgvr => dgvr.Tag is RailDistrict rd && _application.IsCurrentEntity(rd.CompanyIDOperator, rd.GovernmentIDOperator)).Select(dgvr => dgvr.Tag as RailDistrict).ToList();

            if (!selectedDistricts.Any() || !this.Confirm("Are you sure you want to delete these District(s)?"))
            {
                return;
            }

            try
            {
                loader.BringToFront();
                loader.Visible = true;

                DeleteData delete = _application.GetAccess<DeleteData>();
                delete.API = DataAccess.APIs.FleetTracking;

                foreach(RailDistrict railDistrict in selectedDistricts)
                {
                    delete.Resource = $"RailDistrict/Delete/{railDistrict.RailDistrictID}";
                    await delete.Execute();
                }
            }
            finally
            {
                loader.Visible = false;
            }

            LoadDistricts();
        }

        private void dgvDistricts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            RailDistrict railDistrict = dgvDistricts.Rows[e.RowIndex].Tag as RailDistrict;
            if (railDistrict == null)
            {
                return;
            }

            RailDistrictDetails details = new RailDistrictDetails()
            {
                Application = _application,
                RailDistrictID = railDistrict.RailDistrictID
            };

            details.OnSave += (s, ea) => LoadDistricts();

            Form detailForm = _application.OpenForm(details);
            detailForm.Text = "Rail District";
        }

        private void toolAddDistrict_Click(object sender, EventArgs e)
        {
            RailDistrictDetails details = new RailDistrictDetails()
            {
                Application = _application
            };

            details.OnSave += (s, ea) => LoadDistricts();

            Form detailForm = _application.OpenForm(details);
            detailForm.Text = "Rail District";
        }
    }
}

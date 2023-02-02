using System;
using System.Windows.Forms;
using FleetTracking.Attributes;
using FleetTracking.Interop;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;

namespace FleetTracking.RailcarModel
{
    [SecuredControl(SecuredControlAttribute.Permissions.AllowSetup)]
    public partial class BrowseRailcarModels : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application
        {
            set
            {
                _application = value;
                railcarModelList.Application = value;
            }
        }

        RailcarModelList railcarModelList;
        RailcarModelDetail railcarModelDetail = null;
        public BrowseRailcarModels()
        {
            InitializeComponent();
            railcarModelList = new RailcarModelList();
            railcarModelList.Name = nameof(railcarModelList);
            railcarModelList.Dock = DockStyle.Fill;
            railcarModelList.RailcarModelSelectionChanged += RailcarModelList_RailcarModelSelectionChanged;
            splitContainer.Panel1.Controls.Add(railcarModelList);
            railcarModelList.BringToFront();
        }

        private void RailcarModelList_RailcarModelSelectionChanged(object sender, Models.RailcarModel e)
        {
            splitContainer.Panel2.Controls.Clear();

            railcarModelDetail = new RailcarModelDetail();
            railcarModelDetail.Application = _application;
            railcarModelDetail.Name = nameof(railcarModelDetail);
            railcarModelDetail.RailcarModelID = e.RailcarModelID;
            railcarModelDetail.Dock = DockStyle.Fill;
            railcarModelDetail.RailcarModelSaved += RailcarModelDetail_RailcarModelSaved;
            splitContainer.Panel2.Controls.Add(railcarModelDetail);

            mnuDeleteRailcarModel.Enabled = e != null;
        }

        private void RailcarModelDetail_RailcarModelSaved(object sender, Models.RailcarModel e)
        {
            railcarModelList.LoadData(e.Name);
        }

        private void BrowseRailcarModels_Load(object sender, EventArgs e)
        {
            
        }

        private void mnuAddRailcarModel_Click(object sender, EventArgs e)
        {
            splitContainer.Panel2.Controls.Clear();

            railcarModelDetail = new RailcarModelDetail();
            railcarModelDetail.Application = _application;
            railcarModelDetail.Name = nameof(railcarModelDetail);
            railcarModelDetail.Dock = DockStyle.Fill;
            railcarModelDetail.RailcarModelSaved += RailcarModelDetail_RailcarModelSaved;
            splitContainer.Panel2.Controls.Add(railcarModelDetail);
        }

        private async void mnuDeleteRailcarModel_Click(object sender, EventArgs e)
        {
            if (railcarModelList.SelectedRailcarModel == null || !this.Confirm("Are you sure you want to delete this Railcar Model?"))
            {
                return;
            }

            loader.BringToFront();
            loader.Visible = true;

            try
            {
                DeleteData delete = _application.GetAccess<DeleteData>();
                delete.API = DataAccess.APIs.FleetTracking;
                delete.Resource = $"RailcarModel/Delete/{railcarModelList.SelectedRailcarModel.RailcarModelID}";
                await delete.Execute();

                if (delete.RequestSuccessful)
                {
                    await railcarModelList.LoadData();
                }
            }
            finally
            {
                loader.Visible = false;
            }
        }
    }
}

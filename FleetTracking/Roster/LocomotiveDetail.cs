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

namespace FleetTracking.Roster
{
    public partial class LocomotiveDetail : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public long? LocomotiveID { get; set; }

        public LocomotiveDetail()
        {
            InitializeComponent();
        }

        private void LocomotiveDetail_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                loader.BringToFront();
                loader.Visible = true;

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = "LocomotiveModel/GetAll";
                List<Models.LocomotiveModel> locomotiveModels = await get.GetObject<List<Models.LocomotiveModel>>() ?? new List<Models.LocomotiveModel>();

                foreach (Models.LocomotiveModel locomotiveModel in locomotiveModels)
                {
                    LocomotiveModel.LocomotiveModelDropDownItem ddi = new LocomotiveModel.LocomotiveModelDropDownItem()
                    {
                        Application = _application,
                        LocomotiveModelID = locomotiveModel.LocomotiveModelID
                    };
                    cboModel.Items.Add(new ControlSelector.ControlSelectorItem(ddi, ddi));
                }

                cboModel.Refresh();
            }
            finally
            {
                loader.Visible = false;
            }
        }
    }
}

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
using MesaSuite.Common.Extensions;

namespace FleetTracking.LocomotiveModel
{
    public partial class BrowseLocomotiveModels : UserControl, IFleetTrackingControl
    {
        LocomotiveModelList locomotiveModelList;
        LocomotiveModelDetail locomotiveModelDetail;
        public BrowseLocomotiveModels()
        {
            InitializeComponent();

            locomotiveModelList = new LocomotiveModelList();
            locomotiveModelList.Name = "locomotiveModelList";
            locomotiveModelList.Location = new Point(0, 0);
            locomotiveModelList.Dock = DockStyle.Fill;
            locomotiveModelList.LocomotiveModelChanged += LocomotiveModelList_LocomotiveModelChanged;
            splitContainer.Panel1.Controls.Add(locomotiveModelList);
            locomotiveModelList.BringToFront();

            locomotiveModelDetail = new LocomotiveModelDetail();
            locomotiveModelDetail.Name = "locomotiveModelDetail";
            locomotiveModelDetail.Location = new Point(0, 0);
            locomotiveModelDetail.Dock = DockStyle.Fill;
            locomotiveModelDetail.Enabled = false;
            locomotiveModelDetail.Save += LocomotiveModelDetail_Save;
            splitContainer.Panel2.Controls.Add(locomotiveModelDetail);
        }

        private async void LocomotiveModelDetail_Save(object sender, EventArgs e)
        {
            suppressListChangeEvent = true;
            await locomotiveModelList.LoadList(locomotiveModelDetail.LocomotiveModelID);
            suppressListChangeEvent = false;
        }

        bool suppressListChangeEvent = false;
        private void LocomotiveModelList_LocomotiveModelChanged(object sender, Models.LocomotiveModel e)
        {
            if (suppressListChangeEvent) return;

            if (e == null)
            {
                locomotiveModelDetail.Enabled = false;
                mnuDelete.Enabled = false;
                return;
            }

            locomotiveModelDetail.LocomotiveModelID = e.LocomotiveModelID;
            locomotiveModelDetail.Enabled = true;
            mnuDelete.Enabled = true;
        }

        private FleetTrackingApplication _application = null;
        public FleetTrackingApplication Application
        {
            set
            {
                _application = value;
                locomotiveModelList.Application = value;
                locomotiveModelDetail.Application = value;
            }
        }

        private void mnuAdd_Click(object sender, EventArgs e)
        {
            locomotiveModelDetail.LocomotiveModelID = null;
            locomotiveModelDetail.Enabled = true;
            locomotiveModelDetail.Focus();
        }

        private async void mnuDelete_Click(object sender, EventArgs e)
        {
            if (!this.Confirm("Are you sure you want to delete this Locomotive Model?"))
            {
                return;
            }

            DeleteData delete = _application.GetAccess<DeleteData>();
            delete.API = DataAccess.APIs.FleetTracking;
            delete.Resource = $"LocomotiveModel/Delete/{locomotiveModelList.SelectedLocomotiveModelID}";
            await delete.Execute();
            if (delete.RequestSuccessful)
            {
                locomotiveModelDetail.LocomotiveModelID = null;
                locomotiveModelDetail.Enabled = false;
                await locomotiveModelList.LoadList();
                if (locomotiveModelList.SelectedLocomotiveModelID != null)
                {
                    locomotiveModelDetail.LocomotiveModelID = locomotiveModelList.SelectedLocomotiveModelID;
                }
            }
        }
    }
}

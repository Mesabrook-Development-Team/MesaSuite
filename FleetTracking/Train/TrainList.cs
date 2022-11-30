using FleetTracking.Interop;
using MesaSuite.Common.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetTracking.Train
{
    public partial class TrainList : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        private int _skip;

        public TrainList()
        {
            InitializeComponent();
            dataGridViewStylizer.ApplyStyle(dgvTrains);
        }

        private async void TrainList_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            loader.BringToFront();
            loader.Visible = true;

            try
            {
                dgvTrains.Rows.Clear();

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = "Train/GetFiltered";
                get.QueryString.Add("status", rdoInProgress.Checked ? "inprogress" : "all");
                get.QueryString.Add("operableonly", chkOperableTrainsOnly.Checked.ToString());
                get.QueryString.Add("skip", _skip.ToString());

                var responseObject = new
                {
                    hasMore = false,
                    trains = new List<Models.Train>()
                };

                responseObject = await get.GetAnonymousObject(responseObject);



            }
            finally
            {
                loader.Visible = false;
            }
        }
    }
}

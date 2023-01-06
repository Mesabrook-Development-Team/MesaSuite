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

namespace FleetTracking.Train
{
    public partial class LiveLoadServer : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public long? LiveLoadID { get; set; }
        public long? TrainID { get; set; }

        public LiveLoadServer()
        {
            InitializeComponent();
        }

        private async void LiveLoadServer_Load(object sender, EventArgs e)
        {
            ParentForm.Text = "Live Loading";
            ParentForm.Size = new Size(382, 316);
            LiveLoad liveLoad;
            if (LiveLoadID == null)
            {
                PostData generateLiveLoad = _application.GetAccess<PostData>();
                generateLiveLoad.API = DataAccess.APIs.FleetTracking;
                generateLiveLoad.Resource = "LiveLoad/Generate";
                generateLiveLoad.ObjectToPost = new { TrainID };
                liveLoad = await generateLiveLoad.Execute<LiveLoad>();
            }
            else
            {
                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = $"LiveLoad/Get/{LiveLoadID}";
                liveLoad = await get.GetObject<LiveLoad>();
            }

            if (liveLoad == null)
            {
                ParentForm?.Close();
                Dispose();
                return;
            }

            lblCode.Text = liveLoad.Code;
            lstClients.Items.Clear();

            if (liveLoad.LiveLoadSessions != null)
            {
                foreach(LiveLoadSession session in liveLoad.LiveLoadSessions)
                {
                    lstClients.Items.Add($"{session.User?.Username} ({session.Company?.Name}{session.Government?.Name})", "user");
                }
            }
        }
    }
}

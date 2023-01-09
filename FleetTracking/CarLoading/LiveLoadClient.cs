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

namespace FleetTracking.CarLoading
{
    public partial class LiveLoadClient : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        private long? SessionID { get; set; }
        public string LiveLoadCode { get; set; }

        public LiveLoadClient()
        {
            InitializeComponent();
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
                tmrSession.Enabled = true;
            }
            finally
            {
                loader.Visible = false;
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
    }
}

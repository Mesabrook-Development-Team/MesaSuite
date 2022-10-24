using FleetTracking.Interop;
using FleetTracking.Models;
using MesaSuite.Common.Data;
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

namespace FleetTracking.Roster
{
    public partial class RailcarDropDownItem : UserControl, IFleetTrackingControl, IRefreshable
    {
        public event EventHandler ContentLoaded;

        private FleetTrackingApplication _application;

        public FleetTrackingApplication Application { set => _application = value; }
        public long? RailcarID { get; set; }

        public RailcarDropDownItem()
        {
            InitializeComponent();
        }

        private async void RailcarDropDownItem_Load(object sender, EventArgs e)
        {
            try
            {
                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = $"Railcar/Get/{RailcarID}";
                Railcar railcar = await get.GetObject<Railcar>();
                if (railcar == null)
                {
                    lblReportingMark.Text = "Error";
                    lblLocation.Text = "Could not find Railcar";
                    return;
                }

                lblReportingMark.Text = railcar.FormattedReportingMark;
                lblLocation.Text = "Your mom's house";
                lblModel.Text = railcar.RailcarModel?.Name;
                lblModel.Location = new Point(Width - lblModel.Width - 6, lblModel.Top);

                get.Resource = $"Railcar/GetImage/{RailcarID}";
                byte[] imageData = await get.GetObject<byte[]>();
                if (imageData != null)
                {
                    using (MemoryStream stream = new MemoryStream(imageData))
                    {
                        Image image = Image.FromStream(stream);
                        pboxImage.Image = image;
                    }
                }

                ContentLoaded?.Invoke(this, EventArgs.Empty);
            }
            catch
            {
                lblReportingMark.Text = "Error";
                lblModel.Text = "";
                lblLocation.Text = "";
            }
        }
    }
}

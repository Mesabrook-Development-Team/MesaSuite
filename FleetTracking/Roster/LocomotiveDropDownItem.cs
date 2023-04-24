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
    public partial class LocomotiveDropDownItem : UserControl, IFleetTrackingControl, IRefreshable
    {
        public event EventHandler ContentLoaded;

        private FleetTrackingApplication _application;

        public FleetTrackingApplication Application { set => _application = value; }
        public long? LocomotiveID { get; set; }

        public LocomotiveDropDownItem()
        {
            InitializeComponent();
        }

        private async void LocomotiveDropDownItem_Load(object sender, EventArgs e)
        {
            try
            {
                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = $"Locomotive/Get/{LocomotiveID}";
                Locomotive locomotive = await get.GetObject<Locomotive>();
                if (locomotive == null)
                {
                    lblReportingMark.Text = "Error";
                    lblLocation.Text = "Could not find Locomotive";
                    return;
                }

                lblReportingMark.Text = locomotive.FormattedReportingMark;
                lblLocation.Text = locomotive.Location;
                lblModel.Text = locomotive.LocomotiveModel?.Name;
                lblModel.Location = new Point(Width - lblModel.Width - 6, lblModel.Top);

                get.Resource = $"Locomotive/GetImageThumbnail/{LocomotiveID}";
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

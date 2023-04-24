using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FleetTracking.Interop;
using MesaSuite.Common.Data;

namespace FleetTracking.LocomotiveModel
{
    public partial class LocomotiveModelDropDownItem : UserControl, IFleetTrackingControl, IRefreshable
    {        
        public event EventHandler ContentLoaded;

        private FleetTrackingApplication _application;

        public FleetTrackingApplication Application { set => _application = value; }

        public long? LocomotiveModelID { get; set; }

        public LocomotiveModelDropDownItem()
        {
            InitializeComponent();
        }


        private void LocomotiveModelDropDownItem_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private async void LoadData()
        {
            GetData get = _application.GetAccess<GetData>();
            get.API = DataAccess.APIs.FleetTracking;
            get.Resource = $"LocomotiveModel/Get/{LocomotiveModelID}";
            Models.LocomotiveModel model = await get.GetObject<Models.LocomotiveModel>();

            if (model == null)
            {
                lblName.Text = "";
                lblType.Text = "";
                return;
            }

            lblName.Text = model.Name;
            lblType.Text = model.IsSteamPowered ? "Steam Locomotive" : "Diesel Electric Locomotive";

            get.Resource = $"LocomotiveModel/GetImageThumbnail/{LocomotiveModelID}";
            byte[] imageData = await get.GetObject<byte[]>();

            if (imageData != null)
            {
                using (MemoryStream stream = new MemoryStream(imageData))
                {
                    Image image = Image.FromStream(stream);
                    pictureBox1.Image = image;
                }
            }

            ContentLoaded?.Invoke(this, EventArgs.Empty);
        }
    }
}

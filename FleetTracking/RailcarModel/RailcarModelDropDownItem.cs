using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FleetTracking.Interop;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;

namespace FleetTracking.RailcarModel
{
    public partial class RailcarModelDropDownItem : UserControl, IFleetTrackingControl, IRefreshable
    {
        private FleetTrackingApplication _application;

        public event EventHandler ContentLoaded;

        public FleetTrackingApplication Application { set => _application = value; }

        public long? RailcarModelID { get; set; }

        public RailcarModelDropDownItem()
        {
            InitializeComponent();
        }

        private void RailcarModelDropDownItem_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private async void LoadData()
        {
            GetData get = _application.GetAccess<GetData>();
            get.API = DataAccess.APIs.FleetTracking;
            get.Resource = $"RailcarModel/Get/{RailcarModelID}";
            Models.RailcarModel model = await get.GetObject<Models.RailcarModel>();

            if (model == null)
            {
                lblName.Text = "";
                lblType.Text = "";
                return;
            }

            lblName.Text = model.Name;
            lblType.Text = model.Type.ToString().ToDisplayName();

            get.Resource = $"RailcarModel/GetImage/{RailcarModelID}";
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

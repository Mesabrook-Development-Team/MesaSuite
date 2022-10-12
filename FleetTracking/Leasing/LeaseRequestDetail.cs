using FleetTracking.Interop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetTracking.Leasing
{
    public partial class LeaseRequestDetail : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public LeaseRequestDetail()
        {
            InitializeComponent();
        }


        private void LeaseRequestDetail_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(label1.ForeColor, 2), new Point(label1.Location.X + label1.Width + 2, label1.Location.Y + (label1.Height / 2)), new Point(Width - 6, label1.Location.Y + (label1.Height / 2)));
        }
    }
}

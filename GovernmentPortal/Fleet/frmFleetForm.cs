using System.Windows.Forms;
using FleetTracking;

namespace GovernmentPortal.Fleet
{
    public partial class frmFleetForm : Form
    {
        private IFleetTrackingControl _fleetTrackingControl;
        public IFleetTrackingControl FleetTrackingControl
        {
            get => _fleetTrackingControl;
            set
            {
                Controls.Clear();
                _fleetTrackingControl = value;
                Control fleetTrackingControl = (Control)_fleetTrackingControl;
                if (fleetTrackingControl != null)
                {
                    Controls.Add(fleetTrackingControl);
                    fleetTrackingControl.Dock = DockStyle.Fill;
                }
            }
        }

        public frmFleetForm()
        {
            InitializeComponent();
        }
    }
}

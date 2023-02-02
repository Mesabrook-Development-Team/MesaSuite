using System.Windows.Forms;
using FleetTracking;

namespace CompanyStudio.FleetTrackingForms
{
    public partial class frmFleetForm : BaseCompanyStudioContent
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

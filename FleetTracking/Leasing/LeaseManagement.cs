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

namespace FleetTracking.Leasing
{
    public partial class LeaseManagement : UserControl, IFleetTrackingControl
    {
        private Label _currentTab = null;
        public LeaseManagement()
        {
            InitializeComponent();
        }

        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        private void lblTab_MouseEnter(object sender, EventArgs e)
        {
            Label selectedLabel = (Label)sender;
            selectedLabel.BackColor = splitContainer1.Panel1.ForeColor;
            selectedLabel.ForeColor = splitContainer1.Panel1.BackColor;
            selectedLabel.Font = new Font(selectedLabel.Font.FontFamily, 18, FontStyle.Bold);
        }

        private void lblTab_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            if (label == _currentTab)
            {
                return;
            }

            label.BackColor = splitContainer1.Panel1.BackColor;
            label.ForeColor = splitContainer1.Panel1.ForeColor;
            label.Font = new Font(label.Font.FontFamily, 14, FontStyle.Regular);
        }

        private void lblTab_Click(object sender, EventArgs e)
        {
            _currentTab = (Label)sender;

            foreach(Label tab in splitContainer1.Panel1.Controls.OfType<Label>())
            {
                if (tab == _currentTab)
                {
                    continue;
                }

                lblTab_MouseLeave(tab, e);
            }

            LoadCurrentTab();
        }

        private void LoadCurrentTab()
        {
            splitContainer1.Panel2.Controls.Clear();
            if (_currentTab == lblOverview)
            {
                Overview overview = new Overview()
                {
                    Application = _application
                };
                overview.Dock = DockStyle.Fill;
                splitContainer1.Panel2.Controls.Add(overview);
            }
            else if (_currentTab == lblRequests)
            {
                LeaseRequests leaseRequests = new LeaseRequests()
                {
                    Application = _application
                };
                leaseRequests.Dock = DockStyle.Fill;
                splitContainer1.Panel2.Controls.Add(leaseRequests);
            }
            else if (_currentTab == lblContracts)
            {
                LeaseContracts leaseContracts = new LeaseContracts()
                {
                    Application = _application
                };
                leaseContracts.Dock = DockStyle.Fill;
                splitContainer1.Panel2.Controls.Add(leaseContracts);
            }
        }

        private void LeaseManagement_Load(object sender, EventArgs e)
        {
            lblTab_Click(lblOverview, EventArgs.Empty);
        }
    }
}

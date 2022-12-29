using FleetTracking.Interop;
using FleetTracking.Models;
using FleetTracking.Roster;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetTracking.Train
{
    public partial class SelectLocoForFuel : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public List<Locomotive> SelectedLocomotives => locoList.SelectedLocomotives.ToList();

        public Func<Locomotive, bool> LocomotiveFilter { get; set; }

        private LocomotiveList locoList;
        public SelectLocoForFuel()
        {
            InitializeComponent();
        }

        private void SelectLocoForFuel_Load(object sender, EventArgs e)
        {
            locoList = new LocomotiveList();
            locoList.Application = _application;
            locoList.Name = nameof(locoList);
            locoList.Dock = DockStyle.Fill;
            locoList.AllowMultiSelect = true;
            locoList.Filter = LocomotiveFilter;
            pnlList.Controls.Add(locoList);
            ParentForm.Text = "Select Locomotive";
        }

        private void cmdSelect_Click(object sender, EventArgs e)
        {
            ParentForm.DialogResult = DialogResult.OK;
            ParentForm.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            ParentForm.DialogResult = DialogResult.Cancel;
            ParentForm.Close();
        }
    }
}

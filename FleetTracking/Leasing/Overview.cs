using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using FleetTracking.Interop;
using FleetTracking.Models;
using MesaSuite.Common.Data;

namespace FleetTracking.Leasing
{
    public partial class Overview : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public Overview()
        {
            InitializeComponent();
        }

        private async void Overview_Load(object sender, EventArgs e)
        {
            loader.BringToFront();
            loader.Visible = true;

            try
            {
                await LoadLocomotivesLeasedChartData();
                await LoadRailcarsLeasedChartData();
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private async Task LoadLocomotivesLeasedChartData()
        {
            GetData get = _application.GetAccess<GetData>();
            get.API = DataAccess.APIs.FleetTracking;
            get.Resource = "Locomotive/GetAll";
            List<Locomotive> locomotives = await get.GetObject<List<Locomotive>>() ?? new List<Locomotive>();
            locomotives = locomotives.Where(l => _application.IsCurrentEntity(l.CompanyIDOwner, l.GovernmentIDOwner)).ToList();
            DataPoint availableLocomotivesPoint = new DataPoint()
            {
                YValues = new double[] { locomotives.Where(l => l.CompanyLeasedTo?.CompanyID == null && l.GovernmentLeasedTo?.GovernmentID == null).Count() },
                LabelFormat = "Available ({0})"
            };
            DataPoint leasedLocomotivesPoint = new DataPoint()
            {
                YValues = new double[] { locomotives.Where(l => l.CompanyLeasedTo?.CompanyID != null || l.GovernmentLeasedTo?.GovernmentID != null).Count() },
                LabelFormat = "Leased ({0})"
            };
            chrtLocomotivesAvailable.Series[0].Points.Add(availableLocomotivesPoint);
            chrtLocomotivesAvailable.Series[0].Points.Add(leasedLocomotivesPoint);
        }

        private async Task LoadRailcarsLeasedChartData()
        {
            GetData get = _application.GetAccess<GetData>();
            get.API = DataAccess.APIs.FleetTracking;
            get.Resource = "Railcar/GetAll";
            List<Railcar> railcars = await get.GetObject<List<Railcar>>() ?? new List<Railcar>();
            railcars = railcars.Where(r => _application.IsCurrentEntity(r.CompanyIDOwner, r.GovernmentIDOwner)).ToList();
            DataPoint availableRailcarsPoint = new DataPoint()
            {
                YValues = new double[] { railcars.Where(r => r.CompanyLeasedTo?.CompanyID == null && r.GovernmentLeasedTo?.GovernmentID == null).Count() },
                LabelFormat = "Available ({0})"
            };
            DataPoint leasedRailcarsPoint = new DataPoint()
            {
                YValues = new double[] { railcars.Where(r => r.CompanyLeasedTo?.CompanyID != null || r.GovernmentLeasedTo?.GovernmentID != null).Count() },
                LabelFormat = "Leased ({0})"
            };
            chrtRailcarsAvailable.Series[0].Points.Add(availableRailcarsPoint);
            chrtRailcarsAvailable.Series[0].Points.Add(leasedRailcarsPoint);
        }
    }
}

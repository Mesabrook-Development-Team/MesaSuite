﻿using FleetTracking.Attributes;
using FleetTracking.Interop;
using MesaSuite.Common.Data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FleetTracking.Misc
{
    [SecuredControl(SecuredControlAttribute.Permissions.AllowSetup)]
    public partial class MiscellaneousSettings : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }
        public MiscellaneousSettings()
        {
            InitializeComponent();
        }

        private long? MiscellaneousSettingsID { get; set; }

        private void MiscellaneousSettings_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                loader.BringToFront();
                loader.Visible = true;

                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;

                get.Resource = "MiscellaneousSettings/Get";
                Models.MiscellaneousSettings settings = await get.GetObject<Models.MiscellaneousSettings>();
                if (!get.RequestSuccessful)
                {
                    return;
                }

                MiscellaneousSettingsID = settings.MiscellaneousSettingsID;
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private void flow_Resize(object sender, EventArgs e)
        {
            foreach(GroupBox groupBox in flow.Controls.OfType<GroupBox>())
            {
                groupBox.Width = flow.Width - 10;
            }
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                (long?, long?) companyIDGovernmentID = _application.GetCurrentCompanyIDGovernmentID();

                Models.MiscellaneousSettings settings = new Models.MiscellaneousSettings()
                {
                    MiscellaneousSettingsID = MiscellaneousSettingsID,
                    CompanyID = companyIDGovernmentID.Item1,
                    GovernmentID = companyIDGovernmentID.Item2
                };

                PutData put = _application.GetAccess<PutData>();
                put.API = DataAccess.APIs.FleetTracking;
                put.Resource = "MiscellaneousSettings/Put";
                put.ObjectToPut = settings;
                await put.ExecuteNoResult();

                if (put.RequestSuccessful)
                {
                    ParentForm?.Close();
                    Dispose();
                }
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            ParentForm?.Close();
            Dispose();
        }
    }
}

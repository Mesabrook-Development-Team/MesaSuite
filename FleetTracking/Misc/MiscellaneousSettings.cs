using FleetTracking.Attributes;
using FleetTracking.Interop;
using FleetTracking.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

                chkCarsReleased.Checked = settings.EmailImplementationIDCarReleased != null;
                chkCarsReleased.Tag = settings.EmailImplementationIDCarReleased;
                chkLocomotivesReleased.Checked = settings.EmailImplementationIDLocomotiveReleased != null;
                chkLocomotivesReleased.Tag = settings.EmailImplementationIDLocomotiveReleased;
                chkNewLeaseRequests.Checked = settings.EmailImplementationIDLeaseRequestAvailable != null;
                chkNewLeaseRequests.Tag = settings.EmailImplementationIDLeaseRequestAvailable;
                chkLeaseBidsReceived.Checked = settings.EmailImplementationIDLeaseBidReceived != null;
                chkLeaseBidsReceived.Tag = settings.EmailImplementationIDLeaseBidReceived;
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
                    GovernmentID = companyIDGovernmentID.Item2,
                    EmailImplementationIDCarReleased = chkCarsReleased.Tag as long?,
                    EmailImplementationIDLocomotiveReleased = chkLocomotivesReleased.Tag as long?,
                    EmailImplementationIDLeaseRequestAvailable = chkNewLeaseRequests.Tag as long?,
                    EmailImplementationIDLeaseBidReceived = chkLeaseBidsReceived.Tag as long?
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

        private void chkCarsReleased_CheckedChanged(object sender, EventArgs e)
        {
            cmdEditCarsReleased.Enabled = chkCarsReleased.Checked;
        }

        private void cmdEditCarsReleased_Click(object sender, EventArgs e)
        {
            OpenEmailEditor(chkCarsReleased, "Railcar Release Received");
        }

        private void OpenEmailEditor(CheckBox relatedCheckbox, string emailName)
        {
            long? implementationID = relatedCheckbox.Tag as long?;
            EmailEditor emailEditor = new EmailEditor()
            {
                Application = _application,
                EmailName = emailName,
                EmailImplementationID = implementationID
            };

            Form dialog = _application.OpenForm(emailEditor, FleetTrackingApplication.OpenFormOptions.Dialog);
            if (dialog.DialogResult != DialogResult.OK)
            {
                return;
            }

            relatedCheckbox.Tag = emailEditor.EmailImplementationID;
        }

        private void chkLocomotivesReleased_CheckedChanged(object sender, EventArgs e)
        {
            cmdEditLocomotivesReleased.Enabled = chkLocomotivesReleased.Checked;
        }

        private void cmdEditLocomotivesReleased_Click(object sender, EventArgs e)
        {
            OpenEmailEditor(chkLocomotivesReleased, "Locomotive Release Received");
        }

        private void chkNewLeaseRequests_CheckedChanged(object sender, EventArgs e)
        {
            cmdNewLeaseRequests.Enabled = chkNewLeaseRequests.Checked;
        }

        private void chkLeaseBidsReceived_CheckedChanged(object sender, EventArgs e)
        {
            cmdLeaseBidsReceived.Enabled = chkLeaseBidsReceived.Checked;
        }

        private void cmdNewLeaseRequests_Click(object sender, EventArgs e)
        {
            OpenEmailEditor(chkNewLeaseRequests, "New Lease Request Available");
        }

        private void cmdLeaseBidsReceived_Click(object sender, EventArgs e)
        {
            OpenEmailEditor(chkLeaseBidsReceived, "Lease Bid Received");
        }
    }
}

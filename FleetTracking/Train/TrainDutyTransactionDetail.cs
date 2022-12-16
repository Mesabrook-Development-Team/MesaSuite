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
using FleetTracking.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;

namespace FleetTracking.Train
{
    public partial class TrainDutyTransactionDetail : UserControl, IFleetTrackingControl
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public long? TrainID { get; set; }
        public long? TrainDutyTransactionID { get; set; }

        private Size InitialSize;
        public TrainDutyTransactionDetail()
        {
            InitializeComponent();
            InitialSize = this.Size;
        }


        private void TrainDutyTransaction_Load(object sender, EventArgs e)
        {
            ParentForm.ClientSize = InitialSize;
            ParentForm.Text = "Duty Transaction";

            if (TrainID == null)
            {
                this.ShowError("TrainID is required when opening this form");
                ParentForm.Close();
                Dispose();
            }

            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                loader.BringToFront();
                loader.Visible = true;

                List<User> users = await _application.GetUsersForCurrentEntity();
                foreach(User user in users)
                {
                    DropDownItem<User> userDDI = new DropDownItem<User>(user, user.Username);
                    cboOperator.Items.Add(userDDI);
                }

                chkOffDuty.Checked = false;
                dtpOffDuty.Enabled = false;

                if (TrainDutyTransactionID != null)
                {
                    GetData getData = _application.GetAccess<GetData>();
                    getData.API = DataAccess.APIs.FleetTracking;
                    getData.Resource = $"TrainDutyTransaction/Get/{TrainDutyTransactionID}";
                    TrainDutyTransaction transaction = await getData.GetObject<TrainDutyTransaction>();

                    DropDownItem<User> selectedUser = cboOperator.Items.OfType<DropDownItem<User>>().FirstOrDefault(ddi => ddi.Object.UserID == transaction.UserIDOperator);
                    if (selectedUser != null)
                    {
                        cboOperator.SelectedItem = selectedUser;
                    }

                    dtpOnDuty.Value = transaction.TimeOnDuty ?? DateTime.Now;
                    chkOffDuty.Checked = transaction.TimeOffDuty != null;
                    dtpOffDuty.Enabled = chkOffDuty.Checked;
                    dtpOffDuty.Value = transaction.TimeOffDuty ?? DateTime.Now;
                }
            }
            finally
            {
                loader.Visible = false;
            }
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            if (!this.AreFieldsPresent(new List<(string, Control)>()
            {
                ("Operator", cboOperator)
            }))
            {
                return;
            }

            if (!chkOffDuty.Checked && dtpOffDuty.Value < dtpOnDuty.Value)
            {
                this.ShowError("Time On Duty must be before Time Off Duty");
                return;
            }

            try
            {
                loader.BringToFront();
                loader.Visible = true;

                TrainDutyTransaction trainDutyTransaction = new TrainDutyTransaction()
                {
                    TrainDutyTransactionID = TrainDutyTransactionID,
                    TrainID = TrainID,
                    UserIDOperator = cboOperator.SelectedItem.Cast<DropDownItem<User>>().Object.UserID,
                    TimeOnDuty = dtpOnDuty.Value,
                    TimeOffDuty = chkOffDuty.Checked ? (DateTime?)dtpOffDuty.Value : null
                };

                if (TrainDutyTransactionID == null)
                {
                    PostData post = _application.GetAccess<PostData>();
                    post.API = DataAccess.APIs.FleetTracking;
                    post.Resource = "TrainDutyTransaction/Post";
                    post.ObjectToPost = trainDutyTransaction;
                    TrainDutyTransaction savedTransaction = await post.Execute<TrainDutyTransaction>();
                    if (post.RequestSuccessful)
                    {
                        ParentForm.Close();
                    }
                }
                else
                {
                    PutData put = _application.GetAccess<PutData>();
                    put.API = DataAccess.APIs.FleetTracking;
                    put.Resource = "TrainDutyTransaction/Put";
                    put.ObjectToPut = trainDutyTransaction;
                    await put.ExecuteNoResult();
                    if (put.RequestSuccessful)
                    {
                        ParentForm.Close();
                    }
                }
            }
            finally 
            {
                loader.Visible = false; 
            }
        }
    }
}

using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Towing.Models;

namespace Towing.MyTickets
{
    public partial class InProgressMessage : UserControl, IContent
    {
        public InProgressMessage()
        {
            InitializeComponent();
        }

        public frmMain MainForm { get; set; }

        public Task LoadData()
        {
            tmrPoll_Tick(this, EventArgs.Empty);
            return Task.CompletedTask;
        }

        private ActionButtonMethods _actionButtonMethod = ActionButtonMethods.CancelRequest;
        private enum ActionButtonMethods
        {
            CancelRequest,
            MarkComplete
        }

        private const string REQUESTED_TITLE = "Waiting For A Driver";
        private const string REQUESTED_MESSAGE = "Your ticket is now available for a tow truck driver to respond to. Please wait while someone accepts the ticket.";

        private const string ENROUTE_TITLE = "Driver Is On The Way";
        private const string ENROUTE_MESSAGE = "{0} started responding to your ticket at {1}. Keep an eye out!\r\n\r\nPlease let us know when {0} has finished towing so we can close out your ticket!";
        private async void tmrPoll_Tick(object sender, EventArgs e)
        {
            tmrPoll.Enabled = false;

            GetData statusCheck = new GetData(DataAccess.APIs.TowTickets, "TowTicket/GetCurrentTicketStatus");
            GetStatusModel getStatus = await statusCheck.GetObject<GetStatusModel>();

            if (getStatus.status.Equals("none", StringComparison.OrdinalIgnoreCase))
            {
                MainForm.SetShownContent(new List());
                return;
            }

            if (getStatus.status.Equals("requested", StringComparison.OrdinalIgnoreCase))
            {
                lblTitle.Text = REQUESTED_TITLE;
                lblMessage.Text = REQUESTED_MESSAGE;
                cmdAction.Visible = true;
                cmdAction.Text = "Cancel Tow Request";
                _actionButtonMethod = ActionButtonMethods.CancelRequest;
            }

            if (getStatus.status.Equals("responseenroute", StringComparison.OrdinalIgnoreCase))
            {
                lblTitle.Text = ENROUTE_TITLE;
                lblMessage.Text = string.Format(ENROUTE_MESSAGE, getStatus.responder, getStatus.responsetime?.ConvertToLocalTime().ToString("MM/dd/yyyy HH:mm"));
                cmdAction.Text = "Mark Tow Complete";
                cmdAction.Visible = true;
                _actionButtonMethod = ActionButtonMethods.MarkComplete;
            }

            tmrPoll.Enabled = true;
        }

        private async void cmdAction_Click(object sender, EventArgs e)
        {
            switch(_actionButtonMethod)
            {
                case ActionButtonMethods.CancelRequest:
                    if (!this.Confirm("Are you sure you want to cancel your Tow Request?"))
                    {
                        return;
                    }

                    PutData cancelPut = new PutData(DataAccess.APIs.TowTickets, "TowTicket/CancelTowRequest", null);
                    await cancelPut.ExecuteNoResult();

                    if (cancelPut.RequestSuccessful)
                    {
                        MainForm.SetShownContent(new List());
                    }
                    break;
                case ActionButtonMethods.MarkComplete:
                    if (!this.Confirm("Are you sure you want to mark this Tow Request complete?"))
                    {
                        return;
                    }

                    PutData markComplete = new PutData(DataAccess.APIs.TowTickets, "TowTicket/TowComplete", null);
                    await markComplete.ExecuteNoResult();

                    if (markComplete.RequestSuccessful)
                    {
                        MainForm.SetShownContent(new List());
                    }
                    break;
            }
        }
    }
}

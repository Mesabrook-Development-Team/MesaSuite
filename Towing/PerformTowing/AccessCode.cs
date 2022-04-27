using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MesaSuite.Common.Data;
using Towing.Models;

namespace Towing.PerformTowing
{
    public partial class AccessCode : UserControl, IContent
    {
        public AccessCode()
        {
            InitializeComponent();
        }

        public frmMain MainForm { get; set; }

        public Task LoadData()
        {
            tmrPoll_Tick(this, EventArgs.Empty);
            return Task.CompletedTask;
        }

        private async void tmrPoll_Tick(object sender, EventArgs e)
        {
            tmrPoll.Enabled = false;

            GetData getAccessCode = new GetData(DataAccess.APIs.TowTickets, "AccessCode/Get");
            string accessCode = await getAccessCode.GetObject<string>() ?? "[none]";

            if (accessCode.Equals("[none]", StringComparison.OrdinalIgnoreCase)) // Ticket unavailable or we're now doing the job - either way we'll go back to the list screen. If we're doing the job, the list screen will redirect us to the in progress screen
            {
                MainForm.SetShownContent(new List());
                Dispose();
                return;
            }

            lblAccessCode.Text = accessCode;

            tmrPoll.Enabled = true;
        }

        private async void cmdCancel_Click(object sender, EventArgs e)
        {
            PutData cancelPut = new PutData(DataAccess.APIs.TowTickets, "AccessCode/Cancel", null);
            await cancelPut.ExecuteNoResult();

            if (cancelPut.RequestSuccessful)
            {
                MainForm.SetShownContent(new List());
            }
        }

        private async void lnkViewTicket_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetData getData = new GetData(DataAccess.APIs.TowTickets, "AccessCode/Get");
            string accessCode = await getData.GetObject<string>() ?? "[none]";

            if (accessCode.Equals("[none]", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            getData = new GetData(DataAccess.APIs.TowTickets, $"TowTicket/GetByAccessCode/{accessCode}");
            TowTicket towTicket = await getData.GetObject<TowTicket>() ?? new TowTicket();

            tmrPoll.Enabled = false;
            frmViewTicket viewTicket = new frmViewTicket();
            viewTicket.TowTicket = towTicket;
            viewTicket.ViewMode = frmViewTicket.ViewModes.ViewTicket;
            viewTicket.ShowDialog();
            tmrPoll.Enabled = true;
        }
    }
}

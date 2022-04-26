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
    public partial class TowInProgress : UserControl, IContent
    {
        public TowInProgress()
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

            GetData getInProgressTicket = new GetData(DataAccess.APIs.TowTickets, "TowTicket/GetTowingStatus");
            GetStatusModel status = await getInProgressTicket.GetObject<GetStatusModel>() ?? new GetStatusModel() { status = "none" };

            if (status.status.Equals("none", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("This Tow Ticket has been marked as complete! Please return your Tow Truck and key to the location in which you took it from.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm.SetShownContent(new List());
                Dispose();
                return;
            }

            tmrPoll.Enabled = true;
        }

        private async void cmdViewTicket_Click(object sender, EventArgs e)
        {
            GetData getData = new GetData(DataAccess.APIs.TowTickets, "TowTicket/GetTowingStatus");
            GetStatusModel status = await getData.GetObject<GetStatusModel>() ?? new GetStatusModel() { status = "none" };

            if (status.status.Equals("none", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            getData = new GetData(DataAccess.APIs.TowTickets, $"TowTicket/GetByNumber/{status.ticketnumber}");
            TowTicket ticket = await getData.GetObject<TowTicket>() ?? new TowTicket();

            frmViewTicket viewTicket = new frmViewTicket();
            viewTicket.TowTicket = ticket;
            viewTicket.ViewMode = frmViewTicket.ViewModes.ViewTicket;

            tmrPoll.Enabled = false;
            viewTicket.ShowDialog();
            tmrPoll.Enabled = true;
        }
    }
}

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
    public partial class List : UserControl, IContent
    {
        public List()
        {
            InitializeComponent();
        }

        public frmMain MainForm { get; set; }

        public async Task LoadData()
        {
            dgvList.Rows.Clear();

            if (await TicketAlreadyInProgress())
            {
                Dispose();

                MainForm.SetShownContent(new InProgressMessage());

                return;
            }

            GetData getData = new GetData(DataAccess.APIs.TowTickets, "TowTicket/GetMyTickets");
            List<TowTicket> towTickets = await getData.GetObject<List<TowTicket>>() ?? new List<TowTicket>();

            foreach(TowTicket ticket in towTickets.OrderByDescending(tt => tt.IssueDate ?? DateTime.MinValue))
            {
                int rowIndex = dgvList.Rows.Add();
                dgvList.Rows[rowIndex].Cells["colTicketNumber"].Value = ticket.TicketNumber;
                dgvList.Rows[rowIndex].Cells["colIssueDate"].Value = ticket.IssueDate?.ConvertToLocalTime().ToString("MM/dd/yyyy HH:mm") ?? String.Empty;
                dgvList.Rows[rowIndex].Tag = ticket;
            }
        }

        private async Task<bool> TicketAlreadyInProgress()
        {
            GetData checkTicket = new GetData(DataAccess.APIs.TowTickets, "TowTicket/GetCurrentTicketStatus");

            GetStatusModel response = await checkTicket.GetObject<GetStatusModel>();

            return !response.status.Equals("none", StringComparison.OrdinalIgnoreCase);
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != colUse.Index)
            {
                return;
            }

            TowTicket ticket = (TowTicket)dgvList.Rows[e.RowIndex].Tag;
            frmViewTicket newTicket = new frmViewTicket();
            newTicket.TowTicket = ticket;
            DialogResult newTicketResult = newTicket.ShowDialog();

            if (newTicketResult == DialogResult.OK)
            {
                MainForm.SetShownContent(new List());
            }
        }
    }
}

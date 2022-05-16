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
using MesaSuite.Common.Extensions;
using Towing.Models;

namespace Towing.History
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

            GetData get = new GetData(DataAccess.APIs.TowTickets, "TowTicket/GetHistorical");
            List<TowTicket> towTickets = await get.GetObject<List<TowTicket>>();
            foreach(TowTicket ticket in towTickets.OrderByDescending(tt => tt.CompletionTime ?? DateTime.MinValue))
            {
                int rowIndex = dgvList.Rows.Add();

                DataGridViewRow row = dgvList.Rows[rowIndex];
                row.Cells[colTicketNumber.Name].Value = ticket.TicketNumber;
                row.Cells[colIssuedTo.Name].Value = ticket.UserIssuedTo;
                row.Cells[colResponder.Name].Value = ticket.UserResponding;
                row.Cells[colResponseTime.Name].Value = ticket.RespondingTime?.ConvertToLocalTime().ToString("MM/dd/yyyyy HH:mm");
                row.Cells[colCompleteTime.Name].Value = ticket.CompletionTime?.ConvertToLocalTime().ToString("MM/dd/yyyyy HH:mm");
                row.Tag = ticket;
            }
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != colView.Index)
            {
                return;
            }

            DataGridViewRow row = dgvList.Rows[e.RowIndex];
            TowTicket towTicket = row.Tag as TowTicket;
            if (towTicket == null)
            {
                return;
            }

            frmViewTicket view = new frmViewTicket();
            view.TowTicket = towTicket;
            view.ViewMode = frmViewTicket.ViewModes.ViewTicket;
            view.ShowDialog();
        }
    }
}

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

            GetData getTickets = new GetData(DataAccess.APIs.TowTickets, "TowTicket/GetTowableTickets");
            List<TowTicket> towTickets = await getTickets.GetObject<List<TowTicket>>();
            foreach(TowTicket ticket in towTickets)
            {
                int rowIndex = dgvList.Rows.Add();
                DataGridViewRow row = dgvList.Rows[rowIndex];

                row.Cells[nameof(colTicketNumber)].Value = ticket.TicketNumber;
                row.Cells[nameof(colSubmitter)].Value = ticket.UserIssuedTo;
                row.Tag = ticket;
            }
        }
    }
}

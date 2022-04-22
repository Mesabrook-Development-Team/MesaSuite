using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            dgvList.Rows.Add();
            dgvList.Rows[0].Cells["colTicketNumber"].Value = "Test";
            dgvList.Rows.Add();
            dgvList.Rows[1].Cells["colTicketNumber"].Value = "Test 2";
            dgvList.Rows.Add();
            dgvList.Rows[2].Cells["colTicketNumber"].Value = "Test 3";
            dgvList.Rows.Add();
            dgvList.Rows[3].Cells["colTicketNumber"].Value = "Test 4";
            dgvList.Rows.Add();
            dgvList.Rows[4].Cells["colTicketNumber"].Value = "Test 5";
            await Task.Run(() => { });
        }
    }
}

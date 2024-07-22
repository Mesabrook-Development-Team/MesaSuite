using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MesaSuite
{
    public partial class frmNotificationsCenter : Form
    {
        public frmNotificationsCenter()
        {
            InitializeComponent();
        }

        private void lostButton3_Click(object sender, EventArgs e)
        {
            frmTaskDetails d = new frmTaskDetails();
            d.ShowDialog();
        }

        private void lostButton21_Click(object sender, EventArgs e)
        {
            frmCreateNotification frmCreateNotification = new frmCreateNotification();
            frmCreateNotification.ShowDialog();
        }
    }
}

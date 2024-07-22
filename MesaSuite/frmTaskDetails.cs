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
    public partial class frmTaskDetails : Form
    {
        public frmTaskDetails()
        {
            InitializeComponent();
        }

        private void formTheme1_Click(object sender, EventArgs e)
        {

        }

        private void frmTaskDetails_Load(object sender, EventArgs e)
        {
            
        }

        private void lostButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lostButton2_Click(object sender, EventArgs e)
        {
            foreverTextBox5.Text = "Marked Done. Verification Pending.";
        }
    }
}

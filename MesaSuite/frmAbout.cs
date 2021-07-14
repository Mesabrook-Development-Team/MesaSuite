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
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void AboutMesaSuite_Load(object sender, EventArgs e)
        {
            lbl_Version.Text = "Version " + Application.ProductVersion;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Close_MouseEnter(object sender, EventArgs e)
        {
            btn_Close.BackgroundImage = Properties.Resources.btn_close_hover;
        }

        private void btn_Close_MouseLeave(object sender, EventArgs e)
        {
            btn_Close.BackgroundImage = Properties.Resources.btn_close_normal;
        }
    }
}

using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCSync
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void cmdConfig_Click(object sender, EventArgs e)
        {
            frmConfig config = new frmConfig();
            config.ShowDialog();
        }

        private void cmdSync_Click(object sender, EventArgs e)
        {
            frmSync sync = new frmSync();
            sync.Show();
            Hide();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            lblDocumentation.Visible = false;
            backgroundChooser();
        }

        private void newBtnConf_MouseEnter(object sender, EventArgs e)
        {
            btnConf.BackgroundImage = Properties.Resources.btnOptOver;
        }

        private void newBtnConf_MouseLeave(object sender, EventArgs e)
        {
            btnConf.BackgroundImage = Properties.Resources.btnOptBase;
        }

        private void newBtnSync_MouseEnter(object sender, EventArgs e)
        {
            btnSync.BackgroundImage = Properties.Resources.btnSyncOver;
        }

        private void newBtnSync_MouseLeave(object sender, EventArgs e)
        {
            btnSync.BackgroundImage = Properties.Resources.btnSyncBase;
        }

        private void newBtnConf_MouseClick(object sender, MouseEventArgs e)
        {
            frmConfig config = new frmConfig();
            config.ShowDialog();
        }

        private void newBtnSync_MouseClick(object sender, MouseEventArgs e)
        {
            frmSync sync = new frmSync();
            sync.Show();
            Hide();
        }

        private void btnHelp_MouseClick(object sender, MouseEventArgs e)
        {
            Process.Start("https://mesabrook.com/mcsync/index.html");
        }

        private void btnHelp_MouseEnter(object sender, EventArgs e)
        {
            lblDocumentation.Visible = true;
        }

        private void btnHelp_MouseLeave(object sender, EventArgs e)
        {
            lblDocumentation.Visible = false;
        }

        public void backgroundChooser()
        {
            int bg = new Random().Next(0, 6);
            switch(bg)
            {
                case 1:
                    BackgroundImage = Properties.Resources.b1;
                    break;
                case 2:
                    BackgroundImage = Properties.Resources.b2;
                    break;
                case 3:
                    BackgroundImage = Properties.Resources.b3;
                    break;
                case 4:
                    BackgroundImage = Properties.Resources.b4;
                    break;
                case 5:
                    BackgroundImage = Properties.Resources.b5;
                    break;
                case 6:
                    BackgroundImage = Properties.Resources.b6;
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MesaSuite.Common;
using MesaSuite.Common.Extensions;

namespace MesaSuite
{
    public partial class frmAbout : Form
    {
        private frmSplash _frmSplash;
        bool buttonClickSfx;
        public frmAbout()
        {
            InitializeComponent();
        }

        private void AboutMesaSuite_Load(object sender, EventArgs e)
        {
            Font jokeFont = new Font("Comic Sans MS", 12);

            buttonClickSfx = UserPreferences.Get().GetPreferencesForSection("mcsync").GetOrDefault("buttonClickSfx", true).Cast<bool>(true);
            lbl_Version.Text = "MesaSuite Version: " + Application.ProductVersion;
            tabControl1.SelectedTab = tabPage1;

            if(DateTime.Today.Month == 4 && DateTime.Today.Day == 1)
            {
                lblCreditTop.Font = jokeFont;
                lblCreditTop.Text = "Slapped Together By:";
                pboxLogo.BackgroundImage = Properties.Resources.logoMSJoke;
            }
        }

        private void lnkLbl_GitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/CSX8600/MCSync");
            Close();
        }

        private void lnkLbl_Mesabrook_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://mesabrook.com");
            Close();
        }

        private void lnkLbl_Dynmap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://map.mesabrook.com");
            Close();
        }

        private void linkExtraCredit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAdditionalCredits additionalCredits = new frmAdditionalCredits();
            additionalCredits.ShowDialog(this);
        }

        private void pboxLogo_Click(object sender, EventArgs e)
        {
            if(DateTime.Today.Month == 4 && DateTime.Today.Day == 1)
            {
                using (var soundPlayer = new SoundPlayer(Properties.Resources.reverb))
                {
                    soundPlayer.Play();
                }
                MessageBox.Show("Happy April Fools' Day!", "It's gonna be alright", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/CSX8600/MCSync");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/CSX8600/MCSync");
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/CSX8600/MCSync");
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            Process.Start("https://mesabrook.com");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Process.Start("https://mesabrook.com");
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Process.Start("https://mesabrook.com");
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            Process.Start("http://map.mesabrook.com");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start("http://map.mesabrook.com");
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Process.Start("http://map.mesabrook.com");
        }
    }
}

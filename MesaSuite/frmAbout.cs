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
            btnAbout.BackgroundImage = Properties.Resources.btn_about_hover;

            if(DateTime.Today.Month == 4 && DateTime.Today.Day == 1)
            {
                lblCreditTop.Font = jokeFont;
                lblCreditTop.Text = "Slapped Together By:";
                pboxLogo.BackgroundImage = Properties.Resources.logoMSJoke;
                panel1.BackgroundImage = Properties.Resources.tmpBackground;
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            PlayButtonClickSound();
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

        private void btnAbout_Click(object sender, EventArgs e)
        {
            btnAbout.BackgroundImage = Properties.Resources.btn_about_hover;
            btnCredits.BackgroundImage = Properties.Resources.btn_credits;
            tabControl1.SelectedTab = tabPage1;
            PlayButtonClickSound();
        }

        private void btnAbout_MouseEnter(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab == tabPage2)
            {
                btnAbout.BackgroundImage = Properties.Resources.btn_about_hover;
            }
        }

        private void btnAbout_MouseLeave(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                btnAbout.BackgroundImage = Properties.Resources.btn_about;
            }
        }

        private void btnCredits_Click(object sender, EventArgs e)
        {
            btnCredits.BackgroundImage = Properties.Resources.btn_credits_hover;
            btnAbout.BackgroundImage = Properties.Resources.btn_about;
            tabControl1.SelectedTab = tabPage2;
            PlayButtonClickSound();
        }

        private void btnCredits_MouseEnter(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab == tabPage1)
            {
                btnCredits.BackgroundImage = Properties.Resources.btn_credits_hover;
            }
        }

        private void btnCredits_MouseLeave(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                btnCredits.BackgroundImage = Properties.Resources.btn_credits;
            }
        }

        public void PlayButtonClickSound()
        {
            if (!buttonClickSfx)
            {
                return;
            }

            using (var soundPlayer = new SoundPlayer(Properties.Resources.ui_button_click))
            {
                soundPlayer.Play();
            }
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
    }
}

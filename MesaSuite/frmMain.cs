using MesaSuite.Common;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace MesaSuite
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public Dictionary<Panel, string> GetProgramKeyForButton()
        {
            return new Dictionary<Panel, string>()
            {
                { pnlMCSync, "" },
                { pnlSystemManagement, "system" },
                { pnlCompanyStudio, "company" },
                { pnlGovernmentPortal, "gov" }
            };
        }

        private void cmdLogIn_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (Authentication.AuthenticationStatus == Authentication.AuthenticationStatuses.LoggedIn)
                {
                    Authentication.LogOut();
                }
                else
                {
                    Authentication.GetAuthToken(true);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred:\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            foreach(Panel panel in flow.Controls.OfType<Panel>())
            {
                panel.Visible = false;
            }

            pboxMCSyncLogo.Visible = false;
            pboxSystem.Visible = false;
            pboxCStudio.Visible = false;
            pboxGPortal.Visible = false;
            Authentication.OnLoggedIn += Authentication_OnLoggedIn;
            Authentication.OnLoggedOut += Authentication_OnLoggedOut;
            Authentication.OnProgramUpdate += Authentication_OnProgramUpdate;

            if (Authentication.AuthenticationStatus == Authentication.AuthenticationStatuses.LoggedIn)
            {
                pnlUserBtn.BackgroundImage = Properties.Resources.btnLogOutBase;
                pboxLoginStatus.Image = Properties.Resources.icn_check;
                lblLoginStatus.Text = "Logged In";
            }
            else
            {
                pnlUserBtn.BackgroundImage = Properties.Resources.btnLoginBase;
                pboxLoginStatus.Image = Properties.Resources.icn_x;
                lblLoginStatus.Text = "Not Logged In";
            }

            Authentication_OnProgramUpdate(sender, e);
        }

        private void Authentication_OnProgramUpdate(object sender, EventArgs e)
        {
            Dictionary<Panel, string> programKeysForButton = GetProgramKeyForButton();
            foreach(Panel panel in flow.Controls.OfType<Panel>())
            {
                if (!programKeysForButton.ContainsKey(panel))
                {
                    continue;
                }

                string requiredProgramKey = programKeysForButton[panel];

                Invoke(new MethodInvoker(() =>
                {
                    panel.Visible = string.IsNullOrEmpty(requiredProgramKey) || Authentication.Programs.Contains(requiredProgramKey);
                }));
            }
        }

        private void Authentication_OnLoggedOut(object sender, EventArgs e)
        {
            pboxLoginStatus.Image = Properties.Resources.icn_x;
            lblLoginStatus.Text = "Not Logged In";
        }

        private void Authentication_OnLoggedIn(object sender, EventArgs e)
        {
            pboxLoginStatus.Image = Properties.Resources.icn_check;
            lblLoginStatus.Text = "Logged In";
        }

        private void StartMCSync()
        {
            MCSync.Program.Main(StartupArguments.GetArgsForApp("mcsync"));
        }

        private void StartProgram(Action method)
        {
            Thread thread = new Thread(new ThreadStart(method));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void pboxMCSync_MouseEnter(object sender, EventArgs e)
        {
            pboxMCSync.BackgroundImage = Properties.Resources.btnMCSync_Hover;
            pboxMCSyncLogo.Visible = true;
        }

        private void pboxMCSync_MouseLeave(object sender, EventArgs e)
        {
            pboxMCSync.BackgroundImage = Properties.Resources.btnMCSync;
            pboxMCSyncLogo.Visible = false;
        }

        private void pboxMCSync_Click(object sender, EventArgs e)
        {
            PlayButtonClickSound();
            StartProgram(StartMCSync);
        }

        private void pnlUserBtn_MouseEnter(object sender, EventArgs e)
        {
            if(Authentication.AuthenticationStatus == Authentication.AuthenticationStatuses.LoggedOut)
            {
                pnlUserBtn.BackgroundImage = Properties.Resources.btnLoginHover;
            }
            else if(Authentication.AuthenticationStatus == Authentication.AuthenticationStatuses.LoggedIn)
            {
                pnlUserBtn.BackgroundImage = Properties.Resources.btnLogOutHover;
            }
        }

        private void pnlUserBtn_MouseLeave(object sender, EventArgs e)
        {
            if (Authentication.AuthenticationStatus == Authentication.AuthenticationStatuses.LoggedOut)
            {
                pnlUserBtn.BackgroundImage = Properties.Resources.btnLoginBase;
            }
            else if (Authentication.AuthenticationStatus == Authentication.AuthenticationStatuses.LoggedIn)
            {
                pnlUserBtn.BackgroundImage = Properties.Resources.btnLogOutBase;
            }
        }

        private void pnlUserBtn_Click(object sender, EventArgs e)
        {
            PlayButtonClickSound();
            try
            {
                if (Authentication.AuthenticationStatus == Authentication.AuthenticationStatuses.LoggedIn)
                {
                    Authentication.LogOut();
                }
                else
                {
                    Authentication.GetAuthToken(true);
                    pnlUserBtn.BackgroundImage = Properties.Resources.btnLogOutBase;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pnlUserBtn.BackgroundImage = Properties.Resources.btnLoginBase;
            }
        }

        private void pboxMCSync_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pboxMCSync, "Launch MCSync");
        }

        private void pnlUserBtn_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            if (Authentication.AuthenticationStatus == Authentication.AuthenticationStatuses.LoggedOut)
            {
                tt.SetToolTip(this.pnlUserBtn, "Sign in to your Mesabrook account.");
            }
            else if (Authentication.AuthenticationStatus == Authentication.AuthenticationStatuses.LoggedIn)
            {
                tt.SetToolTip(this.pnlUserBtn, "Sign out of your Mesabrook account.");
            }
        }

        private void pboxUserManagement_Click(object sender, EventArgs e)
        {
            StartProgram(() => SystemManagement.Program.Main(StartupArguments.GetArgsForApp("usermanagement")));
            PlayButtonClickSound();
        }

        private void pboxUserManagement_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pboxMCSync, "System Management");
        }

        private void pboxUserManagement_MouseEnter(object sender, EventArgs e)
        {
            pboxSystemManagement.Image = Properties.Resources.icn_sysmgt_hover;
            pboxSystem.Visible = true;
        }

        private void pboxUserManagement_MouseLeave(object sender, EventArgs e)
        {
            pboxSystemManagement.Image = Properties.Resources.icn_sysmgt_normal;
            pboxSystem.Visible = false;
        }

        private void aboutMesaSuiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayButtonClickSound();
            frmAbout aboutMS = new frmAbout();
            aboutMS.ShowDialog();
        }

        public void PlayButtonClickSound()
        {
            using (var soundPlayer = new SoundPlayer(Properties.Resources.ui_button_click))
            {
                soundPlayer.Play();
            }
        }

        private void pboxCompanyStudio_Click(object sender, EventArgs e)
        {
            PlayButtonClickSound();
            StartProgram(() => CompanyStudio.Program.Main(StartupArguments.GetArgsForApp("company")));
        }

        private void pboxCompanyStudio_MouseEnter(object sender, EventArgs e)
        {
            pboxCompanyStudio.Image = Properties.Resources.icn_cstudio_hover;
            pboxCStudio.Visible = true;
        }

        private void pboxCompanyStudio_MouseLeave(object sender, EventArgs e)
        {
            pboxCompanyStudio.Image = Properties.Resources.icn_cstudio_normal;
            pboxCStudio.Visible = false;
        }

        private void pnlUserBtn_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && Authentication.AuthenticationStatus == Authentication.AuthenticationStatuses.LoggedOut)
            {
                ctxSignIn.Show(Cursor.Position);
            }
            else if (e.Button == MouseButtons.Left)
            {
                pnlUserBtn_Click(sender, e);
            }
        }

        private void mnuRegister_Click(object sender, EventArgs e)
        {
            Authentication.Register();
        }

        private void pboxGovernmentPortal_Click(object sender, EventArgs e)
        {
            StartProgram(() => GovernmentPortal.Program.Main(StartupArguments.GetArgsForApp("government")));
        }

        private void pboxGovernmentPortal_MouseEnter(object sender, EventArgs e)
        {
            pboxGovernmentPortal.Image = Properties.Resources.icn_govt_portal_hov;
            pboxGPortal.Visible = true;
        }

        private void pboxGovernmentPortal_MouseLeave(object sender, EventArgs e)
        {
            pboxGovernmentPortal.Image = Properties.Resources.icn_govt_portal;
            pboxGPortal.Visible = false;
        }
    }
}

using MesaSuite.Common;
using MesaSuite.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }

        private bool buttonClickSfx;
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
                { pnlGovernmentPortal, "gov" },
                { pnlTowing, "tow" }
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
            if (GlobalSettings.InternalEditionMode)
            {
                Text += " (INTERNAL EDITION)";
            }

            foreach(Panel panel in flow.Controls.OfType<Panel>())
            {
                panel.Visible = false;
            }

            pboxMCSyncLogo.Visible = false;
            pboxSystem.Visible = false;
            pboxCStudio.Visible = false;
            pboxGPortal.Visible = false;
            pboxTowTxt.Visible = false;
            Authentication.OnLoggedIn += Authentication_OnLoggedIn;
            Authentication.OnLoggedOut += Authentication_OnLoggedOut;
            Authentication.OnProgramUpdate += Authentication_OnProgramUpdate;

            if (Authentication.AuthenticationStatus == Authentication.AuthenticationStatuses.LoggedIn)
            {
                pnlUserBtn.BackgroundImage = Properties.Resources.btnLogOutBase;
                pboxLoginStatus.Image = Properties.Resources.icn_check;
                lblLoginStatus.Text = "Logged In";
                mnuProfile.Visible = true;
            }
            else
            {
                pnlUserBtn.BackgroundImage = Properties.Resources.btnLoginBase;
                pboxLoginStatus.Image = Properties.Resources.icn_x;
                lblLoginStatus.Text = "Not Logged In";
                mnuProfile.Visible = false;
            }

            // Load Personalization Settings
            UserPreferences preferences = UserPreferences.Get();
            buttonClickSfx = preferences.GetPreferencesForSection("mcsync").GetOrSetDefault("buttonClickSfx", true).Cast<bool>(true);

            UpdateLook();

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
            Invoke(new MethodInvoker(() =>
            {
                pboxLoginStatus.Image = Properties.Resources.icn_x;
                lblLoginStatus.Text = "Not Logged In";
                mnuProfile.Visible = false;

                foreach(Form form in Application.OpenForms.OfType<Form>().ToList())
                {
                    if (form is frmClients || form is frmLoginHistory)
                    {
                        form.Close();
                    }
                }
            }));
        }

        private void Authentication_OnLoggedIn(object sender, EventArgs e)
        {
            Invoke(new MethodInvoker(() =>
            {
                pboxLoginStatus.Image = Properties.Resources.icn_check;
                lblLoginStatus.Text = "Logged In";
                mnuProfile.Visible = true;
            }));
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
            if(buttonClickSfx)
            {
                using (var soundPlayer = new SoundPlayer(Properties.Resources.ui_button_click))
                {
                    soundPlayer.Play();
                }
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
            PlayButtonClickSound();
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

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {}

        private void soundEffectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonClickSfx = soundEffectToolStripMenuItem.Checked;
            UserPreferences preferences = UserPreferences.Get();
            preferences.GetPreferencesForSection("mcsync")["buttonClickSfx"] = buttonClickSfx;
            preferences.Save();

            if(buttonClickSfx)
            {
                PlayButtonClickSound();
            }
        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSetBackground form = new frmSetBackground(this);
            form.ShowDialog();
        }

        public void UpdateLook()
        {
            UserPreferences preferences = UserPreferences.Get();
            Dictionary<string, object> mcSyncPreferences = preferences.GetPreferencesForSection("mcsync");
            soundEffectToolStripMenuItem.Checked = mcSyncPreferences.GetOrSetDefault("buttonClickSfx", true).Cast<bool>(true);
            dynamicSplashScreensToolStripMenuItem.Checked = mcSyncPreferences.GetOrSetDefault("dynamicSplashScreen", true).Cast<bool>(true);

            try
            {
                string wallpaperPath = preferences.GetPreferencesForSection("mcsync").GetOrSetDefault("wallpaperPath", defaultValue: null).Cast<string>();
                Image bg = new Bitmap(wallpaperPath);
                BackgroundImage = bg;

                string imageLayoutPreference = preferences.GetPreferencesForSection("mcsync").GetOrSetDefault("imageLayout", ImageLayout.None.ToString()).Cast<string>(ImageLayout.None.ToString());
                ImageLayout imageLayout = ImageLayout.None;
                if (!string.IsNullOrEmpty(imageLayoutPreference) && Enum.TryParse(imageLayoutPreference, true, out ImageLayout imageLayoutParsed))
                {
                    imageLayout = imageLayoutParsed;
                }

                BackgroundImageLayout = imageLayout;
            }
            catch (Exception ex)
            {
                BackgroundImage = Properties.Resources.bg;
                BackgroundImageLayout = ImageLayout.Tile;
            }
        }

        private void pboxTowing_Click(object sender, EventArgs e)
        {
            StartProgram(() => Towing.Program.Main(StartupArguments.GetArgsForApp("tow")));
            PlayButtonClickSound();
        }

        private void pboxTowing_MouseEnter(object sender, EventArgs e)
        {
            pboxTowing.Image = Properties.Resources.icn_tow_hover;
            pboxTowTxt.Visible = true;
        }

        private void pboxTowing_MouseLeave(object sender, EventArgs e)
        {
            pboxTowing.Image = Properties.Resources.icn_tow;
            pboxTowTxt.Visible = false;
        }

        private void mnuPATs_Click(object sender, EventArgs e)
        {
            frmPersonalAccessTokens accessTokens = new frmPersonalAccessTokens();
            accessTokens.Show();
        }

        private void mnuLoginHistoryApps_Click(object sender, EventArgs e)
        {
            frmLoginHistory history = new frmLoginHistory();
            history.Show();
        }

        private void myAppsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClients clients = new frmClients();
            clients.Show();
        }

        private void dynamicSplashScreensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dynamicSplashScreensToolStripMenuItem.Checked = !dynamicSplashScreensToolStripMenuItem.Checked;
            UserPreferences userPreferences = UserPreferences.Get();
            userPreferences.GetPreferencesForSection("mcsync")["dynamicSplashScreen"] = dynamicSplashScreensToolStripMenuItem.Checked;
            userPreferences.Save();
        }

        private void pboxNotifs_Click(object sender, EventArgs e)
        {
            frmNotificationsCenter frm = new frmNotificationsCenter();
            frm.ShowDialog();
        }

        private void pboxTasks_Click(object sender, EventArgs e)
        {
            frmNotificationsCenter frm = new frmNotificationsCenter();
            frm.ShowDialog();
        }
    }
}

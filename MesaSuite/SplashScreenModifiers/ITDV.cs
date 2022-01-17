using System;
using System.Drawing;

namespace MesaSuite.SplashScreenModifiers
{
    internal class ITDV : ISplashScreenModifier
    {
        public bool IsValid() => DateTime.Today.Month == 3 && DateTime.Today.Day == 31;

        public void Modify(frmSplash splash)
        {
            splash.pBoxLogo.Image = Properties.Resources.logo_MS_pink;
            splash.BackgroundImage = Properties.Resources.bg_prideflag_trans;
            splash.lblMessage.Text = "Mesabrook proudly stands with the Trans community!";
            splash.pboxHat.Visible = false;
            splash.lblVersion.ForeColor = Color.Black;
            splash.lblMessage.ForeColor = Color.Black;
        }
    }
}
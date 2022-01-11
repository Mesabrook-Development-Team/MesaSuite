using System;
using System.Drawing;

namespace MesaSuite.SplashScreenModifiers
{
    internal class BirthdayMesabrook : ISplashScreenModifier
    {
        public bool IsValid() => DateTime.Today.Month == 11 && DateTime.Today.Day == 30;

        public void Modify(frmSplash splash)
        {
            splash.pBoxLogo.Image = Properties.Resources.logo_MS_Gold;
            splash.BackgroundImage = Properties.Resources.bg_ms;
            splash.lblMessage.Text = "Happy Anniversary, Mesabrook!";
            splash.pboxHat.Visible = true;
            splash.lblMessage.ForeColor = Color.White;
            splash.pboxHat.BackgroundImage = Properties.Resources.hat_bday;
        }
    }
}

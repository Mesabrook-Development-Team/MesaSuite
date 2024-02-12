using System;
using System.Drawing;

namespace MesaSuite.SplashScreenModifiers
{
    internal class PrideMonth : ISplashScreenModifier
    {
        public bool IsValid() => DateTime.Today.Month == 6;

        public void Modify(frmSplash splash)
        {
            splash.pBoxLogo.Image = Properties.Resources.logo_new_6;
            splash.BackgroundImage = Properties.Resources.bg_prideflag;
            splash.lblMessage.Text = "Mesabrook stands with the LGBTQIA+ Community!";
            splash.pboxHat.Visible = false;
            splash.lblMessage.ForeColor = Color.White;
        }
    }
}

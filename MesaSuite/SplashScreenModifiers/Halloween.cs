using System;

namespace MesaSuite.SplashScreenModifiers
{
    internal class Halloween : ISplashScreenModifier
    {
        public bool IsValid() => DateTime.Today.Month == 10 && DateTime.Today.Day == 31;

        public void Modify(frmSplash splash)
        {
            splash.pboxHat.Visible = false;
            splash.pBoxLogo.Image = Properties.Resources.logo_MS_Red;
            splash.BackgroundImage = Properties.Resources.bg_halloween;
            splash.lblMessage.Text = "Happy Halloween from the Mesabrook Development Team!" + Environment.NewLine + Environment.NewLine + "Background Credit: McPhysH";
        }
    }
}

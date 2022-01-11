using System;
using System.Drawing;

namespace MesaSuite.SplashScreenModifiers
{
    internal class ThanksgivingCanada : ISplashScreenModifier
    {
        public bool IsValid()
        {
            if (DateTime.Today.Month != 10) { return false; }

            DateTime workingDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            while(workingDate.DayOfWeek != DayOfWeek.Monday)
            {
                workingDate = workingDate.AddDays(1);
            }

            return DateTime.Today.Day == workingDate.Day + 7; // Second Monday in October
        }

        public void Modify(frmSplash splash)
        {
            splash.pBoxLogo.Image = Properties.Resources.logo_MS_Orange;
            splash.BackgroundImage = Properties.Resources.bg_thanksgiving;
            splash.lblMessage.Text = "Happy Thanksgiving (Canada) from the Mesabrook Development Team!";
            splash.lblMessage.ForeColor = Color.Black;
            splash.pboxHat.Visible = true;
            splash.pboxHat.BackgroundImage = Properties.Resources.hat_pil;
        }
    }
}

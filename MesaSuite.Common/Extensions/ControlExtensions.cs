using System.Windows.Forms;

namespace MesaSuite.Common.Extensions
{
    public static class ControlExtensions
    {
        public static void ShowError(this Control form, string error)
        {
            MessageBox.Show(form, error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowInformation(this Control form, string info)
        {
            MessageBox.Show(form, info, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool Confirm(this Control form, string confirmString, string title = "Warning")
        {
            return MessageBox.Show(form, confirmString, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
        }
    }
}

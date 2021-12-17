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
    }
}

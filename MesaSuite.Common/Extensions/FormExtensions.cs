using System.Windows.Forms;

namespace MesaSuite.Common.Extensions
{
    public static class FormExtensions
    {
        public static void ShowError(this Form form, string error)
        {
            MessageBox.Show(form, error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

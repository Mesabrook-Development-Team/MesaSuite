using System.Collections.Generic;
using System.Windows.Forms;

namespace MesaSuite.Common.Extensions
{
    public static class ControlExtensions
    {
        public static void ShowError(this Control form, string error)
        {
            MessageBox.Show(form, error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowWarning(this Control form, string error)
        {
            MessageBox.Show(form, error, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowInformation(this Control form, string info)
        {
            MessageBox.Show(form, info, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool Confirm(this Control form, string confirmString, string title = "Warning")
        {
            return MessageBox.Show(form, confirmString, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
        }

        public static bool AreFieldsPresent(this Control control, List<(string, Control)> displayNameControls)
        {
            foreach((string, Control) displayNameControl in displayNameControls)
            {
                if ((displayNameControl.Item2 is TextBox textBox && string.IsNullOrEmpty(textBox.Text)) ||
                    (displayNameControl.Item2 is ComboBox comboBox && comboBox.SelectedItem == null))
                {
                    control.ShowError($"{displayNameControl.Item1} is a required field");
                    return false;
                }
            }

            return true;
        }
    }
}

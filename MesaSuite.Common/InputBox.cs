using MesaSuite.Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MesaSuite.Common
{
    public partial class InputBox : Form
    {
        public string InputValue { get; set; }
        public InputBox()
        {
            InitializeComponent();
        }

        public static T GetInput<T>(string label, string title = "Input", string okLabel = "OK")
        {
            InputBox inputBox = new InputBox();
            inputBox.lblPrompt.Text = label;
            inputBox.Text = title;
            inputBox.cmdOK.Text = okLabel;
            inputBox.FormClosing += (sender, e) => GetInput_InputBox_FormClosing<T>(sender, e);
            inputBox.ShowDialog();

            if (inputBox.DialogResult == DialogResult.Cancel)
            {
                return default(T);
            }

            return (T)Convert.ChangeType(inputBox.InputValue, typeof(T));
        }

        private static void GetInput_InputBox_FormClosing<T>(object sender, FormClosingEventArgs e)
        {
            InputBox inputBox = (InputBox)sender;
            if (inputBox.DialogResult == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                Convert.ChangeType(inputBox.InputValue, typeof(T));
            }
            catch
            {
                inputBox.ShowError("Input is invalid");
                e.Cancel = true;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            InputValue = txtInput.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

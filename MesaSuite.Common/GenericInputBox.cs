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
    public partial class GenericInputBox : Form
    {
        public Type ResultType { get; set; }
        public object Result { get; private set; }
        public string AcceptText
        {
            get => cmdAccept.Text;
            set => cmdAccept.Text = value;
        }

        public string CancelText
        {
            get => cmdCancel.Text;
            set => cmdCancel.Text = value;
        }

        public string Prompt
        {
            get => lblPrompt.Text; 
            set => lblPrompt.Text = value;
        }

        public GenericInputBox()
        {
            InitializeComponent();
        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            try
            {
                Result = Convert.ChangeType(txtInput.Text, ResultType);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch
            {
                this.ShowError("Input value is of the incorrect format");
                return;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

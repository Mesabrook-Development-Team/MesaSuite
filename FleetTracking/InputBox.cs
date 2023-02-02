using System;
using System.Drawing;
using System.Windows.Forms;
using FleetTracking.Interop;
using MesaSuite.Common.Extensions;

namespace FleetTracking
{
    public partial class InputBox : UserControl, IFleetTrackingControl
    {
        private Size InitialSize = new Size(350, 81);
        public string InputValue { get; set; }
        public bool MultiLine { get; set; }

        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; } // We shouldn't really need this but the interface requires it

        public Type InputValueType { get; set; } = typeof(string);

        public InputBox()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            InputValue = null;
            ParentForm.DialogResult = DialogResult.Cancel;
            ParentForm.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                InputValue = Convert.ChangeType(txtInput.Text, InputValueType).ToString();
            }
            catch
            {
                this.ShowError("Input is invalid");
                return;
            }

            ParentForm.DialogResult = DialogResult.OK;
            ParentForm.Close();
        }

        private void InputBox_Load(object sender, EventArgs e)
        {
            ParentForm.AcceptButton = cmdOK;
            ParentForm.CancelButton = cmdCancel;

            if (MultiLine)
            {
                InitialSize = new Size(350, 121);
                txtInput.Multiline = true;
                txtInput.AcceptsReturn = true;
                txtInput.ScrollBars = ScrollBars.Vertical;
            }

            ParentForm.Text = this.Text;
            ParentForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            ParentForm.MaximizeBox = false;
            ParentForm.MinimizeBox = false;
            ParentForm.ClientSize = InitialSize;
        }
    }
}

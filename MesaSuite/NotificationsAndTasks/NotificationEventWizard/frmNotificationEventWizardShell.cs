using MesaSuite.Common.Wizard;
using ReaLTaiizor.Controls;
using System;
using System.Windows.Forms;

namespace MesaSuite.NotificationsAndTasks.NotificationEventWizard
{
    public partial class frmNotificationEventWizardShell : Form, IWizardShell
    {
        private ButtonAdapter _runButtonAdapter;
        private ButtonAdapter _cancelButtonAdapter;
        private ButtonAdapter _nextButtonAdapter;
        private ButtonAdapter _backButtonAdapter;

        public frmNotificationEventWizardShell()
        {
            InitializeComponent();
            _runButtonAdapter = new ButtonAdapter(cmdRun);
            _cancelButtonAdapter = new ButtonAdapter(cmdCancel);
            _nextButtonAdapter = new ButtonAdapter(cmdNext);
            _backButtonAdapter = new ButtonAdapter(cmdBack);

            imageList.Images.Add("success", Properties.Resources.accept);
            imageList.Images.Add("error", Properties.Resources.error);
        }

        public ListView Navigation => lstNav;

        public PictureBox Logo => new PictureBox();

        public Label Title => new Label();

        public System.Windows.Forms.Button RunButton => _runButtonAdapter;

        public System.Windows.Forms.Button NextButton => _nextButtonAdapter;

        public System.Windows.Forms.Button BackButton => _backButtonAdapter;

        public System.Windows.Forms.Panel Content => pnlContent;

        System.Windows.Forms.Button IWizardShell.CancelButton => _cancelButtonAdapter;

        public void CloseWizard() => Close();

        public void HideLoader() => loader.Visible = false;

        public void SetWindowText(string text) { }

        public void ShowLoader()
        {
            loader.BringToFront();
            loader.Visible = true;
        }

        public void ShowWizard() => Show();

        public class ButtonAdapter : System.Windows.Forms.Button
        {
            private ForeverButton foreverButton;
            public ButtonAdapter(ForeverButton foreverButton)
            {
                this.foreverButton = foreverButton;
                this.foreverButton.Click += (_, e) => OnClick(e);
            }

            protected override void OnEnabledChanged(EventArgs e)
            {
                base.OnEnabledChanged(e);

                foreverButton.Enabled = this.Enabled;
            }

            protected override void OnTextChanged(EventArgs e)
            {
                base.OnTextChanged(e);

                foreverButton.Text = this.Text;
            }
        }
    }
}

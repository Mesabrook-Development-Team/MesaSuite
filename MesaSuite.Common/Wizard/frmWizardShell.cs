using System;
using System.Windows.Forms;

namespace MesaSuite.Common.Wizard
{
    public partial class frmWizardShell : Form, IWizardShell
    {
        public frmWizardShell()
        {
            InitializeComponent();

            imageList.Images.Add("success", Properties.Resources.accept);
            imageList.Images.Add("error", Properties.Resources.error);
        }

        public ListView Navigation => lstNav;

        public PictureBox Logo => picLogo;

        public Label Title => lblTitle;

        public Button RunButton => cmdRun;

        public Button NextButton => cmdNext;

        public Button BackButton => cmdBack;

        public Panel Content => pnlContent;

        Button IWizardShell.CancelButton => cmdCancel;

        public void CloseWizard() => Close();

        public void HideLoader()
        {
            loader.Visible = false;
        }

        public void SetWindowText(string text) => Text = text;

        public void ShowLoader()
        {
            loader.BringToFront();
            loader.Visible = true;
        }

        public void ShowWizard() => Show();
    }
}

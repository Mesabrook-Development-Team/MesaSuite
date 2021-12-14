using System;
using System.Windows.Forms;
using GovernmentPortal.Models;

namespace GovernmentPortal
{
    public partial class frmPortal : Form
    {
        private Government _government = null;

        public frmPortal()
        {
            InitializeComponent();
        }

        private void frmPortal_Shown(object sender, EventArgs e)
        {
            frmSelectGovernment selectGovernment = new frmSelectGovernment();
            if (DialogResult.Cancel == selectGovernment.ShowDialog())
            {
                Close();
                return;
            }

            _government = selectGovernment.SelectedGovernment;
        }
    }
}

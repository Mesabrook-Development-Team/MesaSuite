using CompanyStudio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CompanyStudio.Email
{
    public partial class frmEmailExplorer : DockContent, ICompanyStudioContent
    {
        public frmEmailExplorer()
        {
            InitializeComponent();
        }

        private Company _company = null;
        public Company Company { set => _company = value; }

        private void frmEmailExplorer_Load(object sender, EventArgs e)
        {
            if (_company == null || _company.CompanyID == 0)
            {
                MessageBox.Show("You must select a company.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            if (string.IsNullOrEmpty(_company.EmailDomain))
            {
                MessageBox.Show("Your company does not have an email domain.  Please contact a System Administrator to set this up for you.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
        }
    }
}

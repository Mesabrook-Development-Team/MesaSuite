using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyStudio.Wizard
{
    public partial class frmWizardShell : Form
    {
        public frmWizardShell()
        {
            InitializeComponent();

            imageList.Images.Add("success", Properties.Resources.accept);
            imageList.Images.Add("error", Properties.Resources.error);
        }
    }
}

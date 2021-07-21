using System;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CompanyStudio
{
    public partial class frmStudio : Form
    {
        public frmStudio()
        {
            InitializeComponent();
        }

        private void frmStudio_Load(object sender, EventArgs e)
        {
            toolStripExtender.SetStyle(mnuBanner, VisualStudioToolStripExtender.VsVersion.Vs2015, vS2015DarkTheme);
            dckPanel.Theme = vS2015DarkTheme;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompanyStudio.Models;
using WeifenLuo.WinFormsUI.Docking;

namespace CompanyStudio
{
    public partial class frmStartPage : DockContent
    {
        public frmStudio Studio { get; set; }

        public frmStartPage()
        {
            InitializeComponent();
        }

        private void frmStartPage_Load(object sender, EventArgs e)
        {
            foreach(Company company in Studio.Companies.OrderBy(c => c.Name))
            {
                TabPage tab = new TabPage();
                tab.Text = company.Name;
                tbpToDoList.TabPages.Add(tab);
            }
        }
    }
}

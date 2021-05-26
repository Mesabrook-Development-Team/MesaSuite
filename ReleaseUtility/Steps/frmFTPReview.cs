using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReleaseUtility.Steps
{
    public partial class frmFTPReview : Form
    {
        public IEnumerable<string> Files { get; set; }
        public string[] PreSelected { get; set; }

        public frmFTPReview()
        {
            InitializeComponent();
        }

        private void frmFTPReview_Load(object sender, EventArgs e)
        {
            foreach(string file in Files)
            {
                bool selected = PreSelected == null || PreSelected.Contains(file);
                chkFiles.Items.Add(file, selected);
            }
        }

        private void cmdSelect_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Files = chkFiles.CheckedItems.Cast<string>();

            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }
    }
}

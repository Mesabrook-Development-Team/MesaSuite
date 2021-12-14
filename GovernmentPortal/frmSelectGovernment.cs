using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GovernmentPortal.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;

namespace GovernmentPortal
{
    public partial class frmSelectGovernment : Form
    {
        private Government _government = null;
        public Government SelectedGovernment => _government;

        public frmSelectGovernment()
        {
            InitializeComponent();
        }

        private async void frmSelectGovernment_Load(object sender, EventArgs e)
        {
            loader.BringToFront();
            loader.Visible = true;

            GetData getData = new GetData(DataAccess.APIs.GovernmentPortal, "Government/GetForUser");
            List<Government> governments = await getData.GetObject<List<Government>>() ?? new List<Government>();
            
            foreach(Government government in governments)
            {
                cboGovernments.Items.Add(DropDownItem.Create(government, government.Name));
            }

            loader.Visible = false;
        }

        private void cmdConnect_Click(object sender, EventArgs e)
        {
            DropDownItem<Government> selectedItem = cboGovernments.SelectedItem?.Cast<DropDownItem<Government>>();

            if (selectedItem == null)
            {
                MessageBox.Show("You must select a Government", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _government = selectedItem.Object;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

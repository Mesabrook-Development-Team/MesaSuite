using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemManagement.Models;

namespace SystemManagement
{
    public partial class frmEditDomain : Form
    {
        public int DomainID { get; set; }
        public frmEditDomain()
        {
            InitializeComponent();
        }

        private async void frmEditDomain_Load(object sender, EventArgs e)
        {
            Enabled = false;

            GetData get = new GetData(DataAccess.APIs.SystemManagement, "Domain/Get");
            get.QueryString.Add("id", DomainID.ToString());

            Domain domain = await get.GetObject<Domain>();

            if (domain == null)
            {
                Close();
                return;
            }

            txtDomain.Text = domain.DomainName;

            Enabled = true;
            BringToFront();
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDomain.Text))
            {
                this.ShowError("Domain is a required field.");
                return;
            }

            if (txtDomain.Text.Contains("@"))
            {
                this.ShowError("Do not include the @ symbol in the domain name.");
                return;
            }

            Domain domain = new Domain()
            {
                DomainID = DomainID,
                DomainName = txtDomain.Text
            };

            PutData put = new PutData(DataAccess.APIs.SystemManagement, "Domain/Put", domain);
            await put.ExecuteNoResult();

            if (!put.RequestSuccessful)
            {
                return;
            }

            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

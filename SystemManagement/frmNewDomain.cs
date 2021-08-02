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
    public partial class frmNewDomain : Form
    {
        public frmNewDomain()
        {
            InitializeComponent();
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDomain.Text))
            {
                this.ShowError("Email is a required field.");
                return;
            }

            if (txtDomain.Text.Contains("@"))
            {
                this.ShowError("Do not include the @ symbol in the domain name.");
                return;
            }

            Domain domain = new Domain()
            {
                DomainName = txtDomain.Text
            };

            PostData post = new PostData(DataAccess.APIs.SystemManagement, "Domain/Post", domain);
            await post.ExecuteNoResult();

            if (!post.RequestSuccessful)
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

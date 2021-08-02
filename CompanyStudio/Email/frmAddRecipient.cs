using CompanyStudio.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using System;
using System.Windows.Forms;

namespace CompanyStudio.Email
{
    public partial class frmAddRecipient : BaseCompanyStudioContent
    {
        public int DistributionListID { get; set; }
        public frmAddRecipient()
        {
            InitializeComponent();
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                this.ShowError("Email is a required field.");
                return;
            }

            DistributionListRecipient recipient = new DistributionListRecipient()
            {
                DistributionListRecipientListID = DistributionListID,
                DistributionListRecipientAddress = txtEmail.Text
            };

            PostData post = new PostData(DataAccess.APIs.CompanyStudio, "DistributionListRecipient/Post", recipient);
            post.Headers.Add("companyid", Company.CompanyID.ToString());
            await post.ExecuteNoResult();

            if (!post.RequestSuccessful)
            {
                return;
            }

            DialogResult = DialogResult.OK;

            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }
    }
}

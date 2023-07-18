using MesaSuite.Common.Data;
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
    public partial class frmTOSEditor : Form
    {
        public TermsOfService.Types Type { get; set; }
        public frmTOSEditor()
        {
            InitializeComponent();
        }

        private async void frmTOSEditor_Load(object sender, EventArgs e)
        {
            string action = Type == TermsOfService.Types.MesabrookServer ? "Mesabrook" : "MesaSuite";
            GetData get = new GetData(DataAccess.APIs.SystemManagement, "TermsOfService/Get/" + action);
            get.RequireAuthentication = false;
            string terms = await get.GetObject<string>();
            txtTerms.Text = terms;
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            txtTerms.Enabled = false;
            cmdSave.Enabled = false;
            cmdCancel.Enabled = false;

            try
            {
                TermsOfService termsOfService = new TermsOfService()
                {
                    Type = Type,
                    Terms = txtTerms.Text
                };

                PostData post = new PostData(DataAccess.APIs.SystemManagement, "TermsOfService/Post", termsOfService);
                await post.ExecuteNoResult();
                if (post.RequestSuccessful)
                {
                    Close();
                }
            }
            finally
            {
                txtTerms.Enabled = true;
                cmdSave.Enabled = true;
                cmdCancel.Enabled = true;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

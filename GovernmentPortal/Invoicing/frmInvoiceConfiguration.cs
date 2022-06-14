using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GovernmentPortal.Extensions;
using GovernmentPortal.Models;
using MesaSuite.Common.Data;

namespace GovernmentPortal.Invoicing
{
    public partial class frmInvoiceConfiguration : Form
    {
        public long GovernmentID { get; set; }
        public frmInvoiceConfiguration()
        {
            InitializeComponent();
        }

        public frmInvoiceConfiguration(long governmentID) : this()
        {
            GovernmentID = governmentID;
        }

        private async void frmInvoiceConfiguration_Load(object sender, EventArgs e)
        {
            loader.BringToFront();
            loader.Visible = true;

            GetData getGov = new GetData(DataAccess.APIs.GovernmentPortal, $"Government/Get/{GovernmentID}");
            getGov.RequestFields = new List<string>()
            {
                nameof(Government.InvoiceNumberPrefix),
                nameof(Government.NextInvoiceNumber)
            };
            getGov.AddGovHeader(GovernmentID);
            Government government = await getGov.GetObject<Government>();
            if (government == null)
            {
                Dispose();
                return;
            }

            txtPrefix.Text = government.InvoiceNumberPrefix;
            txtNextInvoiceNumber.Text = government.NextInvoiceNumber;

            loader.Visible = false;
        }

        private async void cmdSave_Click(object sender, EventArgs e)
        {
            PatchData patchInvoiceFields = new PatchData(DataAccess.APIs.GovernmentPortal, "Government/Patch", PatchData.PatchMethods.Replace, GovernmentID, new Dictionary<string, object>()
            {
                { nameof(Government.InvoiceNumberPrefix), txtPrefix.Text },
                { nameof(Government.NextInvoiceNumber), txtNextInvoiceNumber.Text }
            });
            patchInvoiceFields.AddGovHeader(GovernmentID);
            patchInvoiceFields.RequestFields = new List<string>()
            {
                nameof(Government.InvoiceNumberPrefix),
                nameof(Government.NextInvoiceNumber)
            };
            await patchInvoiceFields.Execute();
            if (patchInvoiceFields.RequestSuccessful)
            {
                Close();
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

using CompanyStudio.Extensions;
using CompanyStudio.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyStudio.Invoicing
{
    public partial class frmAutomaticPaymentConfiguration : BaseCompanyStudioContent, ILocationScoped
    {
        List<Account> accountsUserHasAccessTo = new List<Account>();
        public frmAutomaticPaymentConfiguration()
        {
            InitializeComponent();
        }

        public Location LocationModel { get; set; }

        private async void frmAutomaticPaymentConfiguration_Load(object sender, EventArgs e)
        {
            await ReloadData();
        }

        private async Task ReloadData()
        {
            lstConfigs.Items.Clear();
            pnlPlaceholder.Visible = true;
            pnlDetails.Visible = false;
            cboPaymentAccount.Items.Clear();

            long? selectedConfigurationID = null;
            if (lstConfigs.SelectedItems.Count > 0)
            {
                selectedConfigurationID = (lstConfigs.SelectedItems[0].Tag as AutomaticInvoicePaymentConfiguration)?.AutomaticInvoicePaymentConfigurationID;
            }

            GetData get = new GetData(DataAccess.APIs.CompanyStudio, "Account/GetAllForUser");
            get.AddLocationHeader(Company.CompanyID, LocationModel.LocationID);
            accountsUserHasAccessTo = await get.GetObject<List<Account>>() ?? new List<Account>();

            get.Resource = "AutomaticInvoicePaymentConfiguration/GetAll";
            List<AutomaticInvoicePaymentConfiguration> automaticInvoicePaymentConfigurations = await get.GetObject<List<AutomaticInvoicePaymentConfiguration>>() ?? new List<AutomaticInvoicePaymentConfiguration>();
            foreach (AutomaticInvoicePaymentConfiguration automaticInvoicePaymentConfiguration in automaticInvoicePaymentConfigurations.OrderBy(aipc => aipc.LocationPayee?.Company.Name ?? aipc.GovernmentPayee?.Name).ThenBy(aipc => aipc.LocationPayee?.Name))
            {
                ListViewItem listViewItem = new ListViewItem(new[]
                {
                    automaticInvoicePaymentConfiguration.LocationIDPayee != null ? $"{automaticInvoicePaymentConfiguration.LocationPayee.Company.Name} ({automaticInvoicePaymentConfiguration.LocationPayee.Name})" : automaticInvoicePaymentConfiguration.GovernmentPayee?.Name + " (Government)",
                    automaticInvoicePaymentConfiguration.PaidAmount?.ToString("N2") ?? "0.00",
                    automaticInvoicePaymentConfiguration.MaxAmount?.ToString("N2") ?? "0.00"
                });
                listViewItem.Tag = automaticInvoicePaymentConfiguration;
                lstConfigs.Items.Add(listViewItem);
                listViewItem.Selected = automaticInvoicePaymentConfiguration.AutomaticInvoicePaymentConfigurationID == selectedConfigurationID;
            }
        }

        private void lstConfigs_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutomaticInvoicePaymentConfiguration selectedConfiguration = null;
            if (lstConfigs.SelectedItems.Count > 0)
            {
                selectedConfiguration = lstConfigs.SelectedItems[0].Tag as AutomaticInvoicePaymentConfiguration;
            }

            if (selectedConfiguration == null)
            {
                pnlPlaceholder.Visible = true;
                pnlDetails.Visible = false;

                return;
            }

            cboPaymentAccount.Items.Clear();
            foreach(Account account in accountsUserHasAccessTo)
            {
                DropDownItem<Account> ddi = new DropDownItem<Account>(account, $"{account.Description} ({account.AccountNumber})");
                cboPaymentAccount.Items.Add(ddi);
            }

            txtPayee.Text = selectedConfiguration.LocationIDPayee != null ? $"{selectedConfiguration.LocationPayee.Company.Name} ({selectedConfiguration.LocationPayee.Name})" : selectedConfiguration.GovernmentPayee?.Name + " (Government)";
            txtAmountPaid.Text = selectedConfiguration.PaidAmount?.ToString("N2") ?? "0.00";
            txtMaxAmount.Text = selectedConfiguration.MaxAmount?.ToString("N2") ?? "0.00";
            rdoOnDueDate.Checked = selectedConfiguration.Schedule == AutomaticInvoicePaymentConfiguration.Schedules.OnDueDate;
            rdoImmediately.Checked = selectedConfiguration.Schedule == AutomaticInvoicePaymentConfiguration.Schedules.Immediately;

            if (selectedConfiguration.AccountID != null)
            {
                DropDownItem<Account> selectedAccount = cboPaymentAccount.Items.OfType<DropDownItem<Account>>().FirstOrDefault(a => a.Object.AccountID == selectedConfiguration.AccountID);
                if (selectedAccount == null)
                {
                    selectedAccount = new DropDownItem<Account>(selectedConfiguration.Account, $"{selectedConfiguration.Account.Description} ({selectedConfiguration.Account.AccountNumber})");
                    cboPaymentAccount.Items.Insert(0, selectedAccount);
                }

                cboPaymentAccount.SelectedItem = selectedAccount;
            }
        }

        private void tsbAddPayees_Click(object sender, EventArgs e)
        {
            frmAutomaticPaymentConfigurationAddPayees addPayees = new frmAutomaticPaymentConfigurationAddPayees()
            {
                Theme = Theme,
                CompanyID = Company.CompanyID,
                LocationID = LocationModel.LocationID
            };

            addPayees.ShowDialog();
        }
    }
}

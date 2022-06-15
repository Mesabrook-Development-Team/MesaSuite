using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GovernmentPortal.Extensions;
using GovernmentPortal.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;

namespace GovernmentPortal.Taxes
{
    public partial class SalesTaxControl : UserControl, IExplorerControl<SalesTax>
    {
        public event EventHandler IsDirtyChanged;
        private long _governmentID;
        public SalesTaxControl()
        {
            InitializeComponent();
        }

        public SalesTaxControl(long governmentID) : this()
        {
            _governmentID = governmentID;
        }

        private bool _isDirty = false;
        public bool IsDirty 
        {
            get => _isDirty;
            set
            {
                _isDirty = value;
                IsDirtyChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public SalesTax Model { get; set; }
        private frmGenericExplorer<SalesTax> _explorer;
        public frmGenericExplorer<SalesTax> Explorer { set => _explorer = value; }


        public async void OnDeleteClicked()
        {
            if (Model == null)
            {
                this.ShowError("You cannot delete an unsaved Sales Tax");
                return;
            }

            if (!this.Confirm("Are you sure you want to delete this Sales Tax?"))
            {
                return;
            }

            loader.BringToFront();
            loader.Visible = true;

            DeleteData delete = new DeleteData(DataAccess.APIs.GovernmentPortal, $"SalesTax/Delete/{Model.SalesTaxID}");
            delete.AddGovHeader(_governmentID);
            await delete.Execute();

            if (delete.RequestSuccessful)
            {
                IsDirty = false;
                _explorer.LoadAllItems(true);
                Dispose();
                return;
            }

            loader.Visible = false;
        }

        public async void OnSaveClicked()
        {
            if (!decimal.TryParse(txtPercent.Text, out decimal percentage))
            {
                this.ShowError("Tax Rate must be a valid number");
                return;
            }

            loader.BringToFront();
            loader.Visible = true;

            SalesTax modelToSave = Model;
            if (modelToSave == null)
            {
                modelToSave = new SalesTax();
                modelToSave.GovernmentID = _governmentID;
            }

            modelToSave.EffectiveDate = dtpEffectiveDate.Value;
            modelToSave.Rate = percentage;
            modelToSave.AccountID = (cboAccount.SelectedItem as DropDownItem<Account>)?.Object.AccountID ?? 0L;

            if (modelToSave.SalesTaxID == default)
            {
                PostData post = new PostData(DataAccess.APIs.GovernmentPortal, "SalesTax/Post", modelToSave);
                post.AddGovHeader(_governmentID);
                modelToSave = await post.Execute<SalesTax>();
                if (post.RequestSuccessful)
                {
                    IsDirty = false;
                    _explorer.LoadAllItems(true, SalesTaxContext.GetDropDownDisplayText(modelToSave.Rate, modelToSave.EffectiveDate));
                    Dispose();
                    return;
                }
            }
            else
            {
                PutData put = new PutData(DataAccess.APIs.GovernmentPortal, "SalesTax/Put", modelToSave);
                put.AddGovHeader(_governmentID);
                modelToSave = await put.Execute<SalesTax>();
                if (put.RequestSuccessful)
                {
                    IsDirty = false;
                    _explorer.LoadAllItems(true, SalesTaxContext.GetDropDownDisplayText(modelToSave.Rate, modelToSave.EffectiveDate));
                    Dispose();
                    return;
                }
            }

            loader.Visible = false;
        }

        private async void SalesTaxControl_Load(object sender, EventArgs e)
        {
            loader.BringToFront();
            loader.Visible = true;

            dtpEffectiveDate.Value = Model?.EffectiveDate ?? DateTime.Today;
            txtPercent.Text = Model?.Rate.ToString();

            GetData getAccounts = new GetData(DataAccess.APIs.GovernmentPortal, "Account/MyAccounts");
            getAccounts.AddGovHeader(_governmentID);
            List<Account> accounts = await getAccounts.GetObject<List<Account>>() ?? new List<Account>();
            cboAccount.Items.AddRange(accounts.Select(acc => new DropDownItem<Account>(acc, $"{acc.Description} ({acc.AccountNumber})")).ToArray());
            cboAccount.SelectedItem = cboAccount.Items.OfType<DropDownItem<Account>>().FirstOrDefault(ddi => ddi.Object.AccountID == Model?.AccountID);

            IsDirty = false;

            loader.Visible = false;
        }

        private void FormValueChanged(object sender, EventArgs e)
        {
            IsDirty = true;
        }
    }
}

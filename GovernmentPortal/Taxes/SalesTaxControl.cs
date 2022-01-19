using System;
using System.Windows.Forms;
using GovernmentPortal.Extensions;
using GovernmentPortal.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;

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

        private void SalesTaxControl_Load(object sender, EventArgs e)
        {
            dtpEffectiveDate.Value = Model?.EffectiveDate ?? DateTime.Today;
            txtPercent.Text = Model?.Rate.ToString();

            IsDirty = false;
        }

        private void FormValueChanged(object sender, EventArgs e)
        {
            IsDirty = true;
        }
    }
}

using System;
using System.Windows.Forms;
using GovernmentPortal.Models;

namespace GovernmentPortal.Taxes
{
    public partial class SalesTaxControl : UserControl, IExplorerControl<SalesTax>
    {
        public event EventHandler IsDirtyChanged;
        public SalesTaxControl()
        {
            InitializeComponent();
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


        public void OnDeleteClicked()
        {
            throw new NotImplementedException();
        }

        public void OnSaveClicked()
        {
            throw new NotImplementedException();
        }

        private void SalesTaxControl_Load(object sender, EventArgs e)
        {
            dtpEffectiveDate.Value = Model?.EffectiveDate ?? DateTime.Today;
            txtPercent.Text = Model?.Rate.ToString();
        }
    }
}

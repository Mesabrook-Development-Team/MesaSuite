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

namespace GovernmentPortal.Invoicing
{
    [ToolboxItem(false)]
    public partial class AutomaticInvoicePaymentConfigurationControl : UserControl, IExplorerControl<AutomaticInvoicePaymentConfiguration>
    {
        public event EventHandler IsDirtyChanged;
        public long? GovernmentID { get; set; }

        public AutomaticInvoicePaymentConfigurationControl()
        {
            InitializeComponent();
        }

        private bool _isDirty;
        public bool IsDirty
        {
            get => _isDirty;
            set
            {
                _isDirty = value;
                IsDirtyChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public AutomaticInvoicePaymentConfiguration Model { get; set; }
        private frmGenericExplorer<AutomaticInvoicePaymentConfiguration> _explorer;
        frmGenericExplorer<AutomaticInvoicePaymentConfiguration> IExplorerControl<AutomaticInvoicePaymentConfiguration>.Explorer { set => _explorer = value; }

        public void OnDeleteClicked()
        {
            throw new NotImplementedException();
        }

        public void OnSaveClicked()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GovernmentPortal.Models;
using MesaSuite.Common.Utility;

namespace GovernmentPortal.Invoicing
{
    internal class AutomaticPaymentsContext : ExplorerContext<AutomaticInvoicePaymentConfiguration>
    {
        private long _governmentID;
        public AutomaticPaymentsContext(long governmentID)
        {
            _governmentID = governmentID;
        }

        internal override Icon ExplorerIcon => Properties.Resources.icn_money; // TODO: Make proper icon file

        internal override IExplorerControl<AutomaticInvoicePaymentConfiguration> GetControlForModel(AutomaticInvoicePaymentConfiguration model)
        {
            return new AutomaticInvoicePaymentConfigurationControl()
            {
                GovernmentID = _governmentID,
                Model = model
            };
        }

        internal override Task<List<DropDownItem<AutomaticInvoicePaymentConfiguration>>> GetInitialListItems()
        {
            
        }
    }
}

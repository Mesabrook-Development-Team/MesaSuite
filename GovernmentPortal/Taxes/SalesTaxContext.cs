using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using GovernmentPortal.Extensions;
using GovernmentPortal.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Utility;

namespace GovernmentPortal.Taxes
{
    internal class SalesTaxContext : ExplorerContext<SalesTax>
    {
        private long _governmentID;
        public SalesTaxContext(long governmentID) : base()
        {
            _governmentID = governmentID;
        }

        internal override Icon ExplorerIcon => Properties.Resources.icn_govt;

        internal override IExplorerControl<SalesTax> GetControlForModel(SalesTax model)
        {
            return new SalesTaxControl()
            {
                Model = model
            };
        }

        internal async override Task<List<DropDownItem<SalesTax>>> GetInitialListItems()
        {
            GetData get = new GetData(DataAccess.APIs.GovernmentPortal, "SalesTax/GetAll");
            get.AddGovHeader(_governmentID);
            List<SalesTax> salesTaxes = await get.GetObject<List<SalesTax>>();

            return salesTaxes.Select(st => new DropDownItem<SalesTax>(st, $"{st.Rate}% effective on {st.EffectiveDate.ToString("MM/dd/yyyy")}")).ToList();
        }
    }
}

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
            return new SalesTaxControl(_governmentID)
            {
                Model = model
            };
        }

        internal async override Task<List<DropDownItem<SalesTax>>> GetInitialListItems()
        {
            GetData get = new GetData(DataAccess.APIs.GovernmentPortal, "SalesTax/GetAll");
            get.AddGovHeader(_governmentID);
            List<SalesTax> salesTaxes = await get.GetObject<List<SalesTax>>();

            List<DropDownItem<SalesTax>> dropDownItems = new List<DropDownItem<SalesTax>>();
            foreach(SalesTax salesTax in salesTaxes.OrderByDescending(st => st.EffectiveDate))
            {
                DropDownItem<SalesTax> ddi = new DropDownItem<SalesTax>(salesTax, GetDropDownDisplayText(salesTax.Rate, salesTax.EffectiveDate));
                if (salesTax.EffectiveDate > DateTime.Today)
                {
                    ddi.BackgroundColor = Color.Green;
                    ddi.FontStyle = FontStyle.Bold;
                }
                dropDownItems.Add(ddi);
            }

            // Find current
            if (dropDownItems.Count > 0) 
            {
                DropDownItem<SalesTax> current = dropDownItems.FirstOrDefault(ddi => ddi.Object.EffectiveDate <= DateTime.Today);
                if (current != null)
                {
                    current.BackgroundColor = Color.Yellow;
                    current.FontStyle = FontStyle.Italic;
                }
            }

            return dropDownItems;
        }

        public static string GetDropDownDisplayText(decimal rate, DateTime effectiveDate)
        {
            return $"{rate}% effective on {effectiveDate.ToString("MM/dd/yyyy")}";
        }
    }
}

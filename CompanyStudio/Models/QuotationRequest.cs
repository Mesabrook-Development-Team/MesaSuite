using CompanyStudio.Extensions;
using CompanyStudio.Purchasing.Quotes;
using MesaSuite.Common.Data;
using MesaSuite.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CompanyStudio.Models
{
    public class QuotationRequest
    {
        public long? QuotationRequestID { get; set; }
        public long? CompanyIDFrom { get; set; }
        public Company CompanyFrom { get; set; }
        public long? CompanyIDTo { get; set; }
        public Company CompanyTo { get; set; }
        public long? GovernmentIDFrom { get; set; }
        public Government GovernmentFrom { get; set; }
        public long? GovernmentIDTo { get; set; }
        public Government GovernmentTo { get; set; }
        public string Notes { get; set; }

        public List<QuotationRequestItem> QuotationRequestItems { get; set; } = new List<QuotationRequestItem>();

        public async Task<long?> IssueQuote(Company company, Location location, ThemeBase theme, frmStudio studio)
        {
            List<frmQuoteBulkPricing.BulkPricingItem> bulkPricingItems = new List<frmQuoteBulkPricing.BulkPricingItem>();
            Dictionary<QuotationRequestItem, frmQuoteBulkPricing.BulkPricingItem> bulkPricingItemByRequestItem = new Dictionary<QuotationRequestItem, frmQuoteBulkPricing.BulkPricingItem>();
            StringBuilder missingItemsMessages = new StringBuilder();
            foreach(QuotationRequestItem quotationRequestItem in QuotationRequestItems)
            {
                GetData get = new GetData(DataAccess.APIs.CompanyStudio, "PriceCheck/GetItem");
                get.QueryString.Add("locationID", location.LocationID.ToString());
                get.QueryString.Add("itemID", quotationRequestItem.ItemID.ToString());
                get.QueryString.Add("quantity", quotationRequestItem.Quantity.ToString());
                LocationItem item = await get.GetObject<LocationItem>();
                if (item == null)
                {
                    get.QueryString["quantity"].Clear();
                    get.QueryString["quantity"].Add("1");
                    item = await get.GetObject<LocationItem>();
                }

                if (item == null)
                {
                    missingItemsMessages.AppendLine($"{quotationRequestItem.Quantity}x of, nor 1x of, {quotationRequestItem.Item.Name} were found in Price Manager.");
                }
                else
                {
                    frmQuoteBulkPricing.BulkPricingItem bulkPricingItem = new frmQuoteBulkPricing.BulkPricingItem()
                    {
                        Image = quotationRequestItem.Item.Image,
                        Name = quotationRequestItem.Item.Name,
                        UnitCost = item.Quantity == 0 ? 0 : item.BasePrice / item.Quantity,
                        BulkQuantity = quotationRequestItem.Quantity
                    };
                    bulkPricingItems.Add(bulkPricingItem);
                    bulkPricingItemByRequestItem.Add(quotationRequestItem, bulkPricingItem);
                }
            }

            if (missingItemsMessages.Length > 0)
            {
                DialogResult result = MessageBox.Show(missingItemsMessages.ToString() + "\r\n\r\nIn order to quote for Items, the item must be added to Price Manager with a Quantity of 1 or the shown Request Quantity.\r\n\r\nDo you want to open Price Manager to add these Items?", "Missing Items", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    Store.frmStoreItems priceManager = new Store.frmStoreItems();
                    studio.DecorateStudioContent(priceManager);
                    priceManager.Company = company;
                    priceManager.LocationModel = location;
                    priceManager.Show(studio.dockPanel, DockState.Document);
                }

                return null;
            }

            if (bulkPricingItems.Any())
            {
                frmQuoteBulkPricing bulkPricing = new frmQuoteBulkPricing()
                {
                    Theme = theme,
                    BulkPricingItems = bulkPricingItems
                };
                DialogResult result = bulkPricing.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    return null;
                }
            }

            Quotation quote = new Quotation()
            {
                CompanyIDFrom = CompanyIDTo,
                CompanyIDTo = CompanyIDFrom,
                GovernmentIDTo = GovernmentIDFrom,
                ExpirationTime = DateTime.Now,
                IsRepeatable = false
            };

            PostData post = new PostData(DataAccess.APIs.CompanyStudio, "Quotation/Post", quote);
            post.AddLocationHeader(company.CompanyID, location.LocationID);
            quote = await post.Execute<Quotation>();
            if (!post.RequestSuccessful)
            {
                return null;
            }

            foreach(QuotationRequestItem quotationRequestItem in QuotationRequestItems)
            {
                frmQuoteBulkPricing.BulkPricingItem bulkPricingItem = bulkPricingItemByRequestItem.GetOrDefault(quotationRequestItem);

                QuotationItem quotationItem = new QuotationItem()
                {
                    QuotationID = quote.QuotationID,
                    ItemID = quotationRequestItem.ItemID,
                    MinimumQuantity = bulkPricingItem?.BulkQuantity ?? 0,
                    UnitCost = bulkPricingItem?.UnitCost ?? 0
                };
                PostData postItem = new PostData(DataAccess.APIs.CompanyStudio, "QuotationItem/Post", quotationItem);
                postItem.AddLocationHeader(company.CompanyID, location.LocationID);
                await postItem.ExecuteNoResult();
            }

            DeleteData delete = new DeleteData(DataAccess.APIs.CompanyStudio, "QuotationRequest/Delete/" + QuotationRequestID);
            delete.AddLocationHeader(company.CompanyID, location.LocationID);
            await delete.Execute();

            return quote.QuotationID;
        }
    }
}

using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using GovernmentPortal.Extensions;
using GovernmentPortal.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Utility;

namespace GovernmentPortal.Accounts
{
    internal class CategoryExplorerContext : ExplorerContext<Category>
    {
        private long _governmentID;
        public CategoryExplorerContext(long governmentID)
        {
            this._governmentID = governmentID;
        }

        internal override Icon ExplorerIcon => Properties.Resources.icn_govt;

        internal override IExplorerControl<Category> GetControlForModel(Category model)
        {
            return new CategoryExplorerControl(_governmentID)
            {
                Model = model
            };
        }

        internal async override Task<List<DropDownItem<Category>>> GetInitialListItems()
        {
            GetData get = new GetData(DataAccess.APIs.GovernmentPortal, "Category/GetAll");
            get.AddGovHeader(_governmentID);
            List<Category> categories = await get.GetObject<List<Category>>();
            if (!get.RequestSuccessful)
            {
                return new List<DropDownItem<Category>>();
            }

            return categories.Select(c => new DropDownItem<Category>(c, c.Name)).ToList();
        }
    }
}

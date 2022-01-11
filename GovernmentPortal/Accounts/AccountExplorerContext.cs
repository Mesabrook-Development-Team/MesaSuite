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
    internal class AccountExplorerContext : ExplorerContext<Account>
    {
        public long _governmentID;

        public AccountExplorerContext(long governmentID) : base()
        {
            _governmentID = governmentID;
        }

        internal override bool DeleteButtonVisible => false;

        internal override Icon ExplorerIcon => Properties.Resources.icn_govt;

        internal override IExplorerControl<Account> GetControlForModel(Account model)
        {
            return new AccountExplorerControl(_governmentID)
            {
                Model = model
            };
        }

        internal async override Task<List<DropDownItem<Account>>> GetInitialListItems()
        {
            GetData get = new GetData(DataAccess.APIs.GovernmentPortal, "Account/GetAll");
            get.AddGovHeader(_governmentID);
            List<Account> accounts = await get.GetObject<List<Account>>();
            if (accounts == null)
            {
                return new List<DropDownItem<Account>>();
            }

            return accounts.Select(a => new DropDownItem<Account>(a, a.Description)).ToList();
        }
    }
}

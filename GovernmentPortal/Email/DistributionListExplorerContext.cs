using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GovernmentPortal.Extensions;
using GovernmentPortal.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Utility;

namespace GovernmentPortal.Email
{
    internal class DistributionListExplorerContext : ExplorerContext<DistributionList>
    {
        private long _governmentID;
        private string _domainName;
        public DistributionListExplorerContext(long governmentID, string domainName) : base()
        {
            _governmentID = governmentID;
            _domainName = domainName;
        }

        internal override IExplorerControl<DistributionList> GetControlForModel(DistributionList model)
        {
            return new DistributionListExplorerControl(_governmentID)
            {
                Model = model
            };
        }
        internal override Icon ExplorerIcon => Properties.Resources.icn_govt;

        internal async override Task<List<DropDownItem<DistributionList>>> GetInitialListItems()
        {
            GetData get = new GetData(DataAccess.APIs.GovernmentPortal, "DistributionList/GetByDomainName");
            get.AddGovHeader(_governmentID);
            get.QueryString.Add("domainName", _domainName);
            List<DistributionList> distributionLists = await get.GetObject<List<DistributionList>>();
            if (!get.RequestSuccessful)
            {
                return new List<DropDownItem<DistributionList>>();
            }

            return distributionLists.Select(dl => new DropDownItem<DistributionList>(dl, dl.DistributionListAddress)).ToList();
        }
    }
}

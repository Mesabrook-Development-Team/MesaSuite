using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GovernmentPortal.Extensions;
using GovernmentPortal.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Utility;

namespace GovernmentPortal.Email
{
    internal class AliasExplorerContext : ExplorerContext<Alias>
    {
        private long _governmentID;
        private int _domainID;
        public AliasExplorerContext(long governmentID) : base()
        {
            _governmentID = governmentID;
        }

        internal override IExplorerControl<Alias> GetControlForModel(Alias model)
        {
            return new AliasExplorerControl(_domainID, _governmentID)
            {
                Model = model
            };
        }

        internal async override Task<List<DropDownItem<Alias>>> GetInitialListItems()
        {
            // Load domain for gov
            GetData get = new GetData(DataAccess.APIs.GovernmentPortal, "Domain/GetForGovernment");
            get.AddGovHeader(_governmentID);
            Domain domain = await get.GetObject<Domain>();
            if (domain == null || string.IsNullOrEmpty(domain.DomainName))
            {
                throw new Exception("A domain name must be assigned to this Government before you can manage emails.");
            }
            _domainID = domain.DomainID;

            // Load aliases
            get = new GetData(DataAccess.APIs.GovernmentPortal, $"Alias/GetForDomain/{domain.DomainID}");
            get.AddGovHeader(_governmentID);
            List<Alias> aliases = await get.GetObject<List<Alias>>();
            if (!get.RequestSuccessful)
            {
                return new List<DropDownItem<Alias>>();
            }

            return aliases.Select(a => new DropDownItem<Alias>(a, a.AliasName)).ToList();
        }
    }
}

using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using GovernmentPortal.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Utility;

namespace GovernmentPortal.Officials
{
    internal class OfficialExplorerContext : ExplorerContext<Official>
    {
        private long _governmentID;
        private bool _govCanMintCurrency;
        private bool _govCanConfigureInterest;
        public OfficialExplorerContext(long governmentID, bool govCanMintCurrency, bool govCanConfigureInterest)
        {
            _governmentID = governmentID;
            _govCanMintCurrency = govCanMintCurrency;
            _govCanConfigureInterest = govCanConfigureInterest;
        }

        internal override Icon ExplorerIcon => Properties.Resources.icn_user;

        internal override IExplorerControl<Official> GetControlForModel(Official model)
        {
            return new OfficialExplorerControl()
            {
                Model = model,
                GovernmentID = _governmentID,
                GovCanMintCurrency = _govCanMintCurrency,
                GovCanConfigureInterest = _govCanConfigureInterest
            };
        }

        internal async override Task<List<DropDownItem<Official>>> GetInitialListItems()
        {
            GetData getData = new GetData(DataAccess.APIs.GovernmentPortal, "Official/GetAllForGovernment");
            getData.Headers.Add("GovernmentID", _governmentID.ToString());
            return (await getData.GetObject<List<Official>>()).Select(o => new DropDownItem<Official>(o, o.OfficialName)).ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GovernmentPortal.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Utility;

namespace GovernmentPortal.Officials
{
    internal class OfficialExplorerContext : ExplorerContext<Official>
    {
        private long _governmentID;
        private bool _govCanMintCurrency;
        public OfficialExplorerContext(long governmentID, bool govCanMintCurrency)
        {
            _governmentID = governmentID;
            _govCanMintCurrency = govCanMintCurrency;
        }

        internal override Icon ExplorerIcon => Properties.Resources.icn_govt;

        internal override IExplorerControl<Official> GetControlForModel(Official model)
        {
            return new OfficialExplorerControl()
            {
                Model = model,
                GovernmentID = _governmentID,
                GovCanMintCurrency = _govCanMintCurrency
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

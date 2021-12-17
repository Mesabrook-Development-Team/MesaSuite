using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GovernmentPortal.Models;
using MesaSuite.Common.Data;
using MesaSuite.Common.Utility;

namespace GovernmentPortal.Officials
{
    internal class OfficialExplorerContext : ExplorerContext<Official>
    {
        private long _governmentID;
        public OfficialExplorerContext(long governmentID)
        {
            _governmentID = governmentID;
        }
        internal override IExplorerControl<Official> GetControlForModel(Official model)
        {
            return new OfficialExplorerControl()
            {
                Model = model,
                GovernmentID = _governmentID
            };
        }

        internal async override Task<List<DropDownItem<Official>>> GetInitialListItems()
        {
            GetData getData = new GetData(DataAccess.APIs.GovernmentPortal, "Official/GetForGovernment");
            getData.Headers.Add("GovernmentID", _governmentID.ToString());
            return (await getData.GetObject<List<Official>>()).Select(o => new DropDownItem<Official>(o, o.OfficialName)).ToList();
        }
    }
}

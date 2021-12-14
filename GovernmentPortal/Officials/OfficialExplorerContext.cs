using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GovernmentPortal.Models;
using MesaSuite.Common.Utility;

namespace GovernmentPortal.Officials
{
    internal class OfficialExplorerContext : ExplorerContext<Official>
    {
        internal override IExplorerControl<Official> GetControlForModel(Official model)
        {
            throw new NotImplementedException();
        }

        internal async override Task<List<DropDownItem<Official>>> GetInitialListItems()
        {
            throw new NotImplementedException();
        }

        internal override void OnNewClicked()
        {
            throw new NotImplementedException();
        }
    }
}

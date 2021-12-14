using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MesaSuite.Common.Utility;

namespace GovernmentPortal
{
    internal abstract class ExplorerContext<TModel>
    {
        internal abstract IExplorerControl<TModel> GetControlForModel(TModel model);
        internal abstract Task<List<DropDownItem<TModel>>> GetInitialListItems();
        internal virtual string ObjectDisplayName => typeof(TModel).Name;
        internal abstract void OnNewClicked();
    }
}

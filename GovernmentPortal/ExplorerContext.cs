using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using MesaSuite.Common.Extensions;
using MesaSuite.Common.Utility;

namespace GovernmentPortal
{
    internal abstract class ExplorerContext<TModel> where TModel:class
    {
        internal abstract Icon ExplorerIcon { get; }
        internal abstract IExplorerControl<TModel> GetControlForModel(TModel model);
        internal abstract Task<List<DropDownItem<TModel>>> GetInitialListItems();
        internal virtual string ObjectDisplayName => typeof(TModel).Name.ToDisplayName();
    }
}

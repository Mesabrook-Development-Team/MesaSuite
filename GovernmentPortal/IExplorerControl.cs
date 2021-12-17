using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovernmentPortal
{
    internal interface IExplorerControl<TModel> where TModel:class
    {
        event EventHandler IsDirtyChanged;
        bool IsDirty { get; set; }
        TModel Model { get; set; }
        void OnDeleteClicked();
        void OnSaveClicked();
        frmGenericExplorer<TModel> Explorer { set; }
    }
}

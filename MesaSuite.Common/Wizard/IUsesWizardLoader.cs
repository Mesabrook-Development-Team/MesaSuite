using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesaSuite.Common.Wizard
{
    internal interface IUsesWizardLoader
    {
        Action ShowLoader { set; }
        Action HideLoader { set; }
    }
}

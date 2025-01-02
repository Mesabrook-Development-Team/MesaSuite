using CompanyStudio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyStudio.Invoicing
{
    public partial class frmAutomaticPaymentConfiguration : BaseCompanyStudioContent, ILocationScoped
    {
        public frmAutomaticPaymentConfiguration()
        {
            InitializeComponent();
        }

        public Location LocationModel { get; set; }


    }
}

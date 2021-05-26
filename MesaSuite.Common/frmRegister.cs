using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MesaSuite.Common
{
    public partial class frmRegister : Form
    {
        public Guid ClientID { get; set; }
        public frmRegister()
        {
            InitializeComponent();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            foreach(int port in Authentication.PORTS)
            {
                if (builder.Length > 0)
                {
                    builder.Append(";");
                }

                builder.Append($"http://localhost:{port}");
            }

            browser.Load($"{ConfigurationManager.AppSettings.Get("MesaSuite.Common.AuthHost")}/Register?clientIdentifier=" + ClientID.ToString() + "&redirectionUri=" + WebUtility.UrlEncode(builder.ToString()));
        }
    }
}

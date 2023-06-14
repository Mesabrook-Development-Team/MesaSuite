using System;
using System.Configuration;
using System.Net;
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
            browser.Load($"{ConfigurationManager.AppSettings.Get("MesaSuite.Common.AuthHost")}/Register?clientName=" + WebUtility.UrlEncode("MesaSuite Desktop App (" + Environment.MachineName + ")") + "&redirectionUri=" + WebUtility.UrlEncode("http://localhost:" + Authentication.PORT) + "&postToRedirectUri=true");
        }
    }
}

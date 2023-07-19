using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Updater.UpdateWorkflow;

namespace Updater.Steps
{
    public partial class TermsOfServiceStepControl : UserControl, IStepUserControl
    {
        public TermsOfServiceStepControl()
        {
            InitializeComponent();
        }

        public Step Step { get; set; }

        private void TermsOfServiceStepControl_Load(object sender, EventArgs e)
        {
            LoadTermsOfService();
        }

        private async void LoadTermsOfService()
        {
            HttpWebRequest webRequest = WebRequest.CreateHttp("http://localhost:58480/system/TermsOfService/Get/MesaSuite");
            webRequest.Method = WebRequestMethods.Http.Get;
            
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)await webRequest.GetResponseAsync())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    richTextBox1.Text = reader.ReadToEnd()
                                            .Replace("\\n", "\n")
                                            .Replace("\\r", "")
                                            .Replace("\\\"", "\"");

                    if (richTextBox1.Text.StartsWith("\""))
                    {
                        richTextBox1.Text = richTextBox1.Text.Substring(1);
                    }

                    if (richTextBox1.Text.EndsWith("\""))
                    {
                        richTextBox1.Text = richTextBox1.Text.Substring(0, richTextBox1.Text.Length - 1);
                    }
                }
            }
            catch (Exception ex)
            {
                richTextBox1.Text = "An error occurred retrieving MesaSuite Terms Of Service: " + ex.Message + "\r\n\r\nPlease visit https://www.mesabrook.com/tos.html to review the Terms Of Service for MesaSuite.";
            }
        }

        private void chkBoxAccept_CheckedChanged(object sender, EventArgs e)
        {
            Step.InstallationConfiguration.AcceptedToS = chkBoxAccept.Checked;
        }
    }
}

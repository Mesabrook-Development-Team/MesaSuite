using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using ClussPro.ObjectBasedFramework.DataSearch;
using WebModels.mesasys;

namespace MesaService.ServiceTasks
{
    internal class SendOutboundEmails : IServiceTask
    {
        public string Name => "Send Outbound Emails";

        private DateTime _nextRunTime = DateTime.Now;
        public DateTime NextRunTime => _nextRunTime;

        public bool Run()
        {
            string server = ConfigurationManager.AppSettings.GetValues("SMTPServer")?.FirstOrDefault();
            string strPort = ConfigurationManager.AppSettings.GetValues("SMTPPort")?.FirstOrDefault();

            if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(strPort) || !int.TryParse(strPort, out int port))
            {
                _nextRunTime = DateTime.Now.AddSeconds(10);
                return false;
            }

            string smtpUser = ConfigurationManager.AppSettings.GetValues("SMTPUser")?.FirstOrDefault();
            string smtpPassword = ConfigurationManager.AppSettings.GetValues("SMTPPassword")?.FirstOrDefault();

            try
            {
                SmtpClient smtpClient = new SmtpClient(server, port);
                    
                if (!string.IsNullOrEmpty(smtpUser) && !string.IsNullOrEmpty(smtpPassword))
                {
                    smtpClient.Credentials = new NetworkCredential(smtpUser, smtpPassword);
                }

                Search<OutboundEmail> outboundEmailSearch = new Search<OutboundEmail>();
                foreach (OutboundEmail email in outboundEmailSearch.GetEditableReader())
                {
                    MailMessage mailMessage = new MailMessage();
                    MailAddress fromAddress = new MailAddress(email.FromEmail, email.FromName);
                    mailMessage.From = fromAddress;
                    mailMessage.To.Add(email.To);
                    mailMessage.Subject = email.Subject;
                    mailMessage.Body = email.Body;
                    smtpClient.Send(mailMessage);

                    email.Delete();
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                _nextRunTime = DateTime.Now.AddSeconds(10);
            }

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Loader;
using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Utility;
using WebModels.account;
using WebModels.mesasys;

namespace WebModels.Loaders.mesasys
{
    public class EmailTemplateLoader : ILoader
    {
        public IEnumerable<LoaderObject> GetLoaderObjects()
        {
            yield return new EmailTemplateLoaderObject<WireTransferHistory>(EmailTemplate.EmailTemplates.WireTransferReceived,
                                                                            "Wire Transfer Received",
                                                                            "A Wire Transfer has been sent to you from {GovernmentFrom.Name}{CompanyFrom.Name} at {TransferTime}. The amount of MBD${Amount} has been deposited into your account of {AccountToHistorical}.\r\n\r\nMemo:\r\n{Memo}",
                                                                            wth => new List<object>()
                                                                            {
                                                                                wth.GovernmentFrom.Name,
                                                                                wth.CompanyFrom.Name,
                                                                                wth.GovernmentTo.Name,
                                                                                wth.CompanyTo.Name,
                                                                                wth.TransferTime,
                                                                                wth.AccountFromMasked,
                                                                                wth.AccountToHistorical,
                                                                                wth.AccountToMasked,
                                                                                wth.Amount,
                                                                                wth.Memo
                                                                            });

            yield return new EmailTemplateLoaderObject<invoicing.Invoice>(EmailTemplate.EmailTemplates.AccountsPayableInvoiceReceived,
                                                                          "Payable Invoice Received",
                                                                          "Invoice Number {InvoiceNumber} has been issued to you by {GovernmentFrom.Name}{LocationFrom.Company.Name} for the amount of MBD${Amount}.\r\n\r\n" +
                                                                            "Invoice Date: {InvoiceDate}\r\n" +
                                                                            "Description: {Description}\r\n" +
                                                                            "Due Date: {DueDate}",
                                                                          invoice => new List<object>()
                                                                          {
                                                                              invoice.GovernmentFrom.Name,
                                                                              invoice.LocationFrom.Name,
                                                                              invoice.LocationFrom.Company.Name,
                                                                              invoice.GovernmentTo.Name,
                                                                              invoice.LocationTo.Name,
                                                                              invoice.LocationTo.Company.Name,
                                                                              invoice.InvoiceNumber,
                                                                              invoice.Description,
                                                                              invoice.InvoiceDate,
                                                                              invoice.DueDate,
                                                                              invoice.Status,
                                                                              invoice.Amount
                                                                          });

            yield return new EmailTemplateLoaderObject<invoicing.Invoice>(EmailTemplate.EmailTemplates.AccountsReceivableInvoiceReadyForReceipt,
                                                                          "Receivable Invoice Ready For Receipt",
                                                                          "Your Invoice {InvoiceNumber} to {GovernmentTo.Name}{LocationTo.Company.Name} has been authorized for payment and is ready for receipt.",
                                                                          invoice => new List<object>()
                                                                          {
                                                                              invoice.GovernmentFrom.Name,
                                                                              invoice.LocationFrom.Name,
                                                                              invoice.LocationFrom.Company.Name,
                                                                              invoice.GovernmentTo.Name,
                                                                              invoice.LocationTo.Name,
                                                                              invoice.LocationTo.Company.Name,
                                                                              invoice.InvoiceNumber,
                                                                              invoice.Description,
                                                                              invoice.InvoiceDate,
                                                                              invoice.DueDate,
                                                                              invoice.Status,
                                                                              invoice.AccountTo.AccountNumber,
                                                                              invoice.AccountTo.Description,
                                                                              invoice.Amount
                                                                          });
        }

        private class EmailTemplateLoaderObject<TTemplateObject> : LoaderObject where TTemplateObject : DataObject
        {
            public EmailTemplateLoaderObject(Guid systemID, string name, string template, Expression<Func<TTemplateObject, List<object>>> allowedFields) : base(typeof(EmailTemplate))
            {
                SystemID = systemID;
                Values = new Dictionary<string, object>()
                {
                    { nameof(EmailTemplate.TemplateSchema), Schema.GetSchemaObject<TTemplateObject>().SchemaName },
                    { nameof(EmailTemplate.TemplateObject), Schema.GetSchemaObject<TTemplateObject>().ObjectName },
                    { nameof(EmailTemplate.Name), name },
                    { nameof(EmailTemplate.Template), template },
                    { nameof(EmailTemplate.AllowedFields), FieldPathUtility.CreateFieldPaths(allowedFields) }
                };
            }
        }

        
    }
}

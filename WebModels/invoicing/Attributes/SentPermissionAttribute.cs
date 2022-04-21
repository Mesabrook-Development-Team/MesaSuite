using System;

namespace WebModels.invoicing.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class SentPermissionAttribute : Attribute
    {
        public SenderTypes UpdaterOption { get; set; }

        public SentPermissionAttribute(SenderTypes updaterOptions)
        {
            UpdaterOption = updaterOptions;
        }

        public enum SenderTypes
        {
            Sender,
            Recipient,
            Payee,
            Payor
        }
    }
}

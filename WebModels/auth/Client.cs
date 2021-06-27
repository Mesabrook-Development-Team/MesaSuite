using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebModels.auth
{
    [Table("58DB9C4D-6F68-4A00-A675-E48D86EB97DA")]
    [Unique(new string[] { "ClientIdentifier" })]
    public class Client : DataObject
    {
        protected Client() : base() { }

        private long? _clientID;
        [Field("A8124915-DD2A-4180-8F2E-59CC210A5250")]
        public long? ClientID
        {
            get { CheckGet(); return _clientID; }
        }

        private Guid? _clientIdentifier;
        [Field("DF81C32E-1B7F-44DE-86E4-8EEA963E46E3")]
        [Required]
        public Guid? ClientIdentifier
        {
            get { CheckGet(); return _clientIdentifier; }
            set { CheckSet(); _clientIdentifier = value; }
        }

        private string _redirectionURI;
        [Field("D5853DEC-73E4-402C-8DEA-5702D5A21405", DataSize = 500)]
        [Required]
        public string RedirectionURI
        {
            get { CheckGet(); return _redirectionURI; }
            set { CheckSet(); _redirectionURI = value; }
        }

        #region Relationships
        private List<Token> _tokens = new List<Token>();
        [RelationshipList("F9111B34-F4D4-497E-ACCE-A3870EAF7B42", "ClientID")]
        public IReadOnlyCollection<Token> Tokens
        {
            get { CheckGet(); return _tokens; }
        }
        #endregion

        public bool ContainsRedirectURI(string redirectURI)
        {
            string[] redirectionUris = RedirectionURI.Split(';');

            return redirectionUris.Contains(redirectURI);
        }
    }
}
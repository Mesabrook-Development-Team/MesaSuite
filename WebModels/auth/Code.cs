using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;

namespace WebModels.auth
{
    [Table("68775828-DB64-43F6-A661-A8F0C4F5C5AF")]
    public class Code : DataObject
    {
        protected Code() : base() { }

        private long? _codeID = null;
        [Field("A551FFE6-6D50-478C-A473-DA75DC5662F8")]
        public long? CodeID
        {
            get { CheckGet(); return _codeID; }
            set { CheckSet(); _codeID = value; }
        }

        private Guid? _authCode;
        [Field("3759F817-B031-4DB9-A415-A15DF5F4F143")]
        [Required]
        public Guid? AuthCode
        {
            get { CheckGet(); return _authCode; }
            set { CheckSet(); _authCode = value; }
        }

        private Guid? _clientIdentifier;
        [Field("81A62AAA-375E-4825-9448-1AA988626A25")]
        [Required]
        public Guid? ClientIdentifier
        {
            get { CheckGet(); return _clientIdentifier; }
            set { CheckSet(); _clientIdentifier = value; }
        }

        private string _redirectURI;
        [Field("2621BE10-E949-4C14-BF6E-084D739731A3")]
        public string RedirectURI
        {
            get { CheckGet(); return _redirectURI; }
            set { CheckSet(); _redirectURI = value; }
        }

        private DateTime? _expiration;
        [Field("39DE2302-F726-4999-BA05-5615B8B28F5E", DataSize = 7)]
        [Required]
        public DateTime? Expiration
        {
            get { CheckGet(); return _expiration; }
            set { CheckSet(); _expiration = value; }
        }

        private long? _userID;
        [Field("FDFAE4E1-7F50-49CC-8D10-0604320917F3")]
        [Required]
        public long? UserID
        {
            get { CheckGet(); return _userID; }
            set { CheckSet(); _userID = value; }
        }

        private DeviceCode _deviceCode = null;
        [Relationship("1D2C635C-F31D-4AFA-AC51-43B74A45B7B7", OneToOneByForeignKey = true)]
        public DeviceCode DeviceCode
        {
            get { CheckGet(); return _deviceCode; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;

namespace WebModels.auth
{
    [Table("D46B82F6-D51A-4F91-BD09-B45D8670861D")]
    public class DeviceCode : DataObject
    {
        protected DeviceCode() : base() { }

        private long? _deviceCodeID;
        [Field("61039CA3-2C81-46E3-9CE3-E6B9D07C0C96")]
        public long? DeviceCodeID
        {
            get { CheckGet(); return _deviceCodeID; }
            set { CheckSet(); _deviceCodeID = value; }
        }

        private long? _clientID;
        [Field("B2C66D32-91FC-4877-8DB2-140C2176DCEA")]
        public long? ClientID
        {
            get { CheckGet(); return _clientID; }
            set { CheckSet(); _clientID = value; }
        }

        private Client _client = null;
        [Relationship("3AE76E49-C6E5-490C-B3C5-2AC4F3C131F5")]
        public Client Client
        {
            get { CheckGet(); return _client; }
        }

        //private string _deviceCode;
        //[Field("71328A4C-FE63-4606-892B-BCA3118905FA", DataSize = 16)]
        //public string DeviceCode
        //{
        //    get { CheckGet(); return _deviceCode; }
        //    set { CheckSet(); _deviceCode = value; }
        //}


    }
}

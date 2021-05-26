using API_User.Models.security;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using System;

namespace API_User.Models.auth
{
    [Table("A5BC5DE8-7209-4C50-8224-88AF13CAD1EA")]
    public class Token : DataObject
    {
        private long? _tokenID;
        [Field("467E062F-15C6-435A-A76B-88742CE1D552")]
        public long? TokenID
        {
            get { CheckGet(); return _tokenID; }
        }

        private long? _userID;
        [Field("ADCE2075-04C8-4B95-83A6-317F06F159E1")]
        public long? UserID
        {
            get { CheckGet(); return _userID; }
        }

        private User _user;
        [Relationship("12EB66CA-1B78-4EF5-9F72-45B4998D08E9")]
        public User User
        {
            get { CheckGet(); return _user; }
        }

        protected override bool PreSave(ITransaction transaction)
        {
            throw new InvalidOperationException("This object is intended for use as auto-delete only.  Saving is not permitted.");
        }
    }
}
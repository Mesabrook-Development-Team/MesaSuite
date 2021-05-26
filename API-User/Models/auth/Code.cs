using API_User.Models.security;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using System;

namespace API_User.Models.auth
{
    [Table("3909B7CA-E50C-49D7-944E-1D92503C4A19")]
    public class Code : DataObject
    {
        private long? _codeID;
        [Field("AD185080-7336-496E-868E-10BD57F98E26")]
        public long? CodeID
        {
            get { CheckGet(); return _codeID; }
        }

        private long? _userID;
        [Field("2C057C80-3BB8-4107-BF4F-50A776B030E1")]
        public long? UserID
        {
            get { CheckGet(); return _userID; }
        }

        private User _user;
        [Relationship("535CF132-3129-4AA6-8730-917B8480C16B")]
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
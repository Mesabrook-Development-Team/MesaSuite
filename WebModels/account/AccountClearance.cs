using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using WebModels.security;

namespace WebModels.account
{
    [Table("E6E44464-A764-4129-BD98-1748E3FFF53B")]
    public class AccountClearance : DataObject
    {
        protected AccountClearance() : base() { }

        private long? _accountClearanceID;
        [Field("BEB40228-CDD1-40C7-8376-9C2BC8ACD376")]
        public long? AccountClearanceID
        {
            get { CheckGet(); return _accountClearanceID; }
            set { CheckSet(); _accountClearanceID = value; }
        }

        private long? _accountID;
        [Field("6CB8A21E-225B-4753-A715-ACD5E87536E1")]
        [Required]
        public long? AccountID
        {
            get { CheckGet(); return _accountID; }
            set { CheckSet(); _accountID = value; }
        }

        private Account _account;
        [Relationship("C5F8B8F1-C9BD-4444-A402-9CC3C9DBC9A5")]
        public Account Account
        {
            get { CheckGet(); return _account; }
        }

        private long? _userID;
        [Field("7C4D4F64-7FF7-45FB-8D12-3B21132A162A")]
        [Required]
        public long? UserID
        {
            get { CheckGet(); return _userID; }
            set { CheckSet(); _userID = value; }
        }

        private User _user;
        [Relationship("5FE881CF-E846-41B0-9033-5F800CDFC2B6")]
        public User User
        {
            get { CheckGet(); return _user; }
        }
    }
}

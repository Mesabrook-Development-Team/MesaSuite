using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System.Collections.Generic;
using WebModels.auth;

namespace WebModels.security
{
    [Table("554BDF2E-ACA5-46AB-A56E-080E6823267F")]
    public class User : DataObject
    {
        protected User() : base() { }

        private long? _userID;
        [Field("7BD9DFA8-8EC1-4159-AEDF-5A9330AEF3EB")]
        public long? UserID
        {
            get { CheckGet(); return _userID; }
            set { CheckSet(); _userID = value; }
        }

        private string _username;
        [Field("DF59672D-B5FB-43F7-8B42-BFC44097B54E", DataSize = 50)]
        [Required]
        public string Username
        {
            get { CheckGet(); return _username; }
            set { CheckSet(); _username = value; }
        }

        #region Relationships
        #region auth
        private List<Token> _tokens = new List<Token>();
        [RelationshipList("F2685C25-DB7A-4D37-8AB8-9B0C17454B12", "UserID", AutoDeleteReferences = true)]
        public IReadOnlyCollection<Token> Tokens
        {
            get { CheckGet(); return _tokens; }
        }
        #endregion
        #region security
        private List<UserProgram> _userPrograms = new List<UserProgram>();
        [RelationshipList("1714F3DF-C649-4A9D-B7C2-7ED01F676173", "UserID", AutoDeleteReferences = true)]
        public IReadOnlyCollection<UserProgram> UserPrograms
        {
            get { CheckGet(); return _userPrograms; }
        }
        #endregion
        #endregion
    }
}
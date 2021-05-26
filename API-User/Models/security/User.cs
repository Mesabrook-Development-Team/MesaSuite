using API_User.Models.auth;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;

namespace API_User.Models.security
{
    [Table("554BDF2E-ACA5-46AB-A56E-080E6823267F")]
    public class User : DataObject
    {
        private long? _userID;
        [Field("7BD9DFA8-8EC1-4159-AEDF-5A9330AEF3EB")]
        public long? UserID
        {
            get { CheckGet(); return _userID; }
            set { CheckSet(); _userID = value; }
        }

        private string _username;
        [Field("DF59672D-B5FB-43F7-8B42-BFC44097B54E", DataSize = 50)]
        public string Username
        {
            get { CheckGet(); return _username; }
            set { CheckSet(); _username = value; }
        }

        // Non-DO properties
        public string Email { get; set; }

        private string _originalFirstName = null;
        private string _firstName = null;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_originalFirstName == null)
                {
                    _originalFirstName = value;
                }

                _firstName = value;
            }
        }

        private string _originalLastName = null;
        private string _lastName = null;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_originalLastName == null)
                {
                    _originalLastName = value;
                }

                _lastName = value;
            }
        }

        public string Password { get; set; }
        public List<string> MemberOf { get; set; }

        private SearchResult GetActiveDirectorySearchResult(string username)
        {
            string ldapAddress = ConfigurationManager.AppSettings.Get("LDAPAddress");
            string ldapContainer = ConfigurationManager.AppSettings.Get("LDAPContainer");
            string ldapGroupName = ConfigurationManager.AppSettings.Get("LDAPGroupName");

            DirectoryEntry directoryEntry = new DirectoryEntry($"LDAP://{ldapAddress}");
            DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry);
            directorySearcher.Filter = $"(&(samaccountname={SanitizeLDAPUsername(username)})(memberof=cn={ldapGroupName},{ldapContainer}))";
            directorySearcher.PropertiesToLoad.Add("samaccountname");
            directorySearcher.PropertiesToLoad.Add("userprincipalname");

            SearchResult result = directorySearcher.FindOne();
            return result;
        }

        private string SanitizeLDAPUsername(string text)
        {
            text = text.Trim();
            char[] specialChars = new char[] { '\\', '#', '+', '<', '>', ',', ';', '"', '=' };
            Dictionary<char, string> replacements = new Dictionary<char, string>();

            foreach (char specialChar in specialChars)
            {
                replacements.Add(specialChar, Convert.ToByte(specialChar).ToString("x"));
            }

            string result = "";
            foreach (char character in text)
            {
                if (specialChars.Contains(character))
                {
                    result += replacements[character];
                }
                else
                {
                    result += character;
                }
            }

            return result;
        }

        public static List<string> GetAllActiveDirectoryUsers()
        {
            List<string> results = new List<string>();
            HashSet<string> existingUsers = new Search<User>().GetReadOnlyReader(null, new string[] { "Username" }).Select(u => u.Username).ToHashSet();

            string ldapAddress = ConfigurationManager.AppSettings.Get("LDAPAddress");
            string ldapContainer = ConfigurationManager.AppSettings.Get("LDAPContainer");
            string ldapGroupName = ConfigurationManager.AppSettings.Get("LDAPGroupName");

            DirectoryEntry entry = new DirectoryEntry($"LDAP://{ldapAddress}");
            DirectorySearcher searcher = new DirectorySearcher(entry);
            searcher.Filter = $"(memberof=cn={ldapGroupName},{ldapContainer})";
            searcher.PropertiesToLoad.Add("samaccountname");

            foreach(SearchResult result in searcher.FindAll())
            {
                string username = result.GetDirectoryEntry().Properties["samaccountname"].Value as string;
                if (!existingUsers.Contains(username))
                {
                    results.Add(username);
                }
            }

            return results;
        }

        public static List<string> GetAllActiveDirectoryGroups()
        {
            List<string> groups = new List<string>();
            string ldapAddress = ConfigurationManager.AppSettings.Get("LDAPAddress");
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, ldapAddress))
            using (GroupPrincipal queryFilter = new GroupPrincipal(context))
            using (PrincipalSearcher searcher = new PrincipalSearcher(queryFilter))
            {
                foreach(GroupPrincipal group in searcher.FindAll().OfType<GroupPrincipal>())
                {
                    groups.Add(group.SamAccountName);
                }
            }

            return groups;
        }

        public User PopulateActiveDirectoryInformation()
        {
            string ldapAddress = ConfigurationManager.AppSettings.Get("LDAPAddress");

            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, ldapAddress))
            using (UserPrincipal queryFilter = new UserPrincipal(context) { SamAccountName = Username })
            using (PrincipalSearcher searcher = new PrincipalSearcher(queryFilter))
            {
                UserPrincipal userPrincipal = (UserPrincipal)searcher.FindOne();
                if (userPrincipal == null)
                {
                    return this;
                }

                FirstName = userPrincipal.GivenName;
                LastName = userPrincipal.Surname;
                Email = userPrincipal.EmailAddress;
            }

            DirectoryEntry directoryEntry = new DirectoryEntry($"LDAP://{ldapAddress}");
            DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry);
            directorySearcher.Filter = $"(samaccountname={SanitizeLDAPUsername(Username)})";
            directorySearcher.PropertiesToLoad.Add("memberOf");

            SearchResult result = directorySearcher.FindOne();
            DirectoryEntry user = result.GetDirectoryEntry();

            MemberOf = new List<string>();
            if (user.Properties["memberOf"].Value is string)
            {
                string workingString = ((string)user.Properties["memberOf"].Value).Replace("CN=", "").Replace("DC=", "");
                workingString = workingString.Substring(0, workingString.IndexOf(","));
                MemberOf.Add(workingString);
            }
            else if (user.Properties["memberOf"].Value != null)
            {
                foreach (string securityGroup in (object[])user.Properties["memberOf"].Value)
                {
                    string workingString = securityGroup.Replace("CN=", "").Replace("DC=", "");
                    workingString = workingString.Substring(0, workingString.IndexOf(","));
                    MemberOf.Add(workingString);
                }
            }

            return this;
        }

        public void UpdateActiveDirectoryInformation()
        {
            string ldapAddress = ConfigurationManager.AppSettings.Get("LDAPAddress");
            string ldapContainer = ConfigurationManager.AppSettings.Get("LDAPContainer");

            DirectoryEntry directoryEntry = new DirectoryEntry($"LDAP://{ldapAddress}/{ldapContainer}");
            DirectoryEntry userEntry = directoryEntry.Children.Find($"CN={_originalFirstName} {_originalLastName}");
            userEntry.Properties["samaccountname"].Value = SanitizeLDAPUsername(Username);
            userEntry.Properties["givenname"].Value = FirstName;
            userEntry.Properties["sn"].Value = LastName;
            userEntry.Properties["mail"].Value = Email;
            int userAccountControl = (int)userEntry.Properties["useraccountcontrol"].Value;
            userEntry.Properties["useraccountcontrol"].Value = (userAccountControl & ~0x2);
            userEntry.CommitChanges();

            if (_originalFirstName != FirstName || _originalLastName != LastName)
            {
                userEntry.MoveTo(directoryEntry, $"CN={FirstName} {LastName}");
                userEntry.CommitChanges();
            }

            DirectorySearcher searcher = new DirectorySearcher(directoryEntry, "(objectclass=group)");
            searcher.PropertiesToLoad.Add("member");

            string fqName = $"CN={FirstName} {LastName},{ldapContainer}";
            foreach (SearchResult result in searcher.FindAll())
            {
                DirectoryEntry group = result.GetDirectoryEntry();
                if (group == null)
                {
                    continue;
                }

                if (MemberOf.Contains(group.Properties["name"].Value) && !group.Properties["member"].Contains(fqName))
                {
                    group.Properties["member"].Add(fqName);
                    group.CommitChanges();
                }
                else if (group.Properties["member"].Contains(fqName) && !MemberOf.Contains(group.Properties["name"].Value))
                {
                    group.Properties["member"].Remove(fqName);
                    group.CommitChanges();
                }
            }
        }

        public void CreateActiveDirectoryUser()
        {
            string ldapAddress = ConfigurationManager.AppSettings.Get("LDAPAddress");
            string ldapContainer = ConfigurationManager.AppSettings.Get("LDAPContainer");

            DirectoryEntry directoryEntry = new DirectoryEntry($"LDAP://{ldapAddress}/{ldapContainer}");
            DirectoryEntry newUser = directoryEntry.Children.Add($"CN={FirstName} {LastName}", "user");
            directoryEntry.CommitChanges();
            newUser.Properties["samaccountname"].Value = SanitizeLDAPUsername(Username);
            newUser.Properties["givenname"].Value = FirstName;
            newUser.Properties["sn"].Value = LastName;
            newUser.Properties["mail"].Value = Email;
            newUser.Properties["useraccountcontrol"].Value = 544;
            newUser.CommitChanges();
            newUser.Invoke("SetPassword", new object[] { Password });
            newUser.CommitChanges();

            DirectorySearcher searcher = new DirectorySearcher(directoryEntry);
            searcher.PropertiesToLoad.Add("member");

            if (MemberOf != null)
            {
                foreach (string group in MemberOf)
                {
                    searcher.Filter = $"(&(samaccountname={group})(objectclass=group))";
                    SearchResult result = searcher.FindOne();
                    if (result == null)
                    {
                        continue;
                    }

                    DirectoryEntry entry = result.GetDirectoryEntry();
                    entry.Properties["member"].Add($"CN={FirstName} {LastName},{ldapContainer}");
                    entry.CommitChanges();
                }
            }
        }

        public void DisableActiveDirectoryUser()
        {
            string ldapAddress = ConfigurationManager.AppSettings.Get("LDAPAddress");
            string ldapContainer = ConfigurationManager.AppSettings.Get("LDAPContainer");

            DirectoryEntry directoryEntry = new DirectoryEntry($"LDAP://{ldapAddress}/{ldapContainer}");
            DirectoryEntry userEntry = directoryEntry.Children.Find($"CN={_originalFirstName} {_originalLastName}");
            int userAccountControl = (int)userEntry.Properties["useraccountcontrol"].Value;
            userEntry.Properties["useraccountcontrol"].Value = userAccountControl | 0x2;
            userEntry.CommitChanges();
        }

        #region Relationships
        private List<UserPermission> _userPermissions = new List<UserPermission>();
        [RelationshipList("C0BE989D-0E9D-4C05-8316-576F890CF11B", "UserID", AutoDeleteReferences = true)]
        [JsonIgnore]
        public IReadOnlyCollection<UserPermission> UserPermissions
        {
            get { CheckGet(); return _userPermissions; }
        }

        private List<Code> _codes = new List<Code>();
        [RelationshipList("829911E1-6382-46C5-A5E2-96861C4121A1", "UserID", AutoDeleteReferences = true)]
        [JsonIgnore]
        public IReadOnlyCollection<Code> Codes
        {
            get { CheckGet(); return _codes; }
        }

        private List<Token> _tokens = new List<Token>();
        [RelationshipList("708AF32D-77B2-4A4C-9038-32AAC2C4B9D8", "UserID", AutoDeleteReferences = true)]
        [JsonIgnore]
        public IReadOnlyCollection<Token> Tokens
        {
            get { CheckGet(); return _tokens; }
        }
        #endregion
    }
}
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using WebModels.security;

namespace API_System.Models.security
{
    public class LDAPUser : User
    {
        protected LDAPUser() : base() { }
        // Non-DO properties
        public string Email { get; set; }

        private string _originalFirstName = "_not set_;
        private string _firstName = null;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_originalFirstName == "_not set_")
                {
                    _originalFirstName = value;
                }

                _firstName = value;
            }
        }

        private string _originalLastName = "_not set_";
        private string _lastName = null;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_originalLastName == "_not set_")
                {
                    _originalLastName = value;
                }

                _lastName = value;
            }
        }

        private string OriginalFirstName
        {
            get
            {
                if (_originalFirstName == "_not set_")
                {
                    return null;
                }

                return _originalFirstName;
            }
        }
66	
        private string OriginalLastName
        {
            get
            {
                if (_originalLastName == "_not set_")
                {
                    return null;
                }

                return _originalLastName;
            }
        }

        public string Password { get; set; }
        public List<string> MemberOf { get; set; }

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
            string strUseDevBackendAuth = ConfigurationManager.AppSettings.Get("UseDevBackendAuth");

            if (string.IsNullOrEmpty(strUseDevBackendAuth) || !bool.TryParse(strUseDevBackendAuth, out bool useDevBackendAuth) || !useDevBackendAuth)
            {
                List<string> results = new List<string>();
                HashSet<string> existingUsers = new Search<LDAPUser>().GetReadOnlyReader(null, new string[] { "Username" }).Select(u => u.Username).ToHashSet();

                string ldapAddress = ConfigurationManager.AppSettings.Get("LDAPAddress");
                string ldapContainer = ConfigurationManager.AppSettings.Get("LDAPContainer");
                string ldapGroupName = ConfigurationManager.AppSettings.Get("LDAPGroupName");

                DirectoryEntry entry = new DirectoryEntry($"LDAP://{ldapAddress}/{ldapContainer}");
                DirectorySearcher searcher = new DirectorySearcher(entry);
                searcher.Filter = $"(memberof=cn={ldapGroupName},{ldapContainer})";
                searcher.PropertiesToLoad.Add("samaccountname");

                foreach (SearchResult result in searcher.FindAll())
                {
                    string username = result.GetDirectoryEntry().Properties["samaccountname"].Value as string;
                    if (!existingUsers.Contains(username))
                    {
                        results.Add(username);
                    }
                }

                return results;
            }
            else
            {
                TcpClient client = new TcpClient("localhost", 48175);

                List<string> users = new List<string>();
                using (BinaryReader reader = new BinaryReader(client.GetStream()))
                using (BinaryWriter writer = new BinaryWriter(client.GetStream()))
                {
                    writer.Write("GetAllUsers");
                    int listLength = reader.ReadInt32();
                    for(int i = 0; i < listLength; i++)
                    {
                        users.Add(reader.ReadString());
                    }
                }
                client.Close();
                return users;
            }
        }

        public static List<string> GetAllActiveDirectoryGroups()
        {
            List<string> groups = new List<string>(); string strUseDevBackendAuth = ConfigurationManager.AppSettings.Get("UseDevBackendAuth");

            if (string.IsNullOrEmpty(strUseDevBackendAuth) || !bool.TryParse(strUseDevBackendAuth, out bool useDevBackendAuth) || !useDevBackendAuth)
            {
                string ldapAddress = ConfigurationManager.AppSettings.Get("LDAPAddress");
                string ldapUser = ConfigurationManager.AppSettings.Get("LDAPUser");
                string ldapPassword = ConfigurationManager.AppSettings.Get("LDAPPassword");
                using (PrincipalContext context = new PrincipalContext(ContextType.Domain, ldapAddress, ldapUser, ldapPassword))
                using (GroupPrincipal queryFilter = new GroupPrincipal(context))
                using (PrincipalSearcher searcher = new PrincipalSearcher(queryFilter))
                {
                    foreach (GroupPrincipal group in searcher.FindAll().OfType<GroupPrincipal>())
                    {
                        groups.Add(group.SamAccountName);
                    }
                }
            }
            else
            {
                TcpClient client = new TcpClient("localhost", 48175);

                using (BinaryReader reader = new BinaryReader(client.GetStream()))
                using (BinaryWriter writer = new BinaryWriter(client.GetStream()))
                {
                    writer.Write("GetAllGroups");
                    int listLength = reader.ReadInt32();
                    for (int i = 0; i < listLength; i++)
                    {
                        groups.Add(reader.ReadString());
                    }
                }
                client.Close();
            }
            return groups;
        }

        public LDAPUser PopulateActiveDirectoryInformation()
        {
            string strUseDevBackendAuth = ConfigurationManager.AppSettings.Get("UseDevBackendAuth");

            if (string.IsNullOrEmpty(strUseDevBackendAuth) || !bool.TryParse(strUseDevBackendAuth, out bool useDevBackendAuth) || !useDevBackendAuth)
            {
                string ldapAddress = ConfigurationManager.AppSettings.Get("LDAPAddress");
                string ldapUser = ConfigurationManager.AppSettings.Get("LDAPUser");
                string ldapPassword = ConfigurationManager.AppSettings.Get("LDAPPassword");

                using (PrincipalContext context = new PrincipalContext(ContextType.Domain, ldapAddress, ldapUser, ldapPassword))
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

                DirectoryEntry directoryEntry = new DirectoryEntry($"LDAP://{ldapAddress}", ldapUser, ldapPassword);
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
            }
            else
            {
                TcpClient client = new TcpClient("localhost", 48175);

                List<string> users = new List<string>();
                using (BinaryReader reader = new BinaryReader(client.GetStream()))
                using (BinaryWriter writer = new BinaryWriter(client.GetStream()))
                {
                    writer.Write("GetUserInformation");
                    writer.Write(Username);

                    FirstName = reader.ReadString();
                    LastName = reader.ReadString();
                    Email = reader.ReadString();

                    int iterations = reader.ReadInt32();
                    MemberOf = new List<string>();
                    for(int i = 0; i < iterations; i++)
                    {
                        MemberOf.Add(reader.ReadString());
                    }
                }
                client.Close();
            }

            return this;
        }

        public void UpdateActiveDirectoryInformation()
        {
            string strUseDevBackendAuth = ConfigurationManager.AppSettings.Get("UseDevBackendAuth");

            if (string.IsNullOrEmpty(strUseDevBackendAuth) || !bool.TryParse(strUseDevBackendAuth, out bool useDevBackendAuth) || !useDevBackendAuth)
            {
                string ldapAddress = ConfigurationManager.AppSettings.Get("LDAPAddress");
                string ldapContainer = ConfigurationManager.AppSettings.Get("LDAPContainer");
                string ldapUser = ConfigurationManager.AppSettings.Get("LDAPUser");
                string ldapPassword = ConfigurationManager.AppSettings.Get("LDAPPassword");

                DirectoryEntry directoryEntry = new DirectoryEntry($"LDAP://{ldapAddress}/{ldapContainer}", ldapUser, ldapPassword);
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
            else
            {
                TcpClient client = new TcpClient("localhost", 48175);

                List<string> users = new List<string>();
                using (BinaryWriter writer = new BinaryWriter(client.GetStream()))
                {
                    writer.Write("SetUserInformation");
                    writer.Write(Username);
                    writer.Write(FirstName);
                    writer.Write(LastName);
                    writer.Write(Email);

                    writer.Write(MemberOf.Count);
                    foreach(string member in MemberOf)
                    {
                        writer.Write(member);
                    }
                }
                client.Close();
            }
        }

        public void CreateActiveDirectoryUser()
        {
            string strUseDevBackendAuth = ConfigurationManager.AppSettings.Get("UseDevBackendAuth");

            if (string.IsNullOrEmpty(strUseDevBackendAuth) || !bool.TryParse(strUseDevBackendAuth, out bool useDevBackendAuth) || !useDevBackendAuth)
            {
                string ldapAddress = ConfigurationManager.AppSettings.Get("LDAPAddress");
                string ldapContainer = ConfigurationManager.AppSettings.Get("LDAPContainer");
                string ldapUser = ConfigurationManager.AppSettings.Get("LDAPUser");
                string ldapPassword = ConfigurationManager.AppSettings.Get("LDAPPassword");

                DirectoryEntry directoryEntry = new DirectoryEntry($"LDAP://{ldapAddress}/{ldapContainer}", ldapUser, ldapPassword);
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
            else
            {
                TcpClient client = new TcpClient("localhost", 48175);

                List<string> users = new List<string>();
                using (BinaryWriter writer = new BinaryWriter(client.GetStream()))
                {
                    writer.Write("CreateUserInformation");
                    writer.Write(Username);
                    writer.Write(Password);
                    writer.Write(FirstName);
                    writer.Write(LastName);
                    writer.Write(Email);

                    writer.Write(MemberOf.Count);
                    foreach (string member in MemberOf)
                    {
                        writer.Write(member);
                    }
                }
                client.Close();
            }
        }

        public void DisableActiveDirectoryUser()
        {
            string strUseDevBackendAuth = ConfigurationManager.AppSettings.Get("UseDevBackendAuth");

            if (string.IsNullOrEmpty(strUseDevBackendAuth) || !bool.TryParse(strUseDevBackendAuth, out bool useDevBackendAuth) || !useDevBackendAuth)
            {
                string ldapAddress = ConfigurationManager.AppSettings.Get("LDAPAddress");
                string ldapContainer = ConfigurationManager.AppSettings.Get("LDAPContainer");
                string ldapUser = ConfigurationManager.AppSettings.Get("LDAPUser");
                string ldapPassword = ConfigurationManager.AppSettings.Get("LDAPPassword");

                DirectoryEntry directoryEntry = new DirectoryEntry($"LDAP://{ldapAddress}/{ldapContainer}", ldapUser, ldapPassword);
                DirectoryEntry userEntry = directoryEntry.Children.Find($"CN={_originalFirstName} {_originalLastName}");
                int userAccountControl = (int)userEntry.Properties["useraccountcontrol"].Value;
                userEntry.Properties["useraccountcontrol"].Value = userAccountControl | 0x2;
                userEntry.CommitChanges();
            }
            else
            {
                TcpClient client = new TcpClient("localhost", 48175);

                List<string> users = new List<string>();
                using (BinaryWriter writer = new BinaryWriter(client.GetStream()))
                {
                    writer.Write("DisableUser");
                    writer.Write(Username);
                }
                client.Close();
            }
        }
    }
}
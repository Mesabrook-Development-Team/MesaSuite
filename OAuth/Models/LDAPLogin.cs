using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;

namespace OAuth.Models
{
    public static class LDAPLogin
    {
        public static bool TryLDAPLogin(string user, string password)
        {
            string ldapAddress = ConfigurationManager.AppSettings.Get("LDAPAddress");
            string ldapContainer = ConfigurationManager.AppSettings.Get("LDAPContainer");
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, ldapAddress, ldapContainer))
            { 
                if (!pc.ValidateCredentials(user, password))
                {
                    return false;
                }
            }

            string ldapGroupName = ConfigurationManager.AppSettings.Get("LDAPGroupName");
            string ldapUser = ConfigurationManager.AppSettings.Get("LDAPUser");
            string ldapPassword = ConfigurationManager.AppSettings.Get("LDAPPassword");
            DirectoryEntry directoryEntry = new DirectoryEntry($"LDAP://{ldapAddress}/{ldapContainer}", ldapUser, ldapPassword);
            DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry);
            directorySearcher.Filter = $"(&(samaccountname={Sanitize(user)})(memberof=cn={ldapGroupName},{ldapContainer}))";

            SearchResult result = directorySearcher.FindOne();

            return result != null;
        }

        private static string Sanitize(string text)
        {
            text = text.Trim();
            char[] specialChars = new char[] { '\\', '#', '+', '<', '>', ',', ';', '"', '=' };
            Dictionary<char, string> replacements = new Dictionary<char, string>();

            foreach(char specialChar in specialChars)
            {
                replacements.Add(specialChar, Convert.ToByte(specialChar).ToString("x"));
            }

            string result = "";
            foreach(char character in text)
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
    }
}
using System;
using System.Collections.Generic;

namespace API.Common
{
    public class SecurityProfile
    {
        public long UserID { get; set; }
        public DateTime Expiration { get; set; }
        public string AccessToken { get; set; }
    }
}

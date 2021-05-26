using System.Collections.Generic;

namespace API_User.Models
{
    public class PatchData
    {
        public long? PrimaryKey { get; set; }
        public string Method { get; set; }
        public Dictionary<string, object> Values { get; set; }
    }
}
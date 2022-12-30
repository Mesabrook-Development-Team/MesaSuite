using System.Collections.Generic;

namespace SystemManagement.Models
{
    public class ItemNamespace
    {
        public long? ItemNamespaceID { get; set; }
        public string Namespace { get; set; }
        public string FriendlyName { get; set; }
        public List<Item> Items { get; set; }
    }
}

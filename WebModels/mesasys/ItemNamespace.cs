using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using System.Collections.Generic;

namespace WebModels.mesasys
{
    [Table("F9F1A245-7C93-4837-B790-5530B6EC2AD3")]
    public class ItemNamespace : DataObject
    {
        protected ItemNamespace() : base() { }

        private long? _itemNamespaceID;
        [Field("FC66A2C1-6765-4CAF-961A-225E0A07E8FC")]
        public long? ItemNamespaceID
        {
            get { CheckGet(); return _itemNamespaceID; }
            set { CheckSet(); _itemNamespaceID = value; }
        }

        private string _namespace;
        [Field("3181B12A-9EC8-43B4-B9C4-F27720781433", DataSize = 100)]
        public string Namespace
        {
            get { CheckGet(); return _namespace; }
            set { CheckSet(); _namespace = value; }
        }

        private string _friendlyName;
        [Field("EC2F1D03-9369-4879-BEF4-DDFAF0EABFB3", DataSize = 100)]
        public string FriendlyName
        {
            get { CheckGet(); return _friendlyName; }
            set { CheckSet(); _friendlyName = value; }
        }

        private List<Item> _items = new List<Item>();
        [RelationshipList("AC63A56D-63E8-43C3-811C-92549E8C714B", nameof(Item.ItemNamespaceID))]
        public IReadOnlyCollection<Item> Items
        {
            get { CheckGet(); return _items; }
        }
    }
}

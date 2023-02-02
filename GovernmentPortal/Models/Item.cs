using System.Drawing;
using System.IO;

namespace GovernmentPortal.Models
{
    public class Item
    {
        public long? ItemID { get; set; }
        public long? ItemNamespaceID { get; set; }
        public ItemNamespace ItemNamespace { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public byte[] Hash { get; set; }

        public Image GetImage()
        {
            if (Image == null)
            {
                return null;
            }

            using (MemoryStream stream = new MemoryStream(Image))
            {
                return System.Drawing.Image.FromStream(stream);
            }
        }
    }
}

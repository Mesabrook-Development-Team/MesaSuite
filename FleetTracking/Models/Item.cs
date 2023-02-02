using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetTracking.Models
{
    public class Item
    {
        public long? ItemID { get; set; }
        public long? ItemNamespaceID { get; set; }
        public ItemNamespace ItemNamespace { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public Image GetImage()
        {
            if (Image == null)
            {
                return null;
            }

            using (MemoryStream memoryStream = new MemoryStream(Image))
            {
                return System.Drawing.Image.FromStream(memoryStream);
            }
        }
    }
}

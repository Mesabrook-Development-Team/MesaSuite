using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;

namespace WebModels.fleet
{
    [Table("4BC25FCF-9500-4FA1-8F89-EECF2E6F686E")]
    [Unique(new[] { nameof(Name) })]
    public class RailcarModel : DataObject
    {
        public const decimal THUMBNAIL_WIDTH = 64M;
        protected RailcarModel() : base() { }

        private long? _railcarModelID;
        [Field("EF180866-34C0-4592-BC46-5E95865ED9DD")]
        public long? RailcarModelID
        {
            get { CheckGet(); return _railcarModelID; }
            set { CheckSet(); _railcarModelID = value; }
        }

        private string _name;
        [Field("AC0B56FD-C697-4648-8C73-C4096A167A04")]
        [Required]
        public string Name
        {
            get { CheckGet(); return _name; }
            set { CheckSet(); _name = value; }
        }

        private decimal? _cargoCapacity;
        [Field("2F3C2EE2-A7DB-4A6D-BC1C-8E149B5227F1", DataSize = 4)]
        [Required]
        public decimal? CargoCapacity
        {
            get { CheckGet(); return _cargoCapacity; }
            set { CheckSet(); _cargoCapacity = value; }
        }

        private decimal? _length;
        [Field("DB7F7B79-1516-444A-B249-4C34AE5A0140", DataSize = 3, DataScale = 1)]
        [Required]
        public decimal? Length
        {
            get { CheckGet(); return _length; }
            set { CheckSet(); _length = value;}
        }

        public enum Types
        {
            // Freight
            Box = 0,
            Tank = 1,
            Hopper = 2,
            Flat = 3,
            BulkheadFlat = 4,
            BulkheadStanchionFlat = 5,
            Centerbeam = 6,
            Autorack = 7,
            Gondola = 8,
            Well = 9,

            // Passenger
            Coach = 50,
            Diner = 51,
            Sleeper = 52,
            Baggage = 53,
            Mail = 54,
            Caboose = 55,
            Cab = 56
        }

        private Types _type;
        [Field("EA4CEF84-3EEC-4539-8D67-017B749D515E")]
        public Types Type
        {
            get { CheckGet(); return _type; }
            set { CheckSet(); _type = value; }
        }

        private byte[] _image;
        [Field("D924F78F-9352-4F23-B17B-97E8C2981F30")]
        public byte[] Image
        {
            get { CheckGet(); return _image; }
            set { CheckSet(); _image = value; }
        }

        private byte[] _imageThumbnail;
        [Field("D0D0CEFB-1BE4-4E26-8AD9-BC2523A0CA72")]
        public byte[] ImageThumbnail
        {
            get { CheckGet(); return _imageThumbnail; }
            set { CheckSet(); _imageThumbnail = value; }
        }

        protected override bool PreSave(ITransaction transaction)
        {
            if (IsFieldDirty(nameof(Image)))
            {
                using (MemoryStream inputStream = new MemoryStream(Image))
                using (Image image = System.Drawing.Image.FromStream(inputStream))
                {
                    int height = (int)(image.Height * (THUMBNAIL_WIDTH / image.Width));
                    using (Image thumbnail = image.GetThumbnailImage((int)THUMBNAIL_WIDTH, height, () => false, IntPtr.Zero))
                    using (MemoryStream outputStream = new MemoryStream())
                    {
                        thumbnail.Save(outputStream, ImageFormat.Png);
                        outputStream.Position = 0;

                        ImageThumbnail = new byte[outputStream.Length];
                        outputStream.Read(ImageThumbnail, 0, (int)outputStream.Length);
                    }
                }
            }

            return base.PreSave(transaction);
        }

        #region Relationships
        #region fleet
        private List<Railcar> _railcars = new List<Railcar>();
        [RelationshipList("76F3A839-BE37-40AE-A27A-BEB3E0DD4172", nameof(Railcar.RailcarModelID))]
        public IReadOnlyCollection<Railcar> Railcars
        {
            get { CheckGet(); return _railcars; }
        }
        #endregion
        #endregion
    }
}

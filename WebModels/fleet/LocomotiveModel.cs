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
    [Table("FA383B19-CAC4-4D32-BB0C-92A7EE19FD22")]
    [Unique(new[] { nameof(Name) })]
    public class LocomotiveModel : DataObject
    {
        public const decimal THUMBNAIL_WIDTH = 64M;

        protected LocomotiveModel() : base() { }

        private long? _locomotiveModelID;
        [Field("C56D04EE-2CB9-4117-8123-4337A52D6C6D")]
        public long? LocomotiveModelID
        {
            get { CheckGet(); return _locomotiveModelID; }
            set { CheckSet(); _locomotiveModelID = value; }
        }

        private string _name;
        [Field("55B8B5B9-8DB8-4EBB-9837-E467F6349F07")]
        [Required]
        public string Name
        {
            get { CheckGet(); return _name; }
            set { CheckSet(); _name = value; }
        }

        private decimal? _fuelCapacity;
        [Field("1D7DC553-305D-4DB4-907F-E4212894D0E1", DataSize = 4)]
        [Required]
        public decimal? FuelCapacity
        {
            get { CheckGet(); return _fuelCapacity; }
            set { CheckSet(); _fuelCapacity = value; }
        }

        private decimal? _waterCapacity;
        [Field("CBDA0D83-FCDE-4B16-9525-677C54205458", DataSize = 3)]
        [Required]
        public decimal? WaterCapacity
        {
            get { CheckGet(); return _waterCapacity; }
            set { CheckSet(); _waterCapacity = value; }
        }

        private decimal? _length;
        [Field("3C986FF5-0228-411C-8554-DBC9CC5FB42A", DataSize = 3, DataScale = 1)]
        [Required]
        public decimal? Length
        {
            get { CheckGet(); return _length; }
            set { CheckSet(); _length = value; }
        }

        private bool _isSteamPowered = false;
        [Field("C3C8FF49-D5F9-47A8-9462-87396B6A5968")]
        public bool IsSteamPowered
        {
            get { CheckGet(); return _isSteamPowered; }
            set { CheckSet(); _isSteamPowered = value; }
        }

        private byte[] _image;
        [Field("2591412C-9042-42AA-ACAC-E1D8C87957F0")]
        public byte[] Image
        {
            get { CheckGet(); return _image; }
            set { CheckSet(); _image = value; }
        }

        private byte[] _imageThumbnail;
        [Field("44DF6FCF-E5DC-4D35-AB74-94CCE34BBCFF")]
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
        private List<Locomotive> _locomotives = new List<Locomotive>();
        [RelationshipList("6D157C2A-41C2-423D-B6FB-7F35AAE05095", nameof(Locomotive.LocomotiveModelID))]
        public IReadOnlyCollection<Locomotive> Locomotives
        {
            get { CheckGet(); return _locomotives; }
        }
        #endregion
        #endregion
    }
}

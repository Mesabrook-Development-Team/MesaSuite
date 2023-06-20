using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;

namespace WebModels.company
{
    [Table("DFF647FA-116A-45CA-B323-50D52E5BD5FB")]
    [Unique(new[] { nameof(Identifier) })]
    public class Register : DataObject
    {
        protected Register() : base() { }

        private long? _registerID;
        [Field("EE688A1A-4BCF-4E0D-B186-4429544CD27C")]
        public long? RegisterID
        {
            get { CheckGet(); return _registerID; }
            set { CheckSet(); _registerID = value; }
        }

        private long? _locationID;
        [Field("4D86A21E-2453-46B8-9AC5-7FDCEFCC93D7")]
        [Required]
        public long? LocationID
        {
            get { CheckGet(); return _locationID; }
            set { CheckSet(); _locationID = value; }
        }

        private Location _location = null;
        [Relationship("F34D4F3D-7958-42F5-A9F8-54072BC83D5D")]
        public Location Location
        {
            get { CheckGet(); return _location; }
        }

        private Guid? _identifier;
        [Field("2F4D81D7-A567-438B-9AC3-83C05E6D0B81")]
        [Required]
        public Guid? Identifier
        {
            get { CheckGet(); return _identifier; }
            set { CheckSet(); _identifier = value; }
        }

        private string _name;
        [Field("21E1C81A-2850-4D0D-B76B-3C8FE4FE9CF6", DataSize = 30)]
        [Required]
        public string Name
        {
            get { CheckGet(); return _name; }
            set { CheckSet(); _name = value; }
        }

        #region Relationships
        #region company
        private List<StoreSale> _storeSales = new List<StoreSale>();
        [RelationshipList("DCACD1BC-88E3-4834-8492-256E8E5FFF98", nameof(StoreSale.RegisterID))]
        public IReadOnlyCollection<StoreSale> StoreSales
        {
            get { CheckGet(); return _storeSales; }
        }
        #endregion
        #endregion
    }
}

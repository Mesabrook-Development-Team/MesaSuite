using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModels.company;
using WebModels.gov;

namespace WebModels.fleet
{
    [Table("1F996588-63CB-4C81-AB5E-D0FB514E1E50")]
    public class CarHandlingRate : DataObject
    {
        protected CarHandlingRate() : base() { }

        private long? _carHandlingRateID;
        [Field("02063BC0-BFB3-43C6-9ABC-51DFCBB5D8A4")]
        public long? CarHandlingRateID
        {
            get { CheckGet(); return _carHandlingRateID; }
            set { CheckSet(); _carHandlingRateID = value; }
        }

        private long? _companyID;
        [Field("C88FB1E5-70B3-4310-9B79-C312BD70934D")]
        public long? CompanyID
        {
            get { CheckGet(); return _companyID; }
            set { CheckSet(); _companyID = value; }
        }

        private Company _company = null;
        [Relationship("F9E12B52-8D20-4E5C-82FD-5920A5BB370B")]
        public Company Company
        {
            get { CheckGet(); return _company; }
        }

        private long? _governmentID;
        [Field("6F3B7B93-6A2B-46B4-95DB-D30BC328E36F")]
        public long? GovernmentID
        {
            get { CheckGet(); return _governmentID; }
            set { CheckSet(); _governmentID = value; }
        }

        private Government _government = null;
        [Relationship("6CFE7752-255F-4175-A22E-97306A628BEC")]
        public Government Government
        {
            get { CheckGet(); return _government; }
        }

        private decimal? _interDistrictRate;
        [Field("D3BA6DD1-780F-495B-BD4C-2D262445F72A", DataSize = 9, DataScale = 2)]
        [Required]
        public decimal? InterDistrictRate
        {
            get { CheckGet(); return _interDistrictRate; }
            set { CheckSet(); _interDistrictRate = value; }
        }

        private decimal? _intraDistrictRate;
        [Field("11AC230C-43F1-4F15-96D8-115771D4CCEF", DataSize = 9, DataScale = 2)]
        [Required]
        public decimal? IntraDistrictRate
        {
            get { CheckGet(); return _intraDistrictRate; }
            set { CheckSet(); _intraDistrictRate = value; }
        }

        private decimal? _placementRate;
        [Field("32E6D910-E94B-43B9-B6BC-920FAFCBA1D9", DataSize = 9, DataScale = 2)]
        [Required]
        public decimal? PlacementRate
        {
            get { CheckGet(); return _placementRate; }
            set { CheckSet(); _placementRate = value; }
        }

        private DateTime? _effectiveTime;
        [Field("630AA93E-BE46-409A-A86E-57E0AE8F37FA", DataSize = 7)]
        [Required]
        public DateTime? EffectiveTime
        {
            get { CheckGet(); return _effectiveTime; }
            set { CheckSet(); _effectiveTime = value; }
        }
    }
}

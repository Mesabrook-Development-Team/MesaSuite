using System;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;

namespace WebModels.gov
{
    [Table("78EC3515-CF70-4E79-B258-EF5664A3D6CF")]
    public class SalesTax : DataObject
    {
        protected SalesTax() : base() { }

        private long? _salesTaxID = null;
        [Field("D724BFCE-DBFF-40FF-9659-14E4897EE14E")]
        public long? SalesTaxID
        {
            get { CheckGet(); return _salesTaxID; }
        }

        private long? _governmentID;
        [Field("384E7366-446F-40A7-96C2-EDD04D02FAAC")]
        [Required]
        public long? GovernmentID
        {
            get { CheckGet(); return _governmentID; }
            set { CheckSet(); _governmentID = value; }
        }

        private Government _government;
        [Relationship("7B121DDE-91CE-4667-8759-A3FB9302C4B2")]
        public Government Government
        {
            get { CheckGet(); return _government; }
        }

        private DateTime? _effectiveDate;
        [Field("87F1A339-D3A1-4648-926C-09ED47C43D64", DataSize = 7)]
        [Required]
        public DateTime? EffectiveDate
        {
            get { CheckGet(); return _effectiveDate; }
            set { CheckSet(); _effectiveDate = value; }
        }

        private decimal? _rate;
        [Field("EA76F9FA-D070-4FD9-B2E7-5EC9BAA9F23B", DataSize = 5, DataScale = 2)]
        [Required]
        public decimal? Rate
        {
            get { CheckGet(); return _rate; }
            set { CheckSet(); _rate = value; }
        }
    }
}

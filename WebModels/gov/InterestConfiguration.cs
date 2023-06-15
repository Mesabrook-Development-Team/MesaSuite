using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;

namespace WebModels.gov
{
    [Table("60C36D1D-A10F-4FC0-AE56-4AB47112BC98")]
    public class InterestConfiguration : DataObject
    {
        protected InterestConfiguration() : base() { }

        private long? _interestConfigurationID;
        [Field("BC5D16A6-7839-4931-B69E-6E7B3067D757")]
        public long? InterestConfigurationID
        {
            get { CheckGet(); return _interestConfigurationID; }
            set { CheckSet(); _interestConfigurationID = value; }
        }

        private decimal? _rateGovernment;
        [Field("6BE95D69-C33B-4A5C-8713-1CD215B282B2", DataSize = 5, DataScale = 2)]
        [Required]
        public decimal? RateGovernment
        {
            get { CheckGet(); return _rateGovernment; }
            set { CheckSet(); _rateGovernment = value; }
        }

        private decimal? _wealthCapGovernment;
        [Field("6255844A-5BB8-441C-8DA1-E1C268B5A241", DataSize = 9, DataScale = 2)]
        [Required]
        public decimal? WealthCapGovernment
        {
            get { CheckGet(); return _wealthCapGovernment; }
            set { CheckSet(); _wealthCapGovernment = value; }
        }

        private decimal? _rateLocation;
        [Field("769E8D77-081E-4507-AFA7-AD2EC9F00CC6", DataSize = 5, DataScale = 2)]
        [Required]
        public decimal? RateLocation
        {
            get { CheckGet(); return _rateLocation; }
            set { CheckSet(); _rateLocation = value; }
        }

        private decimal? _wealthCapLocation;
        [Field("9D800019-D476-4034-B43B-94E30B7C6AC3", DataSize = 9, DataScale = 2)]
        [Required]
        public decimal? WealthCapLocation
        {
            get { CheckGet(); return _wealthCapLocation; }
            set { CheckSet(); _wealthCapLocation = value; }
        }

        private DateTime? _nextInterestRun;
        [Field("D2623A07-B5C2-4E0F-8B0A-BA8A339C954E", DataSize = 7)]
        [Required]
        public DateTime? NextInterestRun
        {
            get { CheckGet(); return _nextInterestRun; }
            set { CheckSet(); _nextInterestRun = value; }
        }

        protected override void PreValidate()
        {
            base.PreValidate();
            NextInterestRun = NextInterestRun?.Date;
        }
    }
}

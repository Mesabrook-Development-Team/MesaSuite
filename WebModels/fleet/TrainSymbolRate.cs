using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;

namespace WebModels.fleet
{
    [Table("025BEF43-3710-4424-88A8-B79807664ACA")]
    public class TrainSymbolRate : DataObject
    {
        protected TrainSymbolRate() : base() { }

        private long? _trainSymbolRateID;
        [Field("A1C7417C-A812-4E89-A1F4-737C81E74522")]
        public long? TrainSymbolRateID
        {
            get { CheckGet(); return _trainSymbolRateID; }
            set { CheckSet(); _trainSymbolRateID = value; }
        }

        private long? _trainSymbolID;
        [Field("A155A8EE-8372-41A4-96CC-C50EF84352B3")]
        [Required]
        public long? TrainSymbolID
        {
            get { CheckGet(); return _trainSymbolID; }
            set { CheckSet(); _trainSymbolID = value; }
        }

        private TrainSymbol _trainSymbol = null;
        [Relationship("D80FA090-0453-4EDE-AEA6-59BBC22C2C71")]
        public TrainSymbol TrainSymbol
        {
            get { CheckGet(); return _trainSymbol; }
        }

        private DateTime? _effectiveTime;
        [Field("1DBA9C63-0129-49FF-BA2C-EE87678A09BA", DataSize = 7)]
        [Required]
        public DateTime? EffectiveTime
        {
            get { CheckGet(); return _effectiveTime; }
            set { CheckSet(); _effectiveTime = value; }
        }

        private decimal? _ratePerCar;
        [Field("6709FDDA-A258-4866-AF1A-A409FCD36FD6", DataSize = 9, DataScale = 2)]
        [Required]
        public decimal? RatePerCar
        {
            get { CheckGet(); return _ratePerCar; }
            set { CheckSet(); _ratePerCar = value; }
        }

        private decimal? _ratePerPartialTrip;
        [Field("88417201-3B86-47C5-B6E1-425A7BA13631", DataSize = 9, DataScale = 2)]
        [Required]
        public decimal? RatePerPartialTrip
        {
            get { CheckGet(); return _ratePerPartialTrip; }
            set { CheckSet(); _ratePerPartialTrip = value; }
        }
    }
}

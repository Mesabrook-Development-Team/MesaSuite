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
    [Table("A1D227DD-3696-4006-92AD-01D79C2AACE8")]
    public class TrainFuelRecord : DataObject
    {
        protected TrainFuelRecord() : base() { }

        private long? _trainFuelRecordID;
        [Field("853FBC37-AEB4-4CDA-8223-12A8D29D2FE4")]
        public long? TrainFuelRecordID
        {
            get { CheckGet(); return _trainFuelRecordID; }
            set { CheckSet(); _trainFuelRecordID = value; }
        }

        private long? _trainID;
        [Field("978C2A7A-0EA6-4CF2-9D45-604C716589D3")]
        [Required]
        public long? TrainID
        {
            get { CheckGet(); return _trainID; }
            set { CheckSet(); _trainID = value; }
        }

        private Train _train = null;
        [Relationship("B789F8F7-0045-42F1-A727-7FF656BA79D1")]
        public Train Train
        {
            get { CheckGet(); return _train; }
        }

        private long? _locomotiveID;
        [Field("0AB56ECA-FD4B-423C-8CD7-0EB9E5B2CA65")]
        [Required]
        public long? LocomotiveID
        {
            get { CheckGet(); return _locomotiveID; }
            set { CheckSet(); _locomotiveID = value; }
        }

        private Locomotive _locomotive = null;
        [Relationship("80C3B33C-A546-4FAB-BB82-7528A7FD521B")]
        public Locomotive Locomotive
        {
            get { CheckGet(); return _locomotive; }
        }

        private decimal? _fuelStart;
        [Field("E527F690-EABA-4D9C-8E7E-78620DE1CE6F", DataSize = 4, DataScale = 1)]
        public decimal? FuelStart
        {
            get { CheckGet(); return _fuelStart; }
            set { CheckSet(); _fuelStart = value; }
        }

        private decimal? _fuelEnd;
        [Field("CDCAD0D2-D2E5-42E6-BB05-55F1BF758D39", DataSize = 4, DataScale = 1)]
        public decimal? FuelEnd
        {
            get { CheckGet(); return _fuelEnd; }
            set { CheckSet(); _fuelEnd = value; }
        }
    }
}

using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;
using System.Collections.Generic;

namespace WebModels.netprint
{
    [Table("218CA855-DDCC-410E-8C1D-1AFF69738CCD")]
    [Unique(new[] { nameof(Address) })]
    public class Printer : DataObject
    {
        protected Printer() : base() { }

        private long? _printerID;
        [Field("C9E966AB-20E4-46F1-AF03-7878FDF466B1")]
        public long? PrinterID
        {
            get { CheckGet(); return _printerID; }
            set { CheckSet(); _printerID = value; }
        }

        private Guid? _address;
        [Field("A872CAE3-68BF-4DA6-850B-DE3F5824F502")]
        public Guid? Address
        {
            get { CheckGet(); return _address; }
            set { CheckSet(); _address = value; }
        }

        private string _name;
        [Field("1FA97F41-1302-42D7-9920-16C22A880A2C", DataSize = 50)]
        public string Name
        {
            get { CheckGet(); return _name; }
            set { CheckSet(); _name = value; }
        }

        #region Relationships
        #region netprint
        private List<PrintJob> _printJobs = new List<PrintJob>();
        [RelationshipList("237CE238-DD11-4503-9159-D18F65425956", nameof(PrintJob.PrinterID), AutoDeleteReferences = true)]
        public IReadOnlyCollection<PrintJob> PrintJobs
        {
            get { CheckGet(); return _printJobs; }
        }
        #endregion
        #endregion
    }
}

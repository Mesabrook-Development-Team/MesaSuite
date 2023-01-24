using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System.Collections.Generic;

namespace WebModels.netprint
{
    [Table("DDBFEF15-2E3E-4B43-A0A1-9B5D2C897CA7")]
    public class PrintPage : DataObject
    {
        protected PrintPage() : base() { }

        private long? _printPageID;
        [Field("9AB2E224-67A6-4E61-A295-7FB42D9A4512")]
        public long? PrintPageID
        {
            get { CheckGet(); return _printPageID; }
            set { CheckSet(); _printPageID = value; }
        }

        private long? _printJobID;
        [Field("2A8FF0BF-1A91-442F-8B3E-98F314E64A40")]
        [Required]
        public long? PrintJobID
        {
            get { CheckGet(); return _printJobID; }
            set { CheckSet(); _printJobID = value; }
        }

        private PrintJob _printJob = null;
        [Relationship("BFC90F0E-69E2-424E-B65F-F82BFFD88B6A")]
        public PrintJob PrintJob
        {
            get { CheckGet(); return _printJob; }
        }

        private byte? _displayOrder;
        [Field("641E58B2-F749-4D39-A2D8-123A09F732BB")]
        [Required]
        public byte? DisplayOrder
        {
            get { CheckGet(); return _displayOrder; }
            set { CheckSet(); _displayOrder = value; }
        }

        #region Relationships
        #region netprint
        private List<PrintLine> _printLines = new List<PrintLine>();
        [RelationshipList("278BAA95-52F2-4B99-9CFF-25FBDBF5A7E9", nameof(PrintLine.PrintPageID), AutoDeleteReferences = true)]
        public IReadOnlyCollection<PrintLine> PrintLines
        {
            get { CheckGet(); return _printLines; }
        }
        #endregion
        #endregion
    }
}

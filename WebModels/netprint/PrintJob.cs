using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModels.netprint
{
    [Table("3F71B0E6-922D-4060-90F3-2B7393DBC02B")]
    public class PrintJob : DataObject
    {
        protected PrintJob() : base() { }

        private long? _printJobID;
        [Field("B6A0CF72-F7B7-44EA-AD22-407E3A50EF8C")]
        public long? PrintJobID
        {
            get { CheckGet(); return _printJobID; }
            set { CheckSet(); _printJobID = value; }
        }

        private long? _printerID;
        [Field("E62D8387-C264-42B1-986A-4C00C4A78FE3")]
        [Required]
        public long? PrinterID
        {
            get { CheckGet(); return _printerID; }
            set { CheckSet(); _printerID = value; }
        }

        private Printer _printer = null;
        [Relationship("1C369801-B3A6-4F07-8B3F-B03B3063706E")]
        public Printer Printer
        {
            get { CheckGet(); return _printer; }
        }

        private string _documentName;
        [Field("66009920-5F88-4E98-9175-FEF6D5981535", DataSize = 50)]
        public string DocumentName
        {
            get { CheckGet(); return _documentName; }
            set { CheckSet(); _documentName = value; }
        }

        private bool _finalized;
        [Field("DD44137C-F191-4EED-B775-DD854D5587FE")]
        public bool Finalized
        {
            get { CheckGet(); return _finalized; }
            set { CheckSet(); _finalized = value; }
        }

        #region Relationships
        #region netprint
        private List<PrintPage> _printPages = new List<PrintPage>();
        [RelationshipList("DB935604-CFDE-4D81-BAAB-5F5936F0F5CF", nameof(PrintPage.PrintJobID), AutoDeleteReferences = true)]
        public IReadOnlyCollection<PrintPage> PrintPages
        {
            get { CheckGet(); return _printPages; }
        }
        #endregion
        #endregion
    }
}

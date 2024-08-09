using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModels.fleet;

namespace WebModels.purchasing
{
    [Table("69A58C83-F71A-4D03-9014-66AC9F44F431")]
    public class Fulfillment : DataObject
    {
        protected Fulfillment() : base() { }

        private long? _fulfillmentID;
        [Field("BE38AD1A-D597-410B-A648-1A045A61BE8F")]
        public long? FulfillmentID
        {
            get { CheckGet(); return _fulfillmentID; }
            set { CheckSet(); _fulfillmentID = value; }
        }

        private long? _purchaseOrderLineID;
        [Field("FD061D55-3DC5-4971-9378-F574DF9379B4")]
        public long? PurchaseOrderLineID
        {
            get { CheckGet(); return _purchaseOrderLineID; }
            set { CheckSet(); _purchaseOrderLineID = value; }
        }

        private PurchaseOrderLine _purchaseOrderLine = null;
        [Relationship("B4C4F29A-5AAC-4764-B44E-4423FDE6F274")]
        public PurchaseOrderLine PurchaseOrderLine
        {
            get { CheckGet(); return _purchaseOrderLine; }
        }

        private long? _railcarID;
        [Field("5DF67988-505F-4C64-9033-B73DA9DA88CC")]
        public long? RailcarID
        {
            get { CheckGet(); return _railcarID; }
            set { CheckSet(); _railcarID = value; }
        }

        private Railcar _railcar = null;
        [Relationship("FF26162A-4B88-4A84-86C6-2835CDE7722D")]
        public Railcar Railcar
        {
            get { CheckGet(); return _railcar; }
        }

        private DateTime? _fulfillmentTime;
        [Field("1BEB679A-F97C-49B2-ADF7-6EECD4CB5BE5", DataSize = 7)]
        public DateTime? FulfillmentTime
        {
            get { CheckGet(); return _fulfillmentTime; }
            set { CheckSet(); _fulfillmentTime = value; }
        }

        private decimal? _quantity;
        [Field("13E1F961-EDD3-467F-A43E-FDEB38D116DD", DataSize = 9, DataScale = 2)]
        public decimal? Quantity
        {
            get { CheckGet(); return _quantity; }
            set { CheckSet(); _quantity = value; }
        }

        private bool _isComplete;
        [Field("8DCC6724-0CD0-4FDA-904D-6B0373AD776F")]
        public bool IsComplete
        {
            get { CheckGet(); return _isComplete; }
            set { CheckSet(); _isComplete = value; }
        }
    }
}

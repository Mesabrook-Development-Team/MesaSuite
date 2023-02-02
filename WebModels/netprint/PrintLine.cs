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
    [Table("3A6D691A-B8BA-4E48-A5C3-BB8E62B45E2D")]
    public class PrintLine : DataObject
    {
        protected PrintLine() : base() { }

        private long? _printLineID;
        [Field("599A640E-171E-4FC9-8FF9-78DE76CB8800")]
        public long? PrintLineID
        {
            get { CheckGet(); return _printLineID; }
            set { CheckSet(); _printLineID = value; }
        }

        private long? _printPageID;
        [Field("A5CC8B7C-D987-4869-874E-48C72BC584E7")]
        [Required]
        public long? PrintPageID
        {
            get { CheckGet(); return _printPageID; }
            set { CheckSet(); _printPageID = value; }
        }

        private PrintPage _printPage = null;
        [Relationship("928C66FB-70DB-4232-B011-6FBEF827BB1E")]
        public PrintPage PrintPage
        {
            get { CheckGet(); return _printPage; }
        }

        private byte? _displayOrder;
        [Field("2E17C13D-BECB-4B17-9307-41C3A587B52B")]
        [Required]
        public byte? DisplayOrder
        {
            get { CheckGet(); return _displayOrder; }
            set { CheckSet(); _displayOrder = value; }
        }

        public enum Alignments
        {
            Unspecified = 0,
            Left = 1,
            Center = 2
        }

        private Alignments _alignment = Alignments.Unspecified;
        [Field("BA10123E-9098-4947-B75E-3F44EFB84830")]
        public Alignments Alignment
        {
            get { CheckGet(); return _alignment; }
            set { CheckSet(); _alignment = value; }
        }

        private string _text;
        [Field("59D05B24-3AB5-4971-88CD-FA067C0961ED", DataSize = 50)]
        public string Text
        {
            get { CheckGet(); return _text; }
            set { CheckSet(); _text = value; }
        }
    }
}

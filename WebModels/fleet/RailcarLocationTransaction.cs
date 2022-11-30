﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using WebModels.invoicing;

namespace WebModels.fleet
{
    [Table("1AE60907-D2E1-41E2-8A83-ECCBCCFDE4EE")]
    public class RailcarLocationTransaction : DataObject
    {
        protected RailcarLocationTransaction() : base() { }

        private long? _railcarLocationTransactionID;
        [Field("7A16493F-6E65-47F4-900E-A8906924FE5B")]
        public long? RailcarLocationTransactionID
        {
            get { CheckGet(); return _railcarLocationTransactionID; }
            set { CheckSet(); _railcarLocationTransactionID = value; }
        }

        private long? _railcarID;
        [Field("522B7C1D-8B85-4F79-99AB-9C544B580DAE")]
        public long? RailcarID
        {
            get { CheckGet(); return _railcarID; }
            set { CheckSet(); _railcarID = value; }
        }

        private Railcar _railcar = null;
        [Relationship("3D900125-A963-4F3A-B14A-24C647435524")]
        public Railcar Railcar
        {
            get { CheckGet(); return _railcar; }
        }

        private long? _trackIDNew;
        [Field("0D6E2013-4E8B-4881-BF3C-0EB9A591880E")]
        public long? TrackIDNew
        {
            get { CheckGet(); return _trackIDNew; }
            set { CheckSet(); _trackIDNew = value; }
        }

        private Track _trackNew = null;
        [Relationship("DF526231-1EB5-426B-A2DF-840510B80592", ForeignKeyField = nameof(TrackIDNew))]
        public Track TrackNew
        {
            get { CheckGet(); return _trackNew; }
        }

        private long? _trainIDNew;
        [Field("E88AF0F2-8ACB-46D8-A347-88F6F2609A2C")]
        public long? TrainIDNew
        {
            get { CheckGet(); return _trainIDNew; }
            set { CheckSet(); _trainIDNew = value; }
        }

        private Train _trainNew = null;
        [Relationship("C73C5130-8D0B-469A-93D5-75CCF161043B", ForeignKeyField = nameof(TrainIDNew))]
        public Train TrainNew
        {
            get { CheckGet(); return _trainNew; }
        }

        private bool _isPartialTrainTrip;
        [Field("217E7862-3B56-4BA1-B11A-61B53B89720C")]
        public bool IsPartialTrainTrip
        {
            get { CheckGet(); return _isPartialTrainTrip; }
            set { CheckSet(); _isPartialTrainTrip = value; }
        }

        private DateTime? _transactionTime;
        [Field("3932912A-D4C5-4520-B0C4-3DD77BFF2320", DataSize = 7)]
        public DateTime? TransactionTime
        {
            get { CheckGet(); return _transactionTime; }
            set { CheckSet(); _transactionTime = value; }
        }

        private long? _invoiceID;
        [Field("CD805F6D-D3FD-4413-B10E-094EB5261D08")]
        public long? InvoiceID
        {
            get { CheckGet(); return _invoiceID; }
            set { CheckSet(); _invoiceID = value; }
        }

        private Invoice _invoice = null;
        [Relationship("07F4CF3C-2ED4-48D5-9B5F-25708806EE59")]
        public Invoice Invoice
        {
            get { CheckGet(); return _invoice; }
        }
    }
}
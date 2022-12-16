using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;

namespace WebModels.fleet
{
    [Table("18F49DE6-3BEF-475A-8AE0-75F44B6D2FCF")]
    public class RailLocation : DataObject
    {
        protected RailLocation() : base() { }

        private long? _railLocationID;
        [Field("3F670925-DB28-452A-BCA0-B4D1C65F31E0")]
        public long? RailLocationID
        {
            get { CheckGet(); return _railLocationID; }
            set { CheckSet(); _railLocationID = value; }
        }

        private long? _railcarID;
        [Field("8EF4797C-601D-43B7-BFCA-6ED46D2A83B3")]
        public long? RailcarID
        {
            get { CheckGet(); return _railcarID; }
            set { CheckSet(); _railcarID = value; }
        }

        private Railcar _railcar = null;
        [Relationship("E8432428-9DC1-44A2-BFB1-BA9CF2D03E69")]
        public Railcar Railcar
        {
            get { CheckGet(); return _railcar; }
        }

        private long? _locomotiveID;
        [Field("4D05FE1B-513D-494C-B981-B6BCE3382523")]
        public long? LocomotiveID
        {
            get { CheckGet(); return _locomotiveID; }
            set { CheckSet(); _locomotiveID = value; }
        }

        private Locomotive _locomotive = null;
        [Relationship("9433F22B-85EB-4491-B586-231FB1EAD27C")]
        public Locomotive Locomotive
        {
            get { CheckGet(); return _locomotive; }
        }

        private int _position;
        [Field("17A69205-E208-4EFA-B334-582FB350E5C9")]
        public int Position
        {
            get { CheckGet(); return _position; }
            set { CheckSet(); _position = value; }
        }

        private long? _trackID;
        [Field("AD775C9C-6335-454A-A742-2E9E1BC74093")]
        public long? TrackID
        {
            get { CheckGet(); return _trackID; }
            set { CheckSet(); _trackID = value; }
        }

        private Track _track = null;
        [Relationship("6C3CAA16-F70B-49C5-9EC6-45DB2521F70C")]
        public Track Track
        {
            get { CheckGet(); return _track; }
        }

        private long? _trainID;
        [Field("E1EA4858-20C4-4AA5-B169-CBC357E1620C")]
        public long? TrainID
        {
            get { CheckGet(); return _trainID; }
            set { CheckSet(); _trainID = value; }
        }

        private Train _train = null;
        [Relationship("24A60843-8E40-42BF-8D4A-D61344412AE6")]
        public Train Train
        {
            get { CheckGet(); return _train; }
        }
    }
}

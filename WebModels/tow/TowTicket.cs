using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using WebModels.security;

namespace WebModels.tow
{
    [Table("7F15B038-5461-4C4E-9727-23D560652661")]
    public class TowTicket : DataObject
    {
        protected TowTicket() : base() { }

        private long? _towTicketID;
        [Field("E4F17EC8-13F6-4F94-94C5-EDE4A3BDDE5A")]
        public long? TowTicketID
        {
            get { CheckGet(); return _towTicketID; }
            set { CheckSet(); _towTicketID = value; }
        }

        private long? _userIDIssuedTo;
        [Field("F19328CA-7AE5-458B-BA27-36F7C1935612")]
        [Required]
        public long? UserIDIssuedTo
        {
            get { CheckGet(); return _userIDIssuedTo; }
            set { CheckSet(); _userIDIssuedTo = value; }
        }

        private User _userIssuedTo = null;
        [Relationship("4A5FF95C-5EB3-4015-81C9-668024E6F8BD", ForeignKeyField = nameof(UserIDIssuedTo))]
        public User UserIssuedTo
        {
            get { CheckGet(); return _userIssuedTo; }
        }

        private string _ticketNumber;
        [Field("030A59B6-A3F2-4F9C-A906-6558334A0EEC", DataSize = 6)]
        [Required]
        public string TicketNumber
        {
            get { CheckGet(); return _ticketNumber; }
            set { CheckSet(); _ticketNumber = value; }
        }

        private DateTime? _issueDate;
        [Field("05A2D94F-F2CB-42E5-A317-47744105FBDD")]
        public DateTime? IssueDate
        {
            get { CheckGet(); return _issueDate; }
            set { CheckSet(); _issueDate = value; }
        }

        private string _phoneNumber;
        [Field("C8D3F9E3-5156-4975-90CE-D85FF8FC06DE", DataSize = 8)]
        public string PhoneNumber
        {
            get { CheckGet(); return _phoneNumber; }
            set { CheckSet(); _phoneNumber = value; }
        }

        private int? _coordX;
        [Field("77E7BF92-B613-4D32-959A-7C26C4FBD6B1")]
        
        public int? CoordX
        {
            get { CheckGet(); return _coordX; }
            set { CheckSet(); _coordX = value; }
        }

        private int? _coordZ;
        [Field("91A6E25C-9424-4E74-A7FB-40735EA3B501")]
        public int? CoordZ
        {
            get { CheckGet(); return _coordZ; }
            set { CheckSet(); _coordZ = value; }
        }

        private string _description;
        [Field("A1D184FA-C49D-4A35-8759-A3D358606592", DataSize = 500)]
        public string Description
        {
            get { CheckGet(); return _description; }
            set { CheckSet(); _description = value;}
        }

        private long? _userIDResponding;
        [Field("AD45C1FE-E106-431B-BAC3-05A35D355A8C")]
        public long? UserIDResponding
        {
            get { CheckGet(); return _userIDResponding; }
            set { CheckSet(); _userIDResponding = value; }
        }

        private User _userResponding = null;
        [Relationship("5E6298FF-D64B-497F-99C3-E8D5E73600AA", ForeignKeyField = nameof(UserIDResponding))]
        public User UserResponding
        {
            get { CheckGet(); return _userResponding; }
        }

        public enum Statuses
        {
            New = 0,
            Requested = 1,
            ResponseEnRoute = 2,
            History = 3
        }

        public Statuses Status
        {
            get { return (Statuses)StatusCode; }
            set { StatusCode = (int)value; }
        }

        private int? _statusCode = (int)Statuses.New;
        [Field("17E6A94C-E2F7-473B-83DC-07EF7DDF73F1")]
        [Required]
        public int? StatusCode
        {
            get { CheckGet(); return _statusCode; }
            set { CheckSet(); _statusCode = value; }
        }
    }
}

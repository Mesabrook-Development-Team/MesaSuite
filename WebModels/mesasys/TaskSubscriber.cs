using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModels.security;

namespace WebModels.mesasys
{
    [Table("D30ABF47-2724-4E20-B2AD-0F7D54599668")]
    public class TaskSubscriber : DataObject
    {
        protected TaskSubscriber() : base() { }

        private long? _taskSubscriberID;
        [Field("68324C13-060D-4752-8787-016F36D739E2")]
        public long? TaskSubscriberID
        {
            get { CheckGet(); return _taskSubscriberID; }
            set { CheckSet(); _taskSubscriberID = value; }
        }

        private long? _taskEventID;
        [Field("C3848D26-CD78-40C0-86EA-B2FB7BB2A601")]
        [Required]
        public long? TaskEventID
        {
            get { CheckGet(); return _taskEventID; }
            set { CheckSet(); _taskEventID = value; }
        }

        private TaskEvent _taskEvent = null;
        [Relationship("F57D26C9-E9B6-460B-B6AA-1D5526043888")]
        public TaskEvent TaskEvent
        {
            get { CheckGet(); return _taskEvent; }
        }

        private long? _userID;
        [Field("D08CFEA2-E7E7-43F2-9DF6-D0D96971B59F")]
        [Required]
        public long? UserID
        {
            get { CheckGet(); return _userID; }
            set { CheckSet(); _userID = value; }
        }

        private User _user = null;
        [Relationship("93DB6ADB-3CEB-466E-8AC7-BABA1A3854E1")]
        public User User
        {
            get { CheckGet(); return _user; }
        }
    }
}

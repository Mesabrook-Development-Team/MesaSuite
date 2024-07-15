using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModels.mesasys
{
    [Table("175AFFB6-515D-4541-A361-D83A2537343D")]
    public class Notification : DataObject
    {
        protected Notification() : base() { }

        private long? _notificationID;
        [Field("57472B69-9F74-4E41-A907-5761A8BD482F")]
        public long? NotificationID
        {
            get { CheckGet(); return _notificationID; }
            set { CheckSet(); _notificationID = value; }
        }

        private long? _notificationSubscriberID;
        [Field("264A8BB9-384B-4611-B05F-3B0D7D5D8EAB")]
        [Required]
        public long? NotificationSubscriberID
        {
            get { CheckGet(); return _notificationSubscriberID; }
            set { CheckSet(); _notificationSubscriberID = value; }
        }

        private NotificationSubscriber _notificationSubscriber = null;
        [Relationship("CEEDAA95-E0DC-4EFE-857D-A327BD6F819F")]
        public NotificationSubscriber NotificationSubscriber
        {
            get { CheckGet(); return _notificationSubscriber; }
        }

        private DateTime? _notificationTime;
        [Field("D2C45371-DB9A-46EA-A6BA-FDE4782C57B2", DataSize = 7)]
        [Required]
        public DateTime? NotificationTime
        {
            get { CheckGet(); return _notificationTime; }
            set { CheckSet(); _notificationTime = value; }
        }

        private bool _isRead;
        [Field("8D6324C4-4A7D-4BF1-A98E-DE5A57D1C437")]
        public bool IsRead
        {
            get { CheckGet(); return _isRead; }
            set { CheckSet(); _isRead = value; }
        }

        private string _message;
        [Field("B6C5F8D6-1F9C-4A3E-9E8E-9F5B5F8D6B6C", DataSize = 1000)]
        [Required]
        public string Message
        {
            get { CheckGet(); return _message; }
            set { CheckSet(); _message = value; }
        }
    }
}

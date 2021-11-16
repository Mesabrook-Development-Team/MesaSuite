using System;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;

namespace WebModels.mesasys
{
    [Table("4ABB8561-D139-41F6-9C4D-EA6B707D805B")]
    public class CrashReport : DataObject
    {
        protected CrashReport() : base() { }

        private long? _crashReportID;
        [Field("EE09BD24-BB9C-4F4A-AE4C-9A748607D255")]
        public long? CrashReportID
        {
            get { CheckGet(); return _crashReportID; }
            set { CheckSet(); _crashReportID = value; }
        }

        private DateTime? _time;
        [Field("16183017-8794-4E4B-9FC2-B61E46475D0A", DataSize = 7)]
        [Required]
        public DateTime? Time
        {
            get { CheckGet(); return _time; }
            set { CheckSet(); _time = value; }
        }

        private string _program;
        [Field("01329A3C-07C7-4366-B6F5-547FD74ADB5B", DataSize = 100)]
        [Required]
        public string Program
        {
            get { CheckGet(); return _program; }
            set { CheckSet(); _program = value; }
        }

        private string _exception;
        [Field("F25B9CA2-2E8E-4A7A-A24F-4DD229F77770", DataSize = -1)]
        [Required]
        public string Exception
        {
            get { CheckGet(); return _exception; }
            set { CheckSet(); _exception = value; }
        }

        private string _user;
        [Field("2E80D7B3-BCB1-4B5C-8BEC-AB1C7D3B39ED", DataSize = 50)]
        [Required]
        public string User
        {
            get { CheckGet(); return _user; }
            set { CheckSet(); _user = value; }
        }
    }
}

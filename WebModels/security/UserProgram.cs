using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModels.security
{
    [Table("10D7D52A-4B7B-40D5-9362-435DD26BF85F")]
    public class UserProgram : DataObject
    {
        protected UserProgram() : base() { }

        private long? _userProgramID = null;
        [Field("528578E8-6C58-49C4-AA47-4418806A7961")]
        public long? UserProgramID
        {
            get { CheckGet(); return _userProgramID; }
            set { CheckSet(); _userProgramID = value; }
        }

        private long? _userID;
        [Field("E3C21BEC-F825-45B7-9990-D79BD45500FB")]
        [Required]
        public long? UserID
        {
            get { CheckGet(); return _userID; }
            set { CheckSet(); _userID = value; }
        }

        private User _user = null;
        [Relationship("F7EAEF09-7580-4DBF-A84C-D3E830ECF201")]
        public User User
        {
            get { CheckGet(); return _user; }
        }

        private long? _programID;
        [Field("EC352E5A-0220-410B-9954-342EC52E9AE2")]
        [Required]
        public long? ProgramID
        {
            get { CheckGet(); return _programID; }
            set { CheckSet(); _programID = value; }
        }

        private Program _program = null;
        [Relationship("B7C695AB-C12A-4ECB-99C8-5A6C6A956A14")]
        public Program Program
        {
            get { CheckGet(); return _program; }
        }
    }
}

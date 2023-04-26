using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using WebModels.company;
using WebModels.gov;

namespace WebModels.fleet
{
    [Table("7F9FDF21-771B-4C05-A705-458F76ED3B09")]
    public class FleetSecurity : DataObject
    {
        protected FleetSecurity() : base() { }

        private long? _fleetSecurityID;
        [Field("7E380F30-D555-46FB-89ED-77237779A3A6")]
        public long? FleetSecurityID
        {
            get { CheckGet(); return _fleetSecurityID; }
            set { CheckSet(); _fleetSecurityID = value; }
        }

        private long? _employeeID;
        [Field("8E3FFA56-7549-44EA-8E44-79FFAE31BC30")]
        public long? EmployeeID
        {
            get { CheckGet(); return _employeeID; }
            set { CheckSet(); _employeeID = value; }
        }

        private Employee _employee = null;
        [Relationship("764DF1D1-C624-4BC8-82EA-34B0B7F9BF8F")]
        public Employee Employee
        {
            get { CheckGet(); return _employee; }
        }

        private long? _officialID;
        [Field("F015DA0F-73A1-4FE8-8A58-321BFC466D68")]
        public long? OfficialID
        {
            get { CheckGet(); return _officialID; }
            set { CheckSet(); _officialID = value; }
        }

        private Official _official = null;
        [Relationship("CE5B7E80-F139-4B9A-B3D4-111A7090E22D")]
        public Official Official
        {
            get { CheckGet(); return _official; }
        }

        private bool _allowSetup;
        [Field("2399F922-5B99-448B-B267-1F80AEE63545")]
        [SecurityOption]
        public bool AllowSetup
        {
            get { CheckGet(); return _allowSetup; }
            set { CheckSet(); _allowSetup = value; }
        }

        private bool _allowLeasingManagement;
        [Field("A3F3BD56-75DA-4005-9382-7C6CAD304BC2")]
        [SecurityOption]
        public bool AllowLeasingManagement
        {
            get { CheckGet(); return _allowLeasingManagement; }
            set { CheckSet(); _allowLeasingManagement = value; }
        }

        private bool _isYardmaster;
        [Field("56E160CE-5DFB-43B2-8A1E-5761B53EC88C")]
        [SecurityOption]
        // API-Company/Employee/GetAllForCompany and API-Gov/Official/GetAllForGovernment uses string representation of this
        public bool IsYardmaster
        {
            get { CheckGet(); return _isYardmaster; }
            set { CheckSet(); _isYardmaster = value; }
        }

        private bool _isTrainCrew;
        [Field("D7503767-B6AB-4CAD-BDE1-558F506AA37A")]
        [SecurityOption]
        // API-Company/Employee/GetAllForCompany and API-Gov/Official/GetAllForGovernment uses string representation of this
        public bool IsTrainCrew
        {
            get { CheckGet(); return _isTrainCrew; }
            set { CheckSet(); _isTrainCrew = value; }
        }

        private bool _allowLoadUnload;
        [Field("EA854F49-2761-4D4E-9E72-F106CCC783EB")]
        [SecurityOption]
        public bool AllowLoadUnload
        {
            get { CheckGet(); return _allowLoadUnload; }
            set { CheckSet(); _allowLoadUnload = value; }
        }

        [AttributeUsage(AttributeTargets.Property)]
        private class SecurityOptionAttribute : Attribute
        {

        }

        private static List<string> _securityFields;
        public static List<string> SecurityFields
        {
            get
            {
                if (_securityFields == null)
                {
                    _securityFields = new List<string>();
                    foreach(PropertyInfo info in typeof(FleetSecurity).GetProperties().Where(i => i.GetCustomAttribute<SecurityOptionAttribute>() != null))
                    {
                        _securityFields.Add(info.Name);
                    }
                }

                return _securityFields;
            }
        }
    }
}

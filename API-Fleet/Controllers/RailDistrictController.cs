using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Common;
using API.Common.Attributes;
using API_Fleet.Extensions;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Utility;
using WebModels.fleet;

namespace API_Fleet.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess(new[] { "gov", "company" })]
    public class RailDistrictController : DataObjectController<RailDistrict>
    {
        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<RailDistrict>(rd => new List<object>()
        {
            rd.RailDistrictID,
            rd.Name,
            rd.CompanyIDOperator,
            rd.CompanyOperator.CompanyID,
            rd.CompanyOperator.Name,
            rd.GovernmentIDOperator,
            rd.GovernmentOperator.GovernmentID,
            rd.GovernmentOperator.Name,
            rd.Tracks.First().TrackID,
            rd.Tracks.First().Name,
            rd.Tracks.First().CompanyIDOwner,
            rd.Tracks.First().CompanyOwner.CompanyID,
            rd.Tracks.First().CompanyOwner.Name,
            rd.Tracks.First().GovernmentIDOwner,
            rd.Tracks.First().GovernmentOwner.GovernmentID,
            rd.Tracks.First().GovernmentOwner.Name
        });

        public RailDistrictController() : base()
        {
            PutSecurityCheck += OwnerOnlySecurityCheck;
            DeleteSecurityCheck += OwnerOnlySecurityCheck;
            PatchSecurityCheck += OwnerOnlySecurityCheck;
        }

        public override bool AllowGetAll => true;

        private void OwnerOnlySecurityCheck(object sender, SecurityCheckEventArgs e)
        {
            RailDistrict railDistrict = DataObject.GetReadOnlyByPrimaryKey<RailDistrict>(e.ObjectID, e.Transaction, FieldPathUtility.CreateFieldPathsAsList<RailDistrict>(rd => new List<object>()
            {
                rd.CompanyIDOperator,
                rd.GovernmentIDOperator
            }));

            e.IsValid &= railDistrict.GovernmentIDOperator == this.GovernmentID() && railDistrict.CompanyIDOperator == this.CompanyID();
        }
    }
}
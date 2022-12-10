using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
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
    public class TrackController : DataObjectController<Track>
    {
        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<Track>(t => new List<object>()
        {
            t.TrackID,
            t.Name,
            t.Length,
            t.CompanyIDOwner,
            t.CompanyOwner.CompanyID,
            t.CompanyOwner.Name,
            t.GovernmentOwner.GovernmentID,
            t.GovernmentOwner.Name,
            t.RailDistrictID,
            t.RailDistrict.RailDistrictID,
            t.RailDistrict.Name,
            t.RailDistrict.CompanyIDOperator,
            t.RailDistrict.CompanyOperator.CompanyID,
            t.RailDistrict.CompanyOperator.Name,
            t.RailDistrict.GovernmentIDOperator,
            t.RailDistrict.GovernmentOperator.GovernmentID,
            t.RailDistrict.GovernmentOperator.Name
        });

        public override bool AllowGetAll => true;

        public TrackController() : base()
        {
            PutSecurityCheck += OwnerOnlySecurityCheck;
            DeleteSecurityCheck += OwnerOnlySecurityCheck;
        }

        private void OwnerOnlySecurityCheck(object sender, SecurityCheckEventArgs e)
        {
            Track track = DataObject.GetReadOnlyByPrimaryKey<Track>(e.ObjectID, e.Transaction, FieldPathUtility.CreateFieldPathsAsList<Track>(t => new List<object>()
            {
                t.CompanyIDOwner,
                t.GovernmentIDOwner
            }));

            e.IsValid &= (track.CompanyIDOwner == this.CompanyID() && track.GovernmentIDOwner == this.GovernmentID()) || (track.RailDistrict.CompanyIDOperator == this.CompanyID() && track.RailDistrict.GovernmentIDOperator == this.GovernmentID());
        }

        public override async Task<IHttpActionResult> Patch(PatchData patchData)
        {
            Track track = DataObject.GetReadOnlyByPrimaryKey<Track>(patchData.PrimaryKey, null, FieldPathUtility.CreateFieldPathsAsList<Track>(t => new List<object>()
            {
                t.CompanyIDOwner,
                t.GovernmentIDOwner,
                t.RailDistrict.CompanyIDOperator,
                t.RailDistrict.GovernmentIDOperator
            }));

            if (track == null)
            {
                return NotFound();
            }

            long? currentCompanyID = this.CompanyID();
            long? currentGovernmentID = this.GovernmentID();

            if (track.CompanyIDOwner != currentCompanyID || track.GovernmentIDOwner != currentGovernmentID)
            {
                // The only allowable values to change is the RailDistrict
                // If this has a RailDistrict, check to make sure that only the RailDistrict's operator is making changes
                if ((track.RailDistrict?.CompanyIDOperator == null && track.RailDistrict?.GovernmentIDOperator == null) ||
                    (track.RailDistrict?.CompanyIDOperator == currentCompanyID && track.RailDistrict?.GovernmentIDOperator == currentGovernmentID))
                {
                    patchData.Values = patchData.Values.Where(kvp => kvp.Key == nameof(Track.RailDistrictID)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                }
                else
                {
                    return Unauthorized();
                }
            }

            return await base.Patch(patchData);
        }
    }
}
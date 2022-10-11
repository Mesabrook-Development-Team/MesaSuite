using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using API.Common.Extensions;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using WebModels.company;
using WebModels.fleet;
using WebModels.gov;

namespace API_Fleet.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess(new[] { "gov", "company" })]
    public class RailcarController : DataObjectController<Railcar>
    {
        public override IEnumerable<string> DefaultRetrievedFields => new[]
        {
            nameof(Railcar.RailcarID),
            nameof(Railcar.RailcarModelID),
            $"{nameof(Railcar.RailcarModel)}.{nameof(RailcarModel.RailcarModelID)}",
            $"{nameof(Railcar.RailcarModel)}.{nameof(RailcarModel.Name)}",
            nameof(Railcar.CompanyIDOwner),
            $"{nameof(Railcar.CompanyOwner)}.{nameof(Company.CompanyID)}",
            $"{nameof(Railcar.CompanyOwner)}.{nameof(Company.Name)}",
            nameof(Railcar.GovernmentIDOwner),
            $"{nameof(Railcar.GovernmentOwner)}.{nameof(Government.GovernmentID)}",
            $"{nameof(Railcar.GovernmentOwner)}.{nameof(Government.Name)}",
            nameof(Railcar.CompanyIDPossessor),
            $"{nameof(Railcar.CompanyPossessor)}.{nameof(Company.CompanyID)}",
            $"{nameof(Railcar.CompanyPossessor)}.{nameof(Company.Name)}",
            nameof(Railcar.GovernmentIDPossessor),
            $"{nameof(Railcar.GovernmentPossessor)}.{nameof(Government.GovernmentID)}",
            $"{nameof(Railcar.GovernmentPossessor)}.{nameof(Government.Name)}",
            $"{nameof(Railcar.CompanyLeasedTo)}.{nameof(Company.CompanyID)}",
            $"{nameof(Railcar.CompanyLeasedTo)}.{nameof(Company.Name)}",
            $"{nameof(Railcar.GovernmentLeasedTo)}.{nameof(Government.GovernmentID)}",
            $"{nameof(Railcar.GovernmentLeasedTo)}.{nameof(Government.Name)}",
            nameof(Railcar.ReportingMark),
            nameof(Railcar.ReportingNumber)
        };

        public override bool AllowGetAll => true;

        public async Task<IEnumerable<Railcar>> GetByModel(long? id)
        {
            return new Search<Railcar>(new LongSearchCondition<Railcar>()
            {
                Field = nameof(Railcar.RailcarModelID),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = id
            }).GetReadOnlyReader(null, await FieldsToRetrieve());
        }

        public IHttpActionResult GetImage(long? id)
        {
            Railcar railcar = DataObject.GetReadOnlyByPrimaryKey<Railcar>(id, null, new[] { "ImageOverride", "RailcarModel.Image" });
            if (railcar == null)
            {
                return NotFound();
            }

            return Ok(railcar.ImageOverride ?? railcar.RailcarModel.Image);
        }

        [HttpPut]
        public IHttpActionResult UpdateImage(UpdateImageParameter updateImageParameter)
        {
            Railcar model = DataObject.GetEditableByPrimaryKey<Railcar>(updateImageParameter.railcarID, null, null);
            if (model == null)
            {
                return NotFound();
            }

            model.ImageOverride = updateImageParameter.image;
            if (!model.Save())
            {
                return model.HandleFailedValidation(this);
            }

            return Ok();
        }

        public class UpdateImageParameter
        {
            public long railcarID { get; set; }
            public byte[] image { get; set; }
        }
    }
}
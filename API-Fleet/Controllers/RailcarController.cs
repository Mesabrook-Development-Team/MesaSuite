using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using API.Common.Extensions;
using API_Fleet.Extensions;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using WebModels.company;
using WebModels.fleet;
using WebModels.gov;
using WebModels.mesasys;

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
            $"{nameof(Railcar.RailcarModel)}.{nameof(RailcarModel.Type)}",
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
            $"{nameof(Railcar.RailLocation)}.{nameof(RailLocation.TrackID)}",
            $"{nameof(Railcar.RailLocation)}.{nameof(RailLocation.Track)}.{nameof(Track.TrackID)}",
            $"{nameof(Railcar.RailLocation)}.{nameof(RailLocation.Track)}.{nameof(Track.Name)}",
            $"{nameof(Locomotive.RailLocation)}.{nameof(RailLocation.Track)}.{nameof(Track.RailDistrictID)}",
            $"{nameof(Locomotive.RailLocation)}.{nameof(RailLocation.Track)}.{nameof(Track.RailDistrict)}.{nameof(RailDistrict.RailDistrictID)}",
            $"{nameof(Locomotive.RailLocation)}.{nameof(RailLocation.Track)}.{nameof(Track.RailDistrict)}.{nameof(RailDistrict.Name)}",
            $"{nameof(Railcar.RailLocation)}.{nameof(RailLocation.TrainID)}",
            $"{nameof(Railcar.RailLocation)}.{nameof(RailLocation.Train)}.{nameof(Train.TrainID)}",
            $"{nameof(Railcar.RailLocation)}.{nameof(RailLocation.Train)}.{nameof(Train.TimeOnDuty)}",
            $"{nameof(Railcar.RailLocation)}.{nameof(RailLocation.Train)}.{nameof(Train.TrainSymbolID)}",
            $"{nameof(Railcar.RailLocation)}.{nameof(RailLocation.Train)}.{nameof(Train.TrainSymbol)}.{nameof(TrainSymbol.TrainSymbolID)}",
            $"{nameof(Railcar.RailLocation)}.{nameof(RailLocation.Train)}.{nameof(Train.TrainSymbol)}.{nameof(TrainSymbol.Name)}",
            $"{nameof(Railcar.RailcarLoads)}.{nameof(RailcarLoad.RailcarLoadID)}",
            $"{nameof(Railcar.RailcarLoads)}.{nameof(RailcarLoad.RailcarID)}",
            $"{nameof(Railcar.RailcarLoads)}.{nameof(RailcarLoad.ItemID)}",
            $"{nameof(Railcar.RailcarLoads)}.{nameof(RailcarLoad.Item)}.{nameof(Item.ItemID)}",
            $"{nameof(Railcar.RailcarLoads)}.{nameof(RailcarLoad.Item)}.{nameof(Item.Name)}",
            $"{nameof(Railcar.RailcarLoads)}.{nameof(RailcarLoad.Item)}.{nameof(Item.Image)}",
            $"{nameof(Railcar.RailcarLoads)}.{nameof(RailcarLoad.Quantity)}",
            nameof(Railcar.ReportingMark),
            nameof(Railcar.ReportingNumber),
            nameof(Railcar.HasOpenBid)
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

        [HttpGet]
        public async Task<IHttpActionResult> GetReleasedByTrack(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SearchConditionGroup group = new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<Railcar>()
                {
                    Field = FieldPathUtility.CreateFieldPathsAsList<Railcar>(r => new List<object>() { r.RailLocation.TrackID }).First(),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = id
                });

            if (this.CompanyID() != null)
            {
                group.SearchConditions.Add(new LongSearchCondition<Railcar>()
                {
                    Field = nameof(Railcar.CompanyIDPossessor),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = this.CompanyID()
                });
            }
            else if (this.GovernmentID() != null)
            {
                group.SearchConditions.Add(new LongSearchCondition<Railcar>()
                {
                    Field = nameof(Railcar.GovernmentIDPossessor),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = this.GovernmentID()
                });
            }
            else
            {
                return NotFound();
            }

            Search<Railcar> railcarSearch = new Search<Railcar>(group);

            return Ok(railcarSearch.GetReadOnlyReader(null, await FieldsToRetrieve()).ToList());
        }

        public class UpdateImageParameter
        {
            public long railcarID { get; set; }
            public byte[] image { get; set; }
        }
    }
}
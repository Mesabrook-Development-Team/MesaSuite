﻿using System.Collections.Generic;
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
    public class LocomotiveController : DataObjectController<Locomotive>
    {
        public override IEnumerable<string> DefaultRetrievedFields => new[]
        {
            nameof(Locomotive.LocomotiveID),
            nameof(Locomotive.LocomotiveModelID),
            $"{nameof(Locomotive.LocomotiveModel)}.{nameof(LocomotiveModel.LocomotiveModelID)}",
            $"{nameof(Locomotive.LocomotiveModel)}.{nameof(LocomotiveModel.Name)}",
            nameof(Locomotive.CompanyIDOwner),
            $"{nameof(Locomotive.CompanyOwner)}.{nameof(Company.CompanyID)}",
            $"{nameof(Locomotive.CompanyOwner)}.{nameof(Company.Name)}",
            nameof(Locomotive.GovernmentIDOwner),
            $"{nameof(Locomotive.GovernmentOwner)}.{nameof(Government.GovernmentID)}",
            $"{nameof(Locomotive.GovernmentOwner)}.{nameof(Government.Name)}",
            nameof(Locomotive.CompanyIDPossessor),
            $"{nameof(Locomotive.CompanyPossessor)}.{nameof(Company.CompanyID)}",
            $"{nameof(Locomotive.CompanyPossessor)}.{nameof(Company.Name)}",
            nameof(Locomotive.GovernmentIDPossessor),
            $"{nameof(Locomotive.GovernmentPossessor)}.{nameof(Government.GovernmentID)}",
            $"{nameof(Locomotive.GovernmentPossessor)}.{nameof(Government.Name)}",
            $"{nameof(Locomotive.CompanyLeasedTo)}.{nameof(Company.CompanyID)}",
            $"{nameof(Locomotive.CompanyLeasedTo)}.{nameof(Company.Name)}",
            $"{nameof(Locomotive.GovernmentLeasedTo)}.{nameof(Government.GovernmentID)}",
            $"{nameof(Locomotive.GovernmentLeasedTo)}.{nameof(Government.Name)}",
            nameof(Locomotive.ReportingMark),
            nameof(Locomotive.ReportingNumber),
            nameof(Locomotive.HasOpenBid)
        };

        public override bool AllowGetAll => true;

        public async Task<IEnumerable<Locomotive>> GetByModel(long? id)
        {
            return new Search<Locomotive>(new LongSearchCondition<Locomotive>()
            {
                Field = nameof(Locomotive.LocomotiveModelID),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = id
            }).GetReadOnlyReader(null, await FieldsToRetrieve());
        }

        public IHttpActionResult GetImage(long? id)
        {
            Locomotive locomotive = DataObject.GetReadOnlyByPrimaryKey<Locomotive>(id, null, new[] { "ImageOverride", "LocomotiveModel.Image" });
            if (locomotive == null)
            {
                return NotFound();
            }

            return Ok(locomotive.ImageOverride ?? locomotive.LocomotiveModel.Image);
        }

        [HttpPut]
        public IHttpActionResult UpdateImage(UpdateImageParameter updateImageParameter)
        {
            Locomotive model = DataObject.GetEditableByPrimaryKey<Locomotive>(updateImageParameter.locomotiveID, null, null);
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
            public long locomotiveID { get; set; }
            public byte[] image { get; set; }
        }
    }
}
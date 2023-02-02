using System.Collections.Generic;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using API.Common.Extensions;
using ClussPro.ObjectBasedFramework;
using WebModels.fleet;

namespace API_Fleet.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess(new [] { "gov", "company" })]
    public class LocomotiveModelController : DataObjectController<LocomotiveModel>
    {
        public override IEnumerable<string> DefaultRetrievedFields => new HashSet<string>()
        {
            nameof(LocomotiveModel.LocomotiveModelID),
            nameof(LocomotiveModel.Name),
            nameof(LocomotiveModel.Length),
            nameof(LocomotiveModel.FuelCapacity),
            nameof(LocomotiveModel.WaterCapacity),
            nameof(LocomotiveModel.IsSteamPowered)
        };

        public override bool AllowGetAll => true;

        [HttpPut]
        public IHttpActionResult UpdateImage(UpdateImageParameter updateImageParameter)
        {
            LocomotiveModel model = DataObject.GetEditableByPrimaryKey<LocomotiveModel>(updateImageParameter.locomotiveModelID, null, null);
            if (model == null)
            {
                return NotFound();
            }

            model.Image = updateImageParameter.image;
            if (!model.Save())
            {
                return model.HandleFailedValidation(this);
            }

            return Ok();
        }

        [HttpGet]
        public byte[] GetImage(long? id)
        {
            return DataObject.GetReadOnlyByPrimaryKey<LocomotiveModel>(id, null, new[] { nameof(LocomotiveModel.Image) })?.Image;
        }

        public class UpdateImageParameter
        {
            public long? locomotiveModelID { get; set; }
            public byte[] image { get; set; }
        }
    }
}
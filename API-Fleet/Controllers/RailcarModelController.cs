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
    [ProgramAccess(new[] { "gov", "company" })]
    public class RailcarModelController : DataObjectController<RailcarModel>
    {
        public override IEnumerable<string> DefaultRetrievedFields => new[]
        {
            nameof(RailcarModel.RailcarModelID),
            nameof(RailcarModel.Name),
            nameof(RailcarModel.Length),
            nameof(RailcarModel.CargoCapacity),
            nameof(RailcarModel.Type)
        };

        public override bool AllowGetAll => true;

        public byte[] GetImage(long? id)
        {
            return DataObject.GetReadOnlyByPrimaryKey<RailcarModel>(id, null, new[] { nameof(RailcarModel.Image) })?.Image;
        }

        [HttpPut]
        public IHttpActionResult UpdateImage(UpdateImageParameter updateImageParameter)
        {
            RailcarModel model = DataObject.GetEditableByPrimaryKey<RailcarModel>(updateImageParameter.railcarModelID, null, null);
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

        public class UpdateImageParameter
        {
            public long? railcarModelID { get; set; }
            public byte[] image { get; set; }
        }
    }
}
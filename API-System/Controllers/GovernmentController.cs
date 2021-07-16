using API_System.Attributes;
using API_System.Extensions;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema;
using OAuth.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebModels.gov;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess]
    public class GovernmentController : ApiController
    {
        [HttpGet]
        public List<Government> GetGovernments()
        {
            List<string> fields = Schema.GetSchemaObject<Government>().GetFields().Select(f => f.FieldName).ToList();
            return new Search<Government>().GetReadOnlyReader(null, fields).ToList();
        }

        [HttpGet]
        public Government GetGovernment(long id)
        {
            List<string> fields = Schema.GetSchemaObject<Government>().GetFields().Select(f => f.FieldName).ToList();
            return DataObject.GetReadOnlyByPrimaryKey<Government>(id, null, fields);
        }

        [HttpGet]
        public List<Official> GetOfficialsForGovernment(long id)
        {
            List<string> fields = Schema.GetSchemaObject<Official>().GetFields().Select(f => $"Officials.{f.FieldName}").ToList();
            return DataObject.GetReadOnlyByPrimaryKey<Government>(id, null, fields).Officials.ToList();
        }

        [HttpGet]
        public Official GetOfficial(long id)
        {
            List<string> fields = Schema.GetSchemaObject<Official>().GetFields().Select(f => f.FieldName).ToList();
            return DataObject.GetReadOnlyByPrimaryKey<Official>(id, null, fields);
        }

        [HttpPost]
        public IHttpActionResult PostGovernment(Government government)
        {
            if (government.GovernmentID != null && government.GovernmentID != 0)
            {
                return BadRequest("Updates are not allowed with this method");
            }

            if (!government.Save())
            {
                government.HandleFailedValidation(this);
            }

            return Created("GetGovernment?id=" + government.GovernmentID, government);
        }

        [HttpPost]
        public IHttpActionResult PostOfficial(Official official)
        {
            if (official.OfficialID != null && official.OfficialID != 0)
            {
                return BadRequest("Updates are not allowed with this method");
            }

            if (!official.Save())
            {
                official.HandleFailedValidation(this);
            }

            return Created("GetOfficial?id=" + official.OfficialID, official);
        }

        [HttpPut]
        public IHttpActionResult PutGovernment(Government government)
        {
            if (government.GovernmentID == null || government.GovernmentID == 0)
            {
                return NotFound();
            }

            Government dbGovernment = DataObject.GetEditableByPrimaryKey<Government>(government.GovernmentID, null, Enumerable.Empty<string>());
            government.Copy(dbGovernment);

            if (!dbGovernment.Save())
            {
                return dbGovernment.HandleFailedValidation(this);
            }

            return Ok(dbGovernment);
        }

        [HttpPut]
        public IHttpActionResult PutOfficial(Official official)
        {
            if (official.OfficialID == null || official.OfficialID == 0)
            {
                return NotFound();
            }

            Official dbOfficial = DataObject.GetEditableByPrimaryKey<Official>(official.OfficialID, null, Enumerable.Empty<string>());
            official.Copy(dbOfficial);

            if (!dbOfficial.Save())
            {
                return dbOfficial.HandleFailedValidation(this);
            }

            return Ok(dbOfficial);
        }

        [HttpDelete]
        public IHttpActionResult DeleteGovernment(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Government government = DataObject.GetEditableByPrimaryKey<Government>(id, null, Enumerable.Empty<string>());
            if (!government.Delete())
            {
                return government.HandleFailedValidation(this);
            }

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteOfficial(long id)
        {
            Official official = DataObject.GetEditableByPrimaryKey<Official>(id, null, null);
            if (official == null)
            {
                return NotFound();
            }

            if (!official.Delete())
            {
                return official.HandleFailedValidation(this);
            }

            return Ok();
        }
    }
}

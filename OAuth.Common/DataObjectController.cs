using API.Common.Extensions;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace API.Common
{
    public class DataObjectController<TDataObject> : ApiController where TDataObject : DataObject
    {
        public virtual bool AllowGetAll { get; }

        [HttpGet]
        public virtual TDataObject Get(long id)
        {
            List<string> fields = Schema.GetSchemaObject<TDataObject>().GetFields().Select(f => f.FieldName).ToList();
            return DataObject.GetReadOnlyByPrimaryKey<TDataObject>(id, null, fields);
        }

        [HttpGet]
        public virtual IHttpActionResult GetAll()
        {
            if (!AllowGetAll)
            {
                return NotFound();
            }

            List<string> fields = Schema.GetSchemaObject<TDataObject>().GetFields().Select(f => f.FieldName).ToList();
            return Ok(new Search<TDataObject>().GetReadOnlyReader(null, fields).ToList());
        }

        [HttpPost]
        public virtual IHttpActionResult Post(TDataObject dataObject)
        {
            long? primaryKeyValue = dataObject.PrimaryKeyField.GetValue(dataObject) as long?;
            
            if (primaryKeyValue != null && primaryKeyValue != 0)
            {
                return BadRequest("Updates are not allowed with this method");
            }

            if (!dataObject.Save())
            {
                return dataObject.HandleFailedValidation(this);
            }

            return Created("Get?id=" + dataObject.PrimaryKeyField.GetValue(dataObject), dataObject);
        }

        [HttpPut]
        public virtual IHttpActionResult Put(TDataObject dataObject)
        {
            long? primaryKeyValue = dataObject.PrimaryKeyField.GetValue(dataObject) as long?;

            if (primaryKeyValue == null || primaryKeyValue == 0)
            {
                return NotFound();
            }

            TDataObject dbDataObject = DataObject.GetEditableByPrimaryKey<TDataObject>(primaryKeyValue, null, null);
            dataObject.Copy(dbDataObject);

            if (!dbDataObject.Save())
            {
                return dbDataObject.HandleFailedValidation(this);
            }

            return Ok(dbDataObject);
        }

        [HttpDelete]
        public virtual IHttpActionResult Delete(long id)
        {
            TDataObject dataObject = DataObject.GetEditableByPrimaryKey<TDataObject>(id, null, null);

            if (dataObject == null)
            {
                return NotFound();
            }

            if (!dataObject.Delete())
            {
                return dataObject.HandleFailedValidation(this);
            }

            return Ok();
        }

        [HttpPatch]
        public virtual IHttpActionResult Patch(PatchData patchData)
        {
            TDataObject dataObject = DataObject.GetEditableByPrimaryKey<TDataObject>(patchData.PrimaryKey, null, Enumerable.Empty<string>());
            if (dataObject == null)
            {
                return NotFound();
            }

            dataObject.PatchData(patchData.Method, patchData.Values);

            if (!dataObject.Save())
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}

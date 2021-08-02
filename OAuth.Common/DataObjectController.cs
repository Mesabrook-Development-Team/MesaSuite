using API.Common.Extensions;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace API.Common
{
    public abstract class DataObjectController<TDataObject> : ApiController where TDataObject : DataObject
    {
        public abstract IEnumerable<string> AllowedFields { get; }

        public virtual bool AllowGetAll { get; }

        [HttpGet]
        public virtual TDataObject Get(long id)
        {
            return DataObject.GetReadOnlyByPrimaryKey<TDataObject>(id, null, AllowedFields);
        }

        [HttpGet]
        public virtual IHttpActionResult GetAll()
        {
            if (!AllowGetAll)
            {
                return NotFound();
            }

            return Ok(new Search<TDataObject>().GetReadOnlyReader(null, AllowedFields).ToList());
        }

        [HttpPost]
        public virtual IHttpActionResult Post(TDataObject dataObject)
        {
            object primaryKeyValue = null;
            if (dataObject.PrimaryKeyField.ReturnType == typeof(long?))
            {
                primaryKeyValue = dataObject.PrimaryKeyField.GetValue(dataObject) as long?;
            }
            else if (dataObject.PrimaryKeyField.ReturnType == typeof(int?))
            {
                primaryKeyValue = dataObject.PrimaryKeyField.GetValue(dataObject) as int?;
            }
            
            if (primaryKeyValue != null && !primaryKeyValue.Equals(0))
            {
                return BadRequest("Updates are not allowed with this method");
            }

            foreach(Field field in Schema.GetSchemaObject<TDataObject>().GetFields())
            {
                if (!AllowedFields.Contains(field.FieldName))
                {
                    field.SetValue(dataObject, field.ReturnType.IsValueType ? Activator.CreateInstance(field.ReturnType) : null);
                }
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
            object primaryKeyValue = null;
            if (dataObject.PrimaryKeyField.ReturnType == typeof(long?))
            {
                primaryKeyValue = dataObject.PrimaryKeyField.GetValue(dataObject) as long?;
            }
            else if (dataObject.PrimaryKeyField.ReturnType == typeof(int?))
            {
                primaryKeyValue = dataObject.PrimaryKeyField.GetValue(dataObject) as int?;
            }

            if (primaryKeyValue != null && typeof(Nullable<>).IsAssignableFrom(primaryKeyValue.GetType()))
            {
                Type underlyingType = Nullable.GetUnderlyingType(primaryKeyValue.GetType());
                primaryKeyValue = Convert.ChangeType(primaryKeyValue, underlyingType);
            }

            TDataObject dbDataObject = DataObject.GetEditableByPrimaryKey<TDataObject>(primaryKeyValue != null ? (long)Convert.ChangeType(primaryKeyValue, typeof(long)) : 0, null, null);
            SchemaObject schemaObject = Schema.GetSchemaObject<TDataObject>();
            foreach(Field field in schemaObject.GetFields().Where(f => f != schemaObject.PrimaryKeyField))
            {
                if (!AllowedFields.Contains(field.FieldName))
                {
                    continue;
                }

                field.SetValue(dbDataObject, field.GetValue(dataObject));
            }

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

            dataObject.PatchData(patchData.Method, patchData.Values.Where(kvp => AllowedFields.Contains(kvp.Key)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value));

            if (!dataObject.Save())
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}

using API.Common.Extensions;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace API.Common
{
    public abstract class DataObjectController<TDataObject> : ApiController where TDataObject : DataObject
    {
        public abstract IEnumerable<string> DefaultRetrievedFields { get; }

        protected virtual IEnumerable<string> RequestableFields => Enumerable.Empty<string>();

        private IEnumerable<string> retrieveFields = null;
        protected async Task<IEnumerable<string>> FieldsToRetrieve()
        {
            if (retrieveFields != null)
            {
                return retrieveFields;
            }

            if (RequestableFields == null || !RequestableFields.Any())
            {
                return DefaultRetrievedFields;
            }

            (await Request.Content.ReadAsStreamAsync()).Seek(0, System.IO.SeekOrigin.Begin);
            string body = await Request.Content.ReadAsStringAsync();

            var requestFields = new { requestfields = new string[0] };
            requestFields = JsonConvert.DeserializeAnonymousType(body, requestFields);

            if (requestFields?.requestfields == null || !requestFields.requestfields.Any())
            {
                NameValueCollection queryString = HttpUtility.ParseQueryString(Request.RequestUri.Query);
                if (queryString.AllKeys.Contains("requestField", StringComparer.OrdinalIgnoreCase))
                {
                    requestFields = new { requestfields = queryString.GetValues("requestField") };
                }
                else
                {
                    return DefaultRetrievedFields;
                }
            }

            retrieveFields = DefaultRetrievedFields.Concat(RequestableFields).Intersect(requestFields.requestfields);
            return retrieveFields;
        }

        public virtual bool AllowGetAll { get; }

        public virtual SearchCondition GetBaseSearchCondition() { return null; }

        [HttpGet]
        public async virtual Task<TDataObject> Get(long id)
        {
            SchemaObject schemaObject = Schema.GetSchemaObject<TDataObject>();

            ISearchCondition searchCondition = new LongSearchCondition<TDataObject>()
            {
                Field = schemaObject.PrimaryKeyField.FieldName,
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = id
            };

            SearchCondition baseCondition = GetBaseSearchCondition();
            if (baseCondition != null)
            {
                searchCondition = new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                    searchCondition,
                    baseCondition);
            }

            return new Search<TDataObject>(searchCondition).GetReadOnly(null, await FieldsToRetrieve());
        }

        [HttpGet]
        public async virtual Task<IHttpActionResult> GetAll()
        {
            if (!AllowGetAll)
            {
                return NotFound();
            }

            return Ok(new Search<TDataObject>(GetBaseSearchCondition()).GetReadOnlyReader(null, await FieldsToRetrieve()).ToList());
        }

        [HttpPost]
        public async virtual Task<IHttpActionResult> Post(TDataObject dataObject)
        {
            long? primaryKeyValue = ConvertUtility.GetNullableLong(dataObject.PrimaryKeyField.GetValue(dataObject));
            
            if (primaryKeyValue != null && primaryKeyValue != 0)
            {
                return BadRequest("Updates are not allowed with this method");
            }

            foreach(Field field in Schema.GetSchemaObject<TDataObject>().GetFields().Where(f => !f.HasOperation))
            {
                if (!(await FieldsToRetrieve()).Contains(field.FieldName))
                {
                    field.SetValue(dataObject, field.ReturnType.IsValueType ? Activator.CreateInstance(field.ReturnType) : null);
                }
            }

            if (!dataObject.Save())
            {
                return dataObject.HandleFailedValidation(this);
            }

            return Created("Get?id=" + dataObject.PrimaryKeyField.GetValue(dataObject), DataObject.GetReadOnlyByPrimaryKey<TDataObject>(ConvertUtility.GetNullableLong(dataObject.PrimaryKeyField.GetValue(dataObject)), null, await FieldsToRetrieve()));
        }

        [HttpPut]
        public async virtual Task<IHttpActionResult> Put(TDataObject dataObject)
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
            foreach(Field field in schemaObject.GetFields().Where(f => !f.HasOperation && f != schemaObject.PrimaryKeyField))
            {
                if (!(await FieldsToRetrieve()).Contains(field.FieldName))
                {
                    continue;
                }

                field.SetValue(dbDataObject, field.GetValue(dataObject));
            }

            if (!dbDataObject.Save())
            {
                return dbDataObject.HandleFailedValidation(this);
            }

            return Ok(DataObject.GetReadOnlyByPrimaryKey<TDataObject>(ConvertUtility.GetNullableLong(dbDataObject.PrimaryKeyField.GetValue(dbDataObject)), null, await FieldsToRetrieve()));
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
        public async virtual Task<IHttpActionResult> Patch(PatchData patchData)
        {
            TDataObject dataObject = DataObject.GetEditableByPrimaryKey<TDataObject>(patchData.PrimaryKey, null, Enumerable.Empty<string>());
            if (dataObject == null)
            {
                return NotFound();
            }

            IEnumerable<string> fieldsToRetrieve = await FieldsToRetrieve();
            dataObject.PatchData(patchData.Method, patchData.Values.Where(kvp => fieldsToRetrieve.Contains(kvp.Key)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value));

            if (!dataObject.Save())
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}

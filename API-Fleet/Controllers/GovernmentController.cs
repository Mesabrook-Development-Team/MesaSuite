﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using WebModels.gov;

namespace API_Fleet.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess(new[] { "gov", "company" })]
    public class GovernmentController : ApiController
    {
        private static readonly List<string> GovernmentFields = new List<string>()
        {
            nameof(Government.GovernmentID),
            nameof(Government.Name)
        };

        [HttpGet]
        public List<Government> GetAll()
        {
            return new Search<Government>().GetReadOnlyReader(null, GovernmentFields).ToList();
        }

        [HttpGet]
        public Government Get(long? id)
        {
            return DataObject.GetReadOnlyByPrimaryKey<Government>(id, null, GovernmentFields);
        }
    }
}
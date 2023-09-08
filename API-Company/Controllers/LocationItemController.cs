﻿using API.Common;
using API.Common.Attributes;
using API_Company.App_Code;
using API_Company.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using ClussPro.ObjectBasedFramework.Validation;
using System.Collections.Generic;
using System.Linq;
using WebModels.company;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("company")]
    [LocationAccess(RequiredPermissions = new[] { nameof(LocationEmployee.ManagePrices) })]
    public class LocationItemController : DataObjectController<LocationItem>
    {
        private long CompanyID => long.Parse(Request.Headers.GetValues("CompanyID").First());
        private long LocationID => long.Parse(Request.Headers.GetValues("LocationID").First());

        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<LocationItem>(li => new List<object>()
        {
            li.LocationItemID,
            li.LocationID,
            li.ItemID,
            li.BasePrice,
            li.Quantity,
            li.Item.ItemID,
            li.Item.Name,
            li.Item.Image
        });

        public override ISearchCondition GetBaseSearchCondition()
        {
            return new LongSearchCondition<LocationItem>()
            {
                Field = nameof(LocationItem.LocationID),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = LocationID
            };
        }

        public override bool AllowGetAll => true;
    }
}

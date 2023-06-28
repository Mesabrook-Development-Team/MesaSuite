using System.Collections.Generic;
using System.Linq;
using API.Common;
using API.Common.Attributes;
using API_Company.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using WebModels.company;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [LocationAccess(RequiredPermissions = new[] { nameof(LocationEmployee.ManageRegisters) })]
    public class RegisterController : DataObjectController<Register>
    {
        private long LocationID => long.Parse(Request.Headers.GetValues("LocationID").First());

        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<Register>(r => new List<object>()
        {
            r.RegisterID,
            r.LocationID,
            r.Name,
            r.Identifier,
            r.CurrentStatus.RegisterStatusID,
            r.CurrentStatus.ChangeTime,
            r.CurrentStatus.Status,
            r.CurrentStatus.Initiator
        });

        public override bool AllowGetAll => true;

        public override ISearchCondition GetBaseSearchCondition()
        {
            return new LongSearchCondition<Register>()
            {
                Field = nameof(Register.LocationID),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = LocationID
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Common;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework.Utility;
using WebModels.fleet;

namespace API_Fleet.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess(new[] { "company", "gov" })]
    public class TrainController : DataObjectController<Train>
    {
        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<Train>(t => new List<object>()
        {
            t.TrainID,
            t.TrainSymbolID,
            t.TrainSymbol.TrainSymbolID,
            t.TrainSymbol.Name,
            t.RailLocations.First().RailLocationID,
            t.RailLocations.First().TrainID,
            t.RailLocations.First().LocomotiveID,
            t.RailLocations.First().Locomotive.LocomotiveID,
            t.RailLocations.First().Locomotive.ReportingMark,
            t.RailLocations.First().Locomotive.ReportingNumber,
            t.RailLocations.First().Locomotive.
        })
    }
}
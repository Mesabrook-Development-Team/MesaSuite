using API.Common;
using API.Common.Attributes;
using API_Government.Attributes;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using WebModels.gov;

namespace API_Government.Controllers
{
    [MesabrookAuthorization]
    [GovernmentAccess(RequiredPermissions = new[] { nameof(Official.CanConfigureInterest) })]
    public class InterestConfigurationController : DataObjectController<InterestConfiguration>
    {
        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<InterestConfiguration>(ic => new List<object>()
        {
            ic.InterestConfigurationID,
            ic.RateGovernment,
            ic.WealthCapGovernment,
            ic.RateLocation,
            ic.WealthCapLocation,
            ic.NextInterestRun
        });

        [HttpGet]
        public async Task<InterestConfiguration> Get()
        {
            InterestConfiguration interestConfiguration = new Search<InterestConfiguration>().GetReadOnly(null, await FieldsToRetrieve());
            if (interestConfiguration == null)
            {
                interestConfiguration = DataObjectFactory.Create<InterestConfiguration>();
                interestConfiguration.RateGovernment = 0;
                interestConfiguration.WealthCapGovernment = 0;
                interestConfiguration.RateLocation = 0;
                interestConfiguration.WealthCapLocation = 0;
                interestConfiguration.NextInterestRun = DateTime.MaxValue;
                if (!interestConfiguration.Save())
                {
                    return null;
                }

                interestConfiguration = new Search<InterestConfiguration>().GetReadOnly(null, await FieldsToRetrieve());
            }

            return interestConfiguration;
        }

        [HttpGet]
        public async override Task<InterestConfiguration> Get(long id)
        {
            return await Get();
        }

        [HttpPost]
        public override Task<IHttpActionResult> Post(InterestConfiguration dataObject)
        {
            return Task.FromResult((IHttpActionResult)new StatusCodeResult(System.Net.HttpStatusCode.Forbidden, this));
        }

        [HttpDelete]
        public override IHttpActionResult Delete(long id)
        {
            return new StatusCodeResult(System.Net.HttpStatusCode.Forbidden, this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using API.Common.Extensions;
using API_Fleet.Extensions;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using WebModels.fleet;

namespace API_Fleet.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess(new[] { "gov", "company" })]
    public class LiveLoadSessionController : ApiController
    {
        private readonly List<string> RetrievedFields = FieldPathUtility.CreateFieldPathsAsList<LiveLoadSession>(lls => new List<object>()
        {
            lls.LiveLoad.TrainID,
            lls.LiveLoad.Train.TimeOnDuty,
            lls.LiveLoad.Train.TrainSymbol.Name,
            lls.LiveLoadSessionID,
            lls.LastHeartbeat
        });

        [HttpPost]
        public IHttpActionResult GenerateSession(GenerateSessionParam param)
        {
            Search<LiveLoad> liveLoadSearch = new Search<LiveLoad>(new StringSearchCondition<LiveLoad>()
            {
                Field = nameof(LiveLoad.Code),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = param.Code
            });

            List<string> fields = FieldPathUtility.CreateFieldPathsAsList<LiveLoad>(ll => new List<object>()
            {
                ll.LiveLoadID,
                ll.LiveLoadSessions.First().LiveLoadSessionID,
                ll.LiveLoadSessions.First().UserID
            });

            LiveLoad liveLoad = liveLoadSearch.GetReadOnly(null, fields);
            if (liveLoad == null)
            {
                return NotFound();
            }

            SecurityProfile securityProfile = (SecurityProfile)Request.Properties["SecurityProfile"];

            if (liveLoad.LiveLoadSessions != null && liveLoad.LiveLoadSessions.Any(lls => lls.UserID == securityProfile.UserID))
            {
                LiveLoadSession oldSession = DataObject.GetEditableByPrimaryKey<LiveLoadSession>(liveLoad.LiveLoadSessions.First(lls => lls.UserID == securityProfile.UserID).LiveLoadSessionID, null, null);
                oldSession.Delete();
            }

            LiveLoadSession session = DataObjectFactory.Create<LiveLoadSession>();
            session.LiveLoadID = liveLoad.LiveLoadID;
            session.UserID = securityProfile.UserID;
            session.CompanyID = this.CompanyID();
            session.GovernmentID = this.GovernmentID();
            session.LastHeartbeat = DateTime.Now;
            if (!session.Save())
            {
                return session.HandleFailedValidation(this);
            }

            return Ok(DataObject.GetReadOnlyByPrimaryKey<LiveLoadSession>(session.LiveLoadSessionID, null, RetrievedFields));
        }

        [HttpPut]
        public IHttpActionResult Heartbeat(HeartbeatParam param)
        {
            LiveLoadSession session = DataObject.GetEditableByPrimaryKey<LiveLoadSession>(param.SessionID, null, new[] { nameof(LiveLoadSession.IsSessionValid) });
            if (session == null || !session.IsSessionValid)
            {
                if (session != null && !session.IsSessionValid)
                {
                    session.Delete();
                }

                return BadRequest("Your session is missing or has expired. Please start your session again.");
            }

            SecurityProfile securityProfile = (SecurityProfile)Request.Properties["SecurityProfile"];
            if (securityProfile.UserID != session.UserID)
            {
                return Unauthorized();
            }

            session.LastHeartbeat = DateTime.Now;
            if (!session.Save())
            {
                return session.HandleFailedValidation(this);
            }

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(long? id)
        {
            SecurityProfile securityProfile = (SecurityProfile)Request.Properties["SecurityProfile"];

            LiveLoadSession session = DataObject.GetEditableByPrimaryKey<LiveLoadSession>(id, null, null);
            if (session == null)
            {
                return NotFound();
            }

            if (session.UserID != securityProfile.UserID)
            {
                return Unauthorized();
            }

            if (!session.Delete())
            {
                return session.HandleFailedValidation(this);
            }

            return Ok();
        }

        public struct GenerateSessionParam
        {
            public string Code { get; set; }
        }

        public struct HeartbeatParam
        {
            public long? SessionID { get; set; }
        }
    }
}
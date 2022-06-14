using API.Common;
using API.Common.Attributes;
using API_System.Models.security;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Extensions;
using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using WebModels.security;

namespace API_System.Controllers
{
    public class ProgramController : ApiController
    {
        [HttpGet]
        [MesabrookAuthorization]
        public List<string> GetCurrentPrograms()
        {
            SecurityProfile profile = Request.Properties["SecurityProfile"] as SecurityProfile;

            LDAPUser user = DataObject.GetReadOnlyByPrimaryKey<LDAPUser>(profile.UserID, null, new string[] { "UserPrograms.Program.Key" });
            return user.UserPrograms.Select(up => up.Program.Key).ToList();
        }

        [HttpGet]
        [MesabrookAuthorization]
        [ProgramAccess("system")]
        public List<Program> GetProgramKeys()
        {
            return new Search<Program>().GetReadOnlyReader(null, new string[] { "ProgramID", "Name", "Key" }).ToList();
        }

        [HttpGet]
        [MesabrookAuthorization]
        [ProgramAccess("system")]
        public List<Program> GetProgramsForUser(long? userid)
        {
            if (userid == null)
            {
                return null;
            }

            List<string> programFields = Schema.GetSchemaObject<Program>().GetFields().Select(f => $"UserPrograms.Program." + f.FieldName).ToList();
            LDAPUser user = DataObject.GetReadOnlyByPrimaryKey<LDAPUser>(userid, null, programFields);

            return user.UserPrograms.Select(up => up.Program).ToList();
        }

        [HttpPost]
        [MesabrookAuthorization]
        [ProgramAccess("system")]
        public IHttpActionResult SetProgramsForUser(SetProgramsForUserParam userPrograms)
        {
            long? userID = userPrograms.newlySelectedPrograms.First().UserID;

            if (userPrograms.newlySelectedPrograms.Any(up => up.UserID != userID))
            {
                return BadRequest("All User IDs must be the same.");
            }

            StringBuilder errorBuilder = new StringBuilder("The following errors occurred:");
            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
            {
                foreach(UserProgram userProgram in userPrograms.newlySelectedPrograms)
                {
                    if (!userProgram.Save(transaction))
                    {
                        foreach(Error error in userProgram.Errors)
                        {
                            errorBuilder.AppendLine(error.Message);
                        }
                    }
                }

                transaction.Commit();
            }

            if (userPrograms.newlySelectedPrograms.Any(up => up.Errors.Any()))
            {
                return BadRequest(errorBuilder.ToString());
            }

            return Ok();
        }

        public class SetProgramsForUserParam
        {
            public List<UserProgram> newlySelectedPrograms { get; set; } = new List<UserProgram>();
        }

        [HttpDelete]
        [MesabrookAuthorization]
        [ProgramAccess("system")]
        public IHttpActionResult DeleteProgramForUser(long? userid, long? programID)
        {
            Search<UserProgram> userProgramSearch = new Search<UserProgram>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<UserProgram>()
                {
                    Field = "UserID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = userid
                },
                new LongSearchCondition<UserProgram>()
                {
                    Field = "ProgramID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = programID
                }));

            UserProgram dbUserProgram = userProgramSearch.GetEditable();
            if (!dbUserProgram.Delete())
            {
                StringBuilder errorBuilder = new StringBuilder("The following errors occurred during delete:");
                foreach(Error error in dbUserProgram.Errors)
                {
                    errorBuilder.AppendLine(error.Message);
                }

                return BadRequest(errorBuilder.ToString());
            }

            return Ok();
        }

        [HttpGet]
        [MesabrookAuthorization]
        [ProgramAccess("system")]
        public Program GetProgram(long? programid)
        {
            return DataObject.GetEditableByPrimaryKey<Program>(programid, null, Enumerable.Empty<string>());
        }

        [HttpGet]
        [MesabrookAuthorization]
        [ProgramAccess("system")]
        public List<LDAPUser> GetUsersForProgram(long? programid)
        {
            List<string> fields = Schema.GetSchemaObject<LDAPUser>().GetFields().Select(f => $"UserPrograms.User.{f.FieldName}").ToList();

            Program program = DataObject.GetReadOnlyByPrimaryKey<Program>(programid, null, fields);

            return program?.UserPrograms.Select(up => up.User.As<LDAPUser>().PopulateActiveDirectoryInformation()).ToList();
        }
    }
}

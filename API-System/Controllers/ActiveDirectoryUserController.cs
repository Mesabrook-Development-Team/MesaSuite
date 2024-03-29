﻿using API.Common.Attributes;
using System.Collections.Generic;
using System.Web.Http;

namespace API_System.Controllers
{
    [ProgramAccess("system")]
    public class ActiveDirectoryUserController : ApiController
    {
        [HttpGet]
        [MesabrookAuthorization]
        public List<string> GetAllActiveDirectoryUsers()
        {
            return Models.security.LDAPUser.GetAllActiveDirectoryUsers();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace Demo.Controllers
{
    [RoutePrefix("v0/users")]
    public class UsersController : ApiController
    {
        [Route("")]
        [HttpGet]
        public string GetAllUsers()
        {
            var listUsers = new List<dynamic>
            {
                new
                {
                    Name = "wawa0210",
                    Gender = "M"
                }
            };

            return JsonConvert.SerializeObject(listUsers);
        }
    }
}

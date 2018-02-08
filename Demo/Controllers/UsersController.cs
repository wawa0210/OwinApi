using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using UserService;
using UserService.Application;

namespace Demo.Controllers
{
    [RoutePrefix("v0/users")]
    public class UsersController : ApiController
    {

        private readonly IUserService _userService;


        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }

        [Route("")]
        [HttpGet]
        public async Task<string> GetAllUsers()
        {
            return JsonConvert.SerializeObject(await _userService.GetUsersListAsync());
        }
    }
}

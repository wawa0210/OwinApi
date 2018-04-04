using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Newtonsoft.Json;
using UserService;
using UserService.Application;
using UserService.Commands;

namespace OwinApi.Controllers
{
    [RoutePrefix("v0/users")]
    public class UsersController : ApiController
    {

        public IUserService _userService { get; set; }

        public IMediator _mediator { get; set; }
        //public UsersController(IUserService userService)
        //{
        //    this._userService = userService;
        //}

        [Route("")]
        [HttpGet]
        public async Task<string> GetAllUsers()
        {
            return JsonConvert.SerializeObject(await _userService.GetUsersListAsync());
        }

        [Route("nameschange")]
        [HttpPost]
        public async Task<bool> ChangeUserName()
        {
            var model = new ChangeUserNameCommand(1314520, "wawa0210");
            var commandResult = await _mediator.Send(model);
            return commandResult;
        }
    }
}

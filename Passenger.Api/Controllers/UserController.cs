using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Services;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Settings;

namespace Passenger.Api.Controllers
{
    public class UserController : ApiControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService,
         ICommandDispatcher commandDispatcher, GeneralSettings settings): base(commandDispatcher)
        {
            _userService = userService;           
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetAsync(string email)      
        {
            var user = await _userService.GetAsync(email);
            if(user == null)
            {
                    return NotFound();
            }
            return Json(user);
        }
             
        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await CommandDispatcher.DispatchAsync(command);
            return CreatedAtAction($"users/{command.Email}", new Object());
        }         
    }
}

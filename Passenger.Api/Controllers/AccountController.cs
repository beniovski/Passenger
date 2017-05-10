using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.Services;

namespace Passenger.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly IJwtHandler _ijwtHandler;
        public AccountController(ICommandDispatcher commandDispatcher,IJwtHandler ijwtHandler )
        : base(commandDispatcher)
        {
            _ijwtHandler = ijwtHandler;
        }
        [HttpPut]
        [Route("token")]
        public async Task<IActionResult>Get()
        {
            var token = _ijwtHandler.CreateToken("user", "user");
            return Json(token);
        } 
        [HttpPut]
        [Authorize]
        [Route("auth")]
        public async Task<IActionResult>GetAuth()
        {
            return Content("auth");
        } 


        [HttpPut]
        [Route("password")]
        public async Task<IActionResult> Put([FromBody]ChangeUserPassword command)
        {
            await CommandDispatcher.DispatchAsync(command);
            return NoContent();
        }      
    }
}
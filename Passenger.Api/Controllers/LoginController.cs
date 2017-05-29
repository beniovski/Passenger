using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.Extensions;
using Passenger.Infrastructure.Services;

namespace Passenger.Api.Controllers
{
    public class LoginController : ApiControllerBase
    {
        private readonly IMemoryCache _cache;        
        
        public LoginController(ICommandDispatcher commandDispatcher, IMemoryCache memoryCache) : base(commandDispatcher)
        {
            _cache = memoryCache;
            
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Post([FromBody]Login command)
        {
            await CommandDispatcher.DispatchAsync(command);
            var jwt = _cache.GetJwt(command.Email);

            return Json(jwt);
        }   
    }
}
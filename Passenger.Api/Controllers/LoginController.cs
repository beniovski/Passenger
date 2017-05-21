using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.Extensions;

namespace Passenger.Api.Controllers
{
    public class LoginController : ApiControllerBase
    {
        private readonly IMemoryCache _cache;        
        
        public LoginController(ICommandDispatcher commandDispatcher, IMemoryCache memoryCache) : base(commandDispatcher)
        {
            _cache = memoryCache;
            
        }
        public async Task<IActionResult> Post([FromBody]Login command)
        {
            command.tokenId = Guid.NewGuid();
            await CommandDispatcher.DispatchAsync(command);
            var jwt = _cache.GetJwt(command.tokenId);
            return Json(jwt);
            
        }
    }
}
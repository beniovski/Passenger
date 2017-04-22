using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Driver;
using Passenger.Infrastructure.Services;

namespace Passenger.Api.Controllers
{
    public class DriverController : ApiControllerBase
    {
        private readonly IDriverService _driverService;

        public DriverController(IDriverService driverService,
         ICommandDispatcher commandDispatcher): base(commandDispatcher)
        {
            _driverService = driverService;          
        }        
       
        [HttpPost("/Driver")]
        public async Task<IActionResult> Post([FromBody]CreateDriver command)
        {
            await CommandDispatcher.DispatchAsync(command);
            return CreatedAtAction($"driver/{command.UserId}", new Object());
        }      





    }
}
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

        [HttpGet("/Driver")]
         public async Task<IActionResult> GetAsync(Guid id)      
        {
            var driver = await _driverService.GetAsync(id);
            if(driver == null)
            {
                    return NotFound();
            }
            return Json(driver);
        }

        [HttpGet("/Drivers")]
         public async Task<IActionResult> Get()      
        {
            var drivers = await _driverService.BrowseAsync();
            if(drivers == null)
            {
                    return NotFound();
            }
            return Json(drivers);
        }





    }
}
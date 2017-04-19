using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Services;
using  Passenger.Infrastructure.Commands.Users;

namespace Passenger.Api.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = _userService.Get(email);
            if(user == null)
            {
                    return NotFound();
            }
            return Json(user);
        }
     
        
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CreateUser request)
        {
             _userService.Register(request.Email, request.Username, request.Password);

            return CreatedAtAction($"users/{request.Email}", new Object());
        }

      
    }
}

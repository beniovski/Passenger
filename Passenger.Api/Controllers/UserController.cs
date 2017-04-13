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
        public UserDto Get(string email)
        => _userService.Get(email);
        
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost("")]
        public void Post([FromBody]CreateUser request)
        {
            _userService.Register(request.Email, request.Username, request.Password);
        }

      
    }
}

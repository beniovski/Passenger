using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace Passenger.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;
        private readonly ILogger<DataInitializer> _logger;
        public DataInitializer(IUserService userService, ILogger<DataInitializer> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            var tasks = new List<Task>();
           _logger.LogTrace("Initializing Data....");
           for(var i=0; i<=10; i++)
           {
               var userId = new Guid();
               var username = $"user{i}";
               tasks.Add(_userService.RegisterAsync(userId, $"{username}@test.com", username, "password"));
           }
           await Task.WhenAll(tasks);


           _logger.LogTrace("Data was initialized.");
           
        }
    }
}
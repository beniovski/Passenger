using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;

namespace Passenger.Infrastructure.Repositories
{
    public class InMemoryDriverRespository : IDriverRepository
    {
        private static ISet<Driver> _drivers = new HashSet<Driver>();

        public async Task AddAsync(Driver driver)
        {
           _drivers.Add(driver);
        }

        public async Task<IEnumerable<Driver>> GetAllAsync()=>_drivers;

        public async Task<Driver> GetAsync(Guid id)=> _drivers.Single(x=> x.DriverId == id);

        public async Task UpdateAsync(Driver driver)
        {
            await Task.CompletedTask;
        }
    }
}
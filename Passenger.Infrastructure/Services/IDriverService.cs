using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public interface IDriverService : IService
    {
       Task<DriverDto> GetAsync(Guid id);
       Task CreateAsync (Guid userId);
       Task SetVehicle (Guid userId, string brand, string name, int seats);
       Task<IEnumerable<DriverDto>> BrowseAsync();

    }
}
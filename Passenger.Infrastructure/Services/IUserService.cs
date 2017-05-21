using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<UserDto> GetAsync(string email);

        Task LoginAsync(string email, string password);
        Task<IEnumerable<UserDto>> BrowseAsync();
    
        Task RegisterAsync(Guid userId, string email, string username, string password);

    }
}
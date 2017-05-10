using System;
using System.Threading.Tasks;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<UserDto> GetAsync(string email);

        Task LoginAsync(string email, string password);
    
        Task RegisterAsync(string email, string username, string password);

    }
}
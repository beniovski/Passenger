using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;

namespace Passenger.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>()
            {
            new User ("useremail", "user1", "secret", "salt"),
            new User ("useremail1", "user2", "secret3", "salt4"),
            new User ("useremailq", "user3", "secret", " salt"),
            new User ("test", "test", "pass", "data"),
            };

        public async Task AddAsync(User user)
        {
            _users.Add(user);
        }

        public async Task<User> GetAsync(Guid id) =>  _users.Single(x => x.Id == id);

        public async Task<User> GetAsync(string email) => _users.Single(x=> x.Email == email.ToLowerInvariant()); 

        public async Task<IEnumerable<User>> GetAllAsync() =>  _users;

        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);
            _users.Remove(user);
        }

        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }
    }
}

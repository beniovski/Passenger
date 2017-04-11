using System;
using System.Collections.Generic;
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
            new User ("useremail", "user3", "secret", " salt"),
            };

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User Get(Guid id)
            => _users.Single(x => x.id == id);

        public User Get(string email)
            => _users.Single(x=> x.Email == email.ToLowerInvariant()); 

        public IEnumerable<User> GetAll()
            => _users;

        public void Remove(Guid id)
        {
            var user = Get(id);
            _users.Remove();
        }

        public void Update(User user)
        {
        }       


    }
}

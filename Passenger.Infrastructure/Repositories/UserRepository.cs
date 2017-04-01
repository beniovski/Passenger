using System;
using Passenger.Core.Repositories;

namespace Passenger.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepositries
    {
        private static ISet<User> _users = new HashSet<User>()
            {
            new User ("useremail", "user1", "secret", " salt"),
            };

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User Get(string email )
            => _users.Single(x=> x.Email ==email.ToLowerInvariant()); 

        public IEnumrable<User> GetAll()
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

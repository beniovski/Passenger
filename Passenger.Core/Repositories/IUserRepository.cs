using System;

namespace Passenger.Core.Repository
{
    public interface IUserRepository
    {
        User Get(Guid id);

        User Get(string email);

        IEnumerable<User> GetAll();
        
        void Add(user user);

        void Remove(Guid id);

        void Update(User user);

    }


}

using System;
using Passenger.Infrastructure.DTO;
using Passenger.Core.Repositories;
using Passenger.Core.Domain;
using AutoMapper;

namespace Passenger.Infrastructure.Services

{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserDto Get(string email)
        {
            var user = _userRepository.Get(email);
            return _mapper.Map<User, UserDto>(user);            
        }    
        
        public void Register(string email , string password)
        {

        }

        public void Register(string email, string username,  string password)
        {
            var user = _userRepository.Get(email);
            if(user != null )
            {
                throw new Exception($"User with email {email} allready exist.");
            }
            var salt = Guid.NewGuid().ToString("N");
            user = new User(email, username, password, salt);
            _userRepository.Add(user);
        }

    }
}

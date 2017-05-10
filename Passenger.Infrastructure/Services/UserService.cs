using System;
using Passenger.Infrastructure.DTO;
using Passenger.Core.Repositories;
using Passenger.Core.Domain;
using AutoMapper;
using System.Threading.Tasks;
using Passenger.Core.Repositories;

namespace Passenger.Infrastructure.Services

{
    public class UserService : IUserService
    {
        private readonly IEncrypter _encrypter;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,IEncrypter encrypter, IMapper mapper)
        {
            _encrypter = encrypter;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);
            return _mapper.Map<User, UserDto>(user);            
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if(user == null )
            {
                throw new Exception("invalid credentials");
            }
            var salt = _encrypter.GetSalt(password);
            var hashedPass = _encrypter.GetHash(password, salt);
           if(user.Password == hashedPass)
           {
               return;
           }
           throw new Exception("invalid credentials");
        }

        public async Task RegisterAsync(string email , string password)
        {

        }

        public async Task RegisterAsync(string email, string username,  string password)
        {
            var user = await _userRepository.GetAsync(email);
            if(user != null )
            {
                throw new Exception($"User with email {email} allready exist.");
            }
            var salt = _encrypter.GetSalt(password);
            var hashedPass = _encrypter.GetHash(password, salt);
            user = new User(email, username, hashedPass, salt);
            _userRepository.AddAsync(user);
        }

    }
}

﻿using System;
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
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);
            return _mapper.Map<User, UserDto>(user);            
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
            var salt = Guid.NewGuid().ToString("N");
            user = new User(email, username, password, salt);
            _userRepository.AddAsync(user);
        }

    }
}

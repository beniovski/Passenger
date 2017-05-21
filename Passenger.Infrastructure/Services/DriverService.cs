using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        private readonly IMapper _mapper;
        private readonly IDriverRepository _driverRepository;

        private readonly IUserRepository _userRepository;

        public DriverService(IMapper mapper, IDriverRepository driverRepository, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _driverRepository = driverRepository;
        }

        public async Task<DriverDto> GetAsync(Guid id)
        {
            var driver = await _driverRepository.GetAsync(id);

            return _mapper.Map<Driver, DriverDto>(driver);
        }

        public async Task CreateAsync(Guid userId)
        {
           var user = _userRepository.GetAsync(userId);
           if(user == null)
           {
               throw new Exception ($"user with id {userId} not found");
           }

           var driver =  _driverRepository.GetAsync(userId);
           if(driver != null)
           {
               throw new Exception ($"driver with id {userId} allready exist");
           }

           driver = new Driver(user);
           await _driverRepository.AddAsync(driver);


        }
        public async Task GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task SetVehicle(Guid userId, string brand, string name, int seats)
        {
           var driver =  _driverRepository.GetAsync(userId);
           if(user != null)
           {
               throw new Exception ($"driver with id {userId} allready exist");
           }
           driver.SetVehicle(brand, name, seats );
           await _driverRepository.UpdateAsync(driver);
        }

        public async Task<IEnumerable<DriverDto>> BrowseAsync()
        {
            var drivers = await _driverRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<Driver>, IEnumerable<DriverDto>>(drivers);
        }
    }
}
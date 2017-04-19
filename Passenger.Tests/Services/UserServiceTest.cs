using AutoMapper;
using Moq;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.Services;
using Xunit;

namespace Passenger.Tests.Services
{
    public class UserServiceTest
    {
        
        [Fact]
        public void Test()
        {
            var userRepositoryMock= new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            userService.Register("user", "passs");

            userRepositoryMock.Verify(x=> x.Add(It.IsAny<User>()), Times.Once);



        
        }
    }
}
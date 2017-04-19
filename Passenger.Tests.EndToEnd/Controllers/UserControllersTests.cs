using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Passenger.Api;
using Passenger.Infrastructure.DTO;
using Xunit;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public class UserControllersTests
    {
        private readonly TestServer _server;

        private readonly HttpClient _client;
        public UserControllersTests()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }
        [Fact]
        public async Task ReturnHelloWorld()
        {
            // Act
            var email ="useremail";
            var response = await _client.GetAsync($"users/{email}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var user = JsonConvert.DeserializeObject<UserDto>(responseString);

            user.Email.ShouldBeEquivalentTo(email);

            // Assert
            Assert.Equal("Hello World!",
                responseString);
        }
    }
}
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public class UserControllersTests : ControllerTestBase
    {
        [Fact]
        public async Task check_status_code_when_email_is_not_found()
        {
            // Act
            var email ="useremail";
            var  response = await Client.GetAsync($"users/{email}");
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NotFound);           
           
        }
    }
}
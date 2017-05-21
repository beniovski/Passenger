using System;

namespace Passenger.Infrastructure.Commands.Users
{
    public class Login : ICommand
    {
        public Guid tokenId { get; set;}
        public string Email { get; set;}
        public string Password { get; set;}
    }
}
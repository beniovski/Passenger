using System;
using System.Collections.Generic;
using Passenger.Core.Domain;

namespace Passenger.Infrastructure.DTO
{
    public class DriverDto
    {
        public Guid Id { get; set; }
        public string Name { get; set;}
        public DateTime UpdatedAt { get; set;}
    }
}
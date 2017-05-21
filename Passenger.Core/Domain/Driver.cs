using System.Collections.Generic;
using System;

namespace Passenger.Core.Domain
{
    public class Driver
    {
        public Guid UserId { get; protected set;}

        public String Name {get; protected set;}

        public Guid DriverId { get; private set;}    
        
        public Vehicle Vehicle { get; protected set;}

        public DateTime UpdatedAt { get; protected set;}

        public IEnumerable<Route> Routes { get; protected set;}

        public IEnumerable<DailyRoute> DailyRoutes { get; protected set;}      

        private Driver()
        {

        }  
        public Driver (User user)
        {
           UserId = user.Id;
           Name = user.Username;

        }
        public void SetVehicle(string brand, string name, int seats)
        {
            Vehicle = new Vehicle(brand, name, seats);
            UpdatedAt = DateTime.UtcNow;
        }

    }

}
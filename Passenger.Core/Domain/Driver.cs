using System.Collections.Generic;
using System;

namespace Passenger.Core.Domain
{
    public class Driver
    {
        public Guid UserId { get; protected set;}

        public Guid DriverId { get; private set;}    
        
        public Vehicle Vehicle { get; protected set;}

        public IEnumerable<Route> Routes { get; protected set;}

        public IEnumerable<DailyRoute> DailyRoutes { get; protected set;}      

        private Driver()
        {

        }  
        public Driver (Vehicle vehicle, Guid userid)
        {
            DriverId = new Guid();
            Vehicle = vehicle;
            UserId = userid;
        }

    }

}
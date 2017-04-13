using System.Collections.Generic;
using System;

namespace Passenger.Core.Domain
{
    class Driver
    {
        public Guid UserId { get; protected set;}

        public Vehicle Vehicle { get; protected set;}

        public IEnumerable<Route> Routes { get; protected set;}

        public IEnumerable<DailyRoute> DailyRoutes { get; protected set;}        

    }

}
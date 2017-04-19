using System;
using System.Collections.Generic;


namespace Passenger.Core.Domain
{
    public class Passenger
    {
        public Guid id { get; protected set; }

        public Guid UserId { get; protected set; }

        public Node Address { get; protected set;  }

        public IEnumerable<Route> Routes { get; protected set; }

        public IEnumerable<DailyRoute> DailyRoutes { get; protected set; }

        public Passenger()
        {

        }
        Passenger(Node address, Guid userid)
        {
            id = new Guid();
            UserId = userid;
            address = Address;
        }

    }


}

using System;


namespace Passenger.Core.Domain
{
    public class Passenger
    {
        public Guid id { get; protected set; }

        public Guid UserId { get; protected set; }

        public Node Address { get; protected set;  }

        public IEnumerable<Route> Routes { get; protected set; }

        public IEnumerable<DailyRoute> DailyRoutes { get; protected set; }

    }


}

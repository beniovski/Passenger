using System;
using System.Collections.Generic;

namespace Passenger.Core.Domain
{
    public class DailyRoute
    {
        public Guid id { get; protected set; }

        public Route Route { get; protected set; }

        public IEnumerable<PassengerNode> PassengerNodes { get; protected set; }

        public DailyRoute()
        {

        }
        public DailyRoute(Route route)
        {
            id  = new Guid();
            Route = route ;
        }

    }

}

using System;
using System.Collections.Generic;


namespace Passenger.Core.Domain
{
    public class DailyRoute
    {
        public Guid id { get; protected set; }

        public Route Route { get; protected set; }

        public IEnumerable<PassengerNode> PassengerNodes { get; protected set; }

    }

}

using System;


namespace Passenger.Core.Domain
{
    public class Route
    {
        public Guid id { get; protected set; }

        public Node StartNode { get; protected set; } 

        public Node EndNode { get; protected set; }

        public Route()
        {

        }
        public Route(Node startnode, Node endnode)
        {
            id = new Guid();
            StartNode = startnode;
            EndNode = endnode;
        }

     }

}




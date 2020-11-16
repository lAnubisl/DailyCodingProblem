using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingProblem439
{
    /*
     Given an unordered list of flights taken by someone, each represented as (origin, destination) pairs, 
     and a starting airport, compute the person's itinerary. If no such itinerary exists, return null. 
     If there are multiple possible itineraries, return the lexicographically smallest one. 
     All flights must be used in the itinerary.

     For example, given the list of flights 
     [('SFO', 'HKO'), ('YYZ', 'SFO'), ('YUL', 'YYZ'), ('HKO', 'ORD')] and starting airport 'YUL', 
     you should return the list ['YUL', 'YYZ', 'SFO', 'HKO', 'ORD'].

     Given the list of flights 
     [('SFO', 'COM'), ('COM', 'YYZ')] and starting airport 'COM', 
     you should return null.

     Given the list of flights [('A', 'B'), ('A', 'C'), ('B', 'C'), ('C', 'A')] and starting airport 'A', 
     you should return the list ['A', 'B', 'C', 'A', 'C'] even though ['A', 'C', 'A', 'B', 'C'] is also a valid 
     itinerary. However, the first one is lexicographically smaller.
     */

    class Program
    {
        static int totalFlights;
        static void Main(string[] args)
        {
            DoJob(
                new[]
                {
                    new Flight("SFO", "HKO"),
                    new Flight("YYZ", "SFO"),
                    new Flight("YUL", "YYZ"),
                    new Flight("HKO", "ORD"),
                },
                "YUL"
            );
            DoJob(
                new[]
                {
                    new Flight("SFO", "COM"),
                    new Flight("COM", "YYZ"),
                },
                "COM"
            );
            DoJob(
                new[]
                {
                    new Flight("A", "B"),
                    new Flight("A", "C"),
                    new Flight("B", "C"),
                    new Flight("C", "A"),
                },
                "A"
            );
        }

        static void DoJob(Flight[] flights, string startingPoint)
        {
            var path = CalculateItineraries(flights, startingPoint);
            if (path == null)
            {
                Console.WriteLine("NULL");
                return;
            }

            Console.WriteLine(string.Join(", ", path));
        }

        static string[] CalculateItineraries(Flight[] flights, string startingPoint)
        {
            totalFlights = flights.Length;
            var nodes = Graph.Build(flights);
            if (!nodes.ContainsKey(startingPoint))
            {
                return null;
            }

            var root = nodes[startingPoint];
            return Search(root);
        }

        static string[] Search(Node root)
        {
            return Search(root, new LinkedList<Flight>(), new HashSet<Flight>());
        }

        static string[] Search(Node root, LinkedList<Flight> list, HashSet<Flight> set)
        {
            foreach(var node in root.Children)
            {
                var flight = new Flight(root.Address, node.Address);
                if (set.Add(flight))
                {
                    list.AddLast(flight);
                    var result = Search(node, list, set);
                    if (result != null) return result;
                    list = new LinkedList<Flight>(list.TakeWhile(l => !Equals(l, flight)));
                    set = list.ToHashSet();
                }
            }

            if (set.Count == totalFlights)
            {
                var l = list.Select(p => p.Origin).ToList();
                l.Add(list.Last().Destination);
                return l.ToArray();
            }

            return null;
        }
    }

    static class Graph
    {
        private static Dictionary<string, Node> nodes;
        public static Dictionary<string, Node> Build(Flight[] flights)
        {
            nodes = new Dictionary<string, Node>();
            foreach (var flight in flights)
            {
                Add(flight);
            }
            
            return nodes;
        }

        internal static void Add(Flight flight)
        {
            var origin = Add(flight.Origin);
            var destination = Add(flight.Destination);
            origin.Children.Add(destination);
        }

        internal static Node Add(string address)
        {
            if (nodes.ContainsKey(address))
            {
                return nodes[address];        
            }

            var node = new Node() { Address = address };
            nodes.Add(address, node);
            return node;
        }
    }

    class Node : IComparable
    {
        public string Address;
        public SortedSet<Node> Children = new SortedSet<Node>();

        public override bool Equals(object obj)
        {
            var that = obj as Node;
            if (that == null) return false;
            return Equals(that);
        }

        private bool Equals(Node that)
        {
            return Equals(this.Address, that.Address);
        }

        public override int GetHashCode()
        {
            return Address.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            var that = obj as Node;
            if (that == null) return 1;
            return Address.CompareTo(that.Address);
        }
    }

    class Flight
    {
        public Flight(string origin, string destination)
        {
            Origin = origin;
            Destination = destination;
        }

        public string Origin, Destination;

        public override bool Equals(object obj)
        {
            var that = obj as Flight;
            if (that == null) return false;
            return Equals(that);
        }

        private bool Equals(Flight that)
        {
            return Equals(this.Origin, that.Origin) 
                && Equals(this.Destination, that.Destination);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Origin, Destination);
        }

        public override string ToString()
        {
            return $"{Origin} -> {Destination}";
        }
    }
}

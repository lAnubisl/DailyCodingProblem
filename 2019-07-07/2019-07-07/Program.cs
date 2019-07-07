using System;
using System.Linq;

namespace _2019_07_07
{
    // Given an array of time intervals(start, end) for classroom lectures(possibly overlapping), 
    // find the minimum number of rooms required.
    // For example, given[(30, 75), (0, 50), (60, 150)], you should return 2.
    class Program
    {
        static void Main(string[] args)
        {
            var data = new Interval[] { new Interval(30, 75), new Interval(0, 50), new Interval(60, 150) };
            var pointsOfTime = data.Select(d => d.Start as StartOrEnd)
                        .Union(data.Select(d => d.End as StartOrEnd))
                        .OrderBy(d => d.Date);
            var maxRooms = 0;
            var currentRooms = 0;
            foreach(var pointOfTime in pointsOfTime)
            {
                currentRooms = pointOfTime.GetType() == typeof(Start) ? currentRooms + 1 : currentRooms - 1;
                if (maxRooms < currentRooms) maxRooms = currentRooms;
            }

            Console.WriteLine(maxRooms);
            Console.ReadKey();
        }
    }

    abstract class StartOrEnd
    {
        public int Date { get; protected set; }
    }

    class Start : StartOrEnd
    {
        public Start(int date)
        {
            Date = date;
        }
    }

    class End : StartOrEnd
    {
        public End(int date)
        {
            Date = date;
        }
    }

    class Interval
    {
        public Interval(int start, int end)
        {
            Start = new Start(start);
            End = new End(end);
        }

        public readonly Start Start;
        public readonly End End;
    }
}
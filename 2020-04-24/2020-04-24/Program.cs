using System;
using System.Collections.Generic;

namespace _2020_04_24
{
    /* Daily Coding Problem: Problem #313 [Hard]
     * Good morning! Here's your coding interview problem for today.
     * This problem was asked by Citrix.
     * You are given a circular lock with three wheels, each of which display the numbers 0 through 9 in order.Each of these wheels rotate clockwise and counterclockwise.
     * In addition, the lock has a certain number of "dead ends", meaning that if you turn the wheels to one of these combinations, the lock becomes stuck in that state and cannot be opened.
     * Let us consider a "move" to be a rotation of a single wheel by one digit, in either direction. Given a lock initially set to 000, a target combination, and a list of dead ends, 
     * write a function that returns the minimum number of moves required to reach the target state, or None if this is impossible.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solve(525, new int[] { 111, 998 }));
            Console.ReadKey();
        }

        static int? Solve(int target, int[] deadEnds)
        {
            var queue = new Queue<(int, int)>();
            var visited = new HashSet<int>(deadEnds);
            queue.Enqueue((0, 0));
            while (queue.TryDequeue(out (int, int) val))
            {
                if (visited.Contains(val.Item1)) continue;
                visited.Add(val.Item1);
                if (val.Item1 == target) return val.Item2;
                foreach (var item in GetConnections(val.Item1))
                {
                    queue.Enqueue((item, val.Item2 + 1));
                }
            }

            return null;
        }

        static IEnumerable<int> GetConnections(int value)
        {
            var x = value / 100;
            var y = (value - 100 * x) / 10;
            var z = (value - 100 * x - 10 * y);
            yield return 100 * x + 10 * y + Map(z + 1);
            yield return 100 * x + 10 * y + Map(z - 1);
            yield return 100 * x + 10 * Map(y + 1) + z;
            yield return 100 * x + 10 * Map(y - 1) + z;
            yield return 100 * Map(x + 1) + 10 * y + z;
            yield return 100 * Map(x - 1) + 10 * y + z;
        }

        static int Map(int i) => i == -1 ? 9 : i == 10 ? 0 : i;
    }
}

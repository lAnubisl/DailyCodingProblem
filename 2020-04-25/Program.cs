using System;
using System.Collections.Generic;
using System.Linq;

namespace _2020_04_25
{
    /* Daily Coding Problem: Problem #314 [Medium]
     * Good morning! Here's your coding interview problem for today.
     * This problem was asked by Spotify.
     * You are the technical director of WSPT radio, serving listeners nationwide. 
     * For simplicity's sake we can consider each listener to live along a horizontal line stretching from 0 (west) to 1000 (east).
     * Given a list of N listeners, and a list of M radio towers, each placed at various locations along this line, 
     * determine what the minimum broadcast range would have to be in order for each listener's home to be covered.
     * For example, suppose listeners = [1, 5, 11, 20], and towers = [4, 8, 15]. 
     * In this case the minimum range would be 5, since that would be required for the tower at position 15 to reach the listener at position 20.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solve(new int[] { 1, 5, 11, 20 },  new int[] { 4, 8, 15 }));
        }

        static int Solve(int[] listeners, int[] towers)
        {
            var listenersDict = new Dictionary<int, bool>(listeners.Select(l => new KeyValuePair<int, bool>(l, false)));
            var towersSet = new HashSet<Tower>(towers.Select(t => new Tower { Location = t }));
            var totalListeners = listeners.Length;
            var coveredListeners = 0;
            var signalPower = -1;
            while (coveredListeners < totalListeners)
            {
                signalPower++;
                coveredListeners += CheckNewListeners(listenersDict, towersSet, signalPower);
            }

            return signalPower;
        }

        static bool NewListenerCovered(Dictionary<int, bool> listeners, Tower tower, bool searchRight, int signalPower)
        {
            var location = tower.Location + (searchRight ? signalPower : signalPower * -1);
            if (!listeners.TryGetValue(location, out bool covered))
            {
                return false;
            }

            if (covered)
            {
                if (searchRight) tower.SearchRight = false;
                else tower.SearchLeft = false;
                return false;
            }

            listeners[location] = true;
            return true;
        }

        static int CheckNewListeners(Dictionary<int, bool> listeners, HashSet<Tower> towers, int signalPower)
        {
            var result = 0;
            var towersToNotUse = new List<Tower>();
            foreach(var tower in towers)
            {
                if (tower.SearchLeft && NewListenerCovered(listeners, tower, false, signalPower)) result++;
                if (tower.SearchRight && NewListenerCovered(listeners, tower, true, signalPower)) result++;
                if (!tower.SearchRight && !tower.SearchLeft) towersToNotUse.Add(tower);
            }

            foreach(var tower in towersToNotUse)
            {
                towers.Remove(tower);
            }

            return result;
        }

        private class Tower
        {
            public int Location;
            public bool SearchLeft = true, SearchRight = true;

            public override int GetHashCode()
            {
                return Location;
            }

            public override bool Equals(object obj)
            {
                var other = obj as Tower;
                if (other == null) return false;
                return this.Location == other.Location;
            }
        }
    }
}
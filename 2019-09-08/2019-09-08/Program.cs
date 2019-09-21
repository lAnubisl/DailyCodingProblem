using System;

namespace _2019_09_08
{
    /*
        Given a matrix of 1s and 0s, return the number of "islands" in the matrix. A 1 represents land and 0 represents water, so an island is a group of 1s that are neighboring whose perimeter is surrounded by water.

        For example, this matrix has 4 islands.

        1 0 0 0 0
        0 0 1 1 0
        0 1 1 0 0
        0 0 0 0 0
        1 1 0 0 1
        1 1 0 0 1
    */
    class Program
    {
        static void Main(string[] args)
        {
            var map = new bool[,]
            {
                {true,  false, false, false, false },
                {false, false, true,  true,  false },
                {false, true,  true,  false, false },
                {false, false, false, false, false },
                {true,  true,  false, false, true },
                {true,  true,  false, false, true }
            };
            Console.WriteLine(CountIslands(map));
            Console.ReadLine();
        }

        static int CountIslands(bool[,] map)
        {
            var islands = 0;
            var visited = new bool[map.GetLength(0), map.GetLength(1)];
            for(var i = 0; i < map.GetLength(0); i++)
            {
                for(var j = 0; j < map.GetLength(1); j++)
                {
                    if (visited[i, j]) continue;
                    if (!map[i,j]) { visited[i, j] = true; continue; }
                    islands++;
                    ScanIsland(visited, map, i, j);
                }
            }
            return islands;
        }

        static void ScanIsland(bool[,] visited, bool[,] map, int i, int j)
        {
            if (visited[i, j]) return;
            visited[i, j] = true;
            if (!map[i, j]) return;
            if (i > 0) ScanIsland(visited, map, i - 1, j);
            if (j > 0) ScanIsland(visited, map, i, j - 1);
            if (i < map.GetLength(0) - 1) ScanIsland(visited, map, i + 1, j);
            if (j < map.GetLength(1) - 1) ScanIsland(visited, map, i, j + 1);
            if (i > 0 && j > 0) ScanIsland(visited, map, i - 1, j - 1);
            if (i > 0 && j < map.GetLength(1) - 1) ScanIsland(visited, map, i - 1, j + 1);
            if (i < map.GetLength(0) - 1 && j > 0) ScanIsland(visited, map, i + 1, j);
            if (i < map.GetLength(0) - 1 && j < map.GetLength(1) - 1) ScanIsland(visited, map, i + 1, j + 1);
        }
    }
}
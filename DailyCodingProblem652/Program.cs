using System;

namespace DailyCodingProblem652
{
    /// <summary>
    /// Good morning! Here's your coding interview problem for today.
    /// This problem was asked by Apple.
    /// You are going on a road trip, and would like to create a suitable music playlist.
    /// The trip will require N songs, though you only have M songs downloaded, where M < N.
    /// A valid playlist should select each song at least once, and guarantee a buffer of B songs between repeats.
    /// Given N, M, and B, determine the number of valid playlists.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // _  _       _      _       _       _
            // M (M - 1) (M - 2) (M - B) (M - B) (M - B)
            Console.WriteLine(Solve(5, 10, 4));
        }

        static long Solve(int M, int N, int B)
        {
            long count = 0;
            for(int i = 1; i <= N; i++)
            {
                if (i == 1)
                {
                    count = M;
                    continue;
                }

                if (i <= M)
                {
                    count = count * (M - (i - 1));
                    continue;
                }

                count = count * (M - B);
            }

            return count;
        }
    }
}
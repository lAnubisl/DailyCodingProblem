using System;
using System.Linq;

namespace DailyCodingProblem653
{
    /// <summary>
    /// Good morning! Here's your coding interview problem for today.
    /// This problem was asked by Google.
    /// You are given given a list of rectangles represented by min and max x- and y-coordinates.
    /// Compute whether or not a pair of rectangles overlap each other.
    /// If one rectangle completely covers another, it is considered overlapping.
    /// For example, given the following rectangles:
    /// 
    /// {
    ///     "top_left": (1, 4),
    ///     "dimensions": (3, 3) # width, height
    /// },
    /// {
    ///     "top_left": (-1, 3),
    ///     "dimensions": (2, 1)
    /// },
    /// {
    ///     "top_left": (0, 5),
    ///     "dimensions": (4, 3)
    /// }
    /// 
    /// return true as the first and third rectangle overlap each other.
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var rectangles = GetInput();
            Console.WriteLine(Solve(rectangles));
        }

        /// CPU: O(nlogn)
        /// MEM: O(n) vsn br improwed to O(1) 
        static bool Solve(Rectangle[] input)
        {
            // CPU: O(nlogn)
            var sorted = input.OrderByDescending(XMax).ToArray();
            for(int i = 0; i < input.Length - 1; i++)
            {
                if (XMax(sorted[i + 1]) > sorted[i].TopLeft.X)
                {
                    if (Solve(sorted[i], sorted[i + 1])) return true;
                }
            }

            return false;
        }

        static bool Solve(Rectangle a, Rectangle b)
        {
            if (a.TopLeft.Y > b.TopLeft.Y) return YMin(a) < b.TopLeft.Y;
            return YMin(b) < a.TopLeft.Y;
        }

        static int YMin(Rectangle r)
        {
            return r.TopLeft.Y - r.Dimensions.Height;
        }

        static int XMax(Rectangle r)
        {
            return r.TopLeft.X + r.Dimensions.Width;
        }

        static Rectangle[] GetInput()
        {
            return new Rectangle[]
            {
                new Rectangle
                {
                    TopLeft = new Point { X = 1, Y = 4 },
                    Dimensions = new Dimensions { Width = 3, Height = 3 }
                },
                new Rectangle
                {
                    TopLeft = new Point { X = -1, Y = 3 },
                    Dimensions = new Dimensions { Width = 2, Height = 1 }
                },
                //new Rectangle
                //{
                //    TopLeft = new Point { X = 0, Y = 5 },
                //    Dimensions = new Dimensions { Width = 4, Height = 3 }
                //},
            };

        }
    }

    class Rectangle
    {
        public Point TopLeft { get; set; }
        public Dimensions Dimensions { get; set; }
    }

    class Point
    {
        public int X, Y;
    }

    class Dimensions
    {
        public int Width, Height;
    }
}

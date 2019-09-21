using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _2019_09_11
{
    /*
    A rule looks like this:

    A NE B

    This means this means point A is located northeast of point B.

    A SW C

    means that point A is southwest of C.

    Given a list of rules, check if the sum of the rules validate. For example:

    A N B
    B NE C
    C N A
    does not validate, since A cannot be both north and south of C.

    A NW B
    A N B
    is considered valid.
    */
    class Program
    {
        static Line latitude = new Line();
        static Line longitude = new Line();

        static void Main(string[] args)
        {
            var sb = new StringBuilder();
            //sb.AppendLine("A N B");
            //sb.AppendLine("B NE C");
            //sb.AppendLine("C N A");
            sb.AppendLine("A NW B");
            sb.AppendLine("A N B");
            

            var input = sb.ToString();

            var statements = input.Split(Environment.NewLine).SelectMany(Parse);
            var valid = latitude.Process(Relationship.Latitudes(statements)).All(p => p) 
                     && longitude.Process(Relationship.Longitures(statements)).All(p => p);

            Console.WriteLine(valid);
            Console.ReadKey();
        }

        public static IEnumerable<Relationship> Parse(string str)
        {
            if (str == null) yield break;
            var parts = str.Split(' ');
            if (parts.Length != 3) yield break;
            if (Regex.Match(parts[1], "^[WENS]+$") == Match.Empty) yield break;
            foreach (var direction in parts[1].ToCharArray())
            {
                yield return new Relationship() { From = parts[0], Direction = direction, To = parts[2] };
            }
        }

    }

    class Line
    {
        private IDictionary<string, Point> Points = new Dictionary<string, Point>();

        public IEnumerable<bool> Process(IEnumerable<Relationship> relationships)
        {
            foreach (var relationship in relationships)
            {
                Points.TryGetValue(relationship.To, out Point to);
                Points.TryGetValue(relationship.From, out Point from);

                if (to == null)
                {
                    to = new Point { Name = relationship.To };
                    Points.Add(to.Name, to);
                }

                if (from == null)
                {
                    from = new Point { Name = relationship.From };
                    Points.Add(from.Name, from);
                }

                if (!to.AddFrom(from)) yield return false;
                if (!from.AddTo(to)) yield return false;
                yield return true;
            }
        }
    }

    class Point
    {
        public string Name;
        public bool AddTo(Point point)
        {
            if (InFroms(point)) return false;
            Tos.Add(point);
            return true;
        }

        public bool AddFrom(Point point)
        {
            if (InTos(point)) return false;
            Froms.Add(point);
            return true;
        }

        private bool InTos(Point point)
        {
            return Tos.Any(p => p.Name == point.Name) || Tos.Select(to => to.InTos(point)).Any(to => to);
        }

        private bool InFroms(Point point)
        {
            return Froms.Any(p => p.Name == point.Name) || Froms.Select(from => from.InFroms(point)).Any(from => from);
        }

        private List<Point> Froms = new List<Point>();
        private List<Point> Tos = new List<Point>();
    }

    class Relationship
    {
        public string From, To;
        public char Direction;

        public static IEnumerable<Relationship> Latitudes(IEnumerable<Relationship> relationships)
        {
            return Line(relationships, 'W');
        }

        public static IEnumerable<Relationship> Longitures(IEnumerable<Relationship> relationships)
        {
            return Line(relationships, 'N');
        }

        private static IEnumerable<Relationship> Line(IEnumerable<Relationship> relationships, char c)
        {
            return relationships.Select(r => r.Normalize()).Where(r => r.Direction == c);
        }

        private Relationship Normalize()
        {
            if (Direction == 'S')
            {
                Invert();
                Direction = 'N';
            }

            if (Direction == 'E')
            {
                Invert();
                Direction = 'W';
            }

            return this;
        }

        private void Invert()
        {
            var temp = To;
            To = From;
            From = temp;
        }
    }
}

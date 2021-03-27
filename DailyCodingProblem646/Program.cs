using System;
using System.Collections.Generic;

namespace DailyCodingProblem646
{
    /// <summary>
    /// This problem was asked by Twitter.
    /// A classroom consists of N students, whose friendships can be represented in an adjacency list.
    /// For example, the following descibes a situation where 
    /// 0 is friends with 1 and 2, 
    /// 3 is friends with 6, and so on.
    /// 
    /// {0: [1, 2],
    ///  1: [0, 5],
    ///  2: [0],
    ///  3: [6],
    ///  4: [],
    ///  5: [1],
    ///  6: [3]
    /// }
    /// 
    /// Each student can be placed in a friend group, which can be defined as the transitive closure 
    /// of that student's friendship relations. In other words, this is the smallest set such that 
    /// no student in the group has any friends outside this group. For the example above, the friend 
    /// groups would be {0, 1, 2, 5}, {3, 6}, {4}.
    /// Given a friendship list such as the one above, determine the number of friend groups in the class.
    /// 
    /// The idea:
    /// 1) Build a graph.
    /// 2) Use BFS to scan isolated graph clusters
    /// 3) Go through all students and search clusters for all of them.
    /// 4) Optimization: assign users to a cluster. Give each unique cluster an index
    /// 5) Store cluster indexes
    /// 6) Count cluster indexes. => result
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var graph = BuildGraph();
            var groups = Group(graph);
            Console.WriteLine(groups.Length);
        }

        static HashSet<Student>[] Group(Student[] graph)
        {
            var list = new List<HashSet<Student>>();
            foreach (var student in graph)
            {
                var skipStudent = false;
                foreach (var hashSet in list)
                {
                    if (hashSet.Contains(student))
                    {
                        skipStudent = true;
                        break;
                    }
                }

                if (skipStudent) continue;
                var currentHashSet = new HashSet<Student>();
                Queue<Student> q = new Queue<Student>();
                q.Enqueue(student);
                while (q.TryDequeue(out Student current))
                {
                    currentHashSet.Add(current);
                    foreach (var friend in current.Friends)
                    {
                        if (currentHashSet.Contains(friend)) continue;
                        q.Enqueue(friend);
                    }
                }

                list.Add(currentHashSet);
            }

            return list.ToArray();
        }

        static Student[] BuildGraph()
        {
            // assume we can parse input data somehow. 
            var graph = new List<Student>();
            var s0 = new Student("0");
            var s1 = new Student("1");
            var s2 = new Student("2");
            var s3 = new Student("3");
            var s4 = new Student("4");
            var s5 = new Student("5");
            var s6 = new Student("6");
            s0.AddFriend(s1);
            s0.AddFriend(s2);
            s1.AddFriend(s0);
            s1.AddFriend(s5);
            s2.AddFriend(s0);
            s3.AddFriend(s6);
            s5.AddFriend(s1);
            s6.AddFriend(s3);
            graph.Add(s0);
            graph.Add(s1);
            graph.Add(s2);
            graph.Add(s3);
            graph.Add(s4);
            graph.Add(s5);
            graph.Add(s6);
            return graph.ToArray();
        }
    }

    class Student
    {
        public Student(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public void AddFriend(Student friend)
        {
            Friends.Add(friend);
        }

        public string Name { get; }
        public List<Student> Friends { get; } = new List<Student>();
    }
}

using System;
using System.Collections.Generic;

namespace DailyCodingProblem436
{
    /* 
    Good morning! Here's your coding interview problem for today.

    This problem was asked by Microsoft.
    Implement 3 stacks using a single list:

    class Stack:
        def __init__(self):
            self.list = []

        def pop(self, stack_number):
            pass

        def push(self, item, stack_number):
            pass
     */
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();
            stack.Push(1, 1);
            stack.Push(2, 2);
            stack.Push(3, 3);
            stack.Push(4, 1);
            stack.Push(5, 2);
            stack.Push(6, 3);

            Console.WriteLine(stack.Pop(1));
            Console.WriteLine(stack.Pop(1));
            Console.WriteLine(stack.Pop(2));
            Console.WriteLine(stack.Pop(2));
            Console.WriteLine(stack.Pop(3));
            Console.WriteLine(stack.Pop(3));
        }
    }

    class Stack<T>
    {
        private readonly List<T> list = new List<T>();

        private int st1End = 0;
        private int st2End = 0;
        private int st3End = 0;

        public void Push(T value, int stackNumber)
        {
            if (stackNumber < 1 || stackNumber > 3) return;
            if (stackNumber == 1)
            {
                list.Insert(st1End, value);
                st1End++; st2End++; st3End++;
                return;
            }

            if (stackNumber == 2)
            {
                list.Insert(st2End, value);
                st2End++; st3End++;
                return;
            }

            list.Insert(st3End, value);
            st3End++;
        }

        public T Pop(int stackNumber)
        {
            if (stackNumber < 1 || stackNumber > 3) return default(T);
            if (stackNumber == 1)
            {
                st1End--;
                st2End--;
                st3End--;
                return Pop(list, st1End);
            }

            if(stackNumber == 2)
            {
                st2End--;
                st3End--;
                return Pop(list, st2End);
            }

            st3End--;
            return Pop(list, st3End);
        }

        private static T Pop(List<T> list, int index)
        {
            var result = list[index];
            list.RemoveAt(index);
            return result;
        }
    }
}

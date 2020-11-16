using System;

namespace DailyCodingProblem438
{
    /*
     * 
     This problem was asked by Amazon.

     Implement a stack API using only a heap. A stack implements the following methods:

     push(item), which adds an element to the stack
     pop(), which removes and returns the most recently added element (or throws an error if there is nothing on the stack)
     Recall that a heap has the following operations:

     push(item), which adds a new key to the heap
     pop(), which removes and returns the max value of the heap

     */
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new MyStack<int>();
            stack.Push(10);
            stack.Push(8);
            stack.Push(20);
            try
            {
                while (true)
                {
                    Console.WriteLine(stack.Pop());
                }
            }
            catch(Exception)
            {
                Console.WriteLine("No more elements");
            }
        }
    }

    class MyStack<T>
    {
        private readonly Heap<Wrapper<T>> heap = new Heap<Wrapper<T>>(10, true);
        private int counter;
        public void Push(T item)
        {
            var wrapper = new Wrapper<T> { Counter = counter, Value = item };
            heap.Insert(wrapper);
            counter++;
        }

        public T Pop()
        {
            return heap.Remove().Value;
        }
    }

    class Wrapper<T> : IComparable
    {
        public int Counter;
        public T Value;

        public int CompareTo(object obj)
        {
            var that = obj as Wrapper<T>;
            if (that == null) return -1;
            return this.Counter.CompareTo(that.Counter);
        }
    }

    /// <summary>
    /// Array-based Heap implementation.
    /// </summary>
    /// <typeparam name="T">Kind of thing being stored in the heap.</typeparam>
    public class Heap<T> where T : IComparable
    {
        private enum HeapType
        {
            Min,
            Max
        };

        private readonly HeapType _heapType;
        T[] _heap;
        int _count;

        /// <summary>
        /// Create a new heap.
        /// </summary>
        /// <param name="minSize">The minimum number of elements the heap is expected to hold.</param>
        /// <param name="isMaxHeap">If "true", this is a Max Heap, where the largest values rise to the top. Otherwise, this is a Min Heap.</param>
        public Heap(int minSize, bool isMaxHeap = false)
        {
            _heapType = isMaxHeap ? HeapType.Max : HeapType.Min;
            _heap = new T[((int)Math.Pow(2, Math.Ceiling(Math.Log(minSize, 2))))];
        }

        /// <summary>
        /// Current size of the Heap.
        /// </summary>
        public int Count { get { return _count; } }

        /// <summary>
        /// Test to see if the Heap is empty.
        /// </summary>
        public bool IsEmpty { get { return _count == 0; } }

        /// <summary>
        /// Add a new value to the Heap.
        /// </summary>
        /// <param name="val"></param>
        public void Insert(T val)
        {
            if (_count == _heap.Length)
            {
                DoubleHeap();
            }
            _heap[_count] = val;
            ShiftUp(_count);
            _count++;
        }

        /// <summary>
        /// View the value currently at the top of the Heap.
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (_heap.Length == 0) throw new ArgumentOutOfRangeException("No values in heap");
            return _heap[0];
        }

        /// <summary>
        /// Remove the value currently at the top of the Heap and return it.
        /// </summary>
        /// <returns></returns>
        public T Remove()
        {
            T output = Peek();
            _count--;
            _heap[0] = _heap[_count];
            ShiftDown(0);
            return output;
        }

        /// <summary>
        /// Move an element up the Heap.
        /// </summary>
        /// <param name="heapIndex"></param>
        private void ShiftUp(int heapIndex)
        {
            if (heapIndex == 0) return;
            int parentIndex = (heapIndex - 1) / 2;
            bool shouldShift = DoCompare(parentIndex, heapIndex) > 0;
            if (!shouldShift) return;
            Swap(parentIndex, heapIndex);
            ShiftUp(parentIndex);
        }

        /// <summary>
        /// Move an element down the Heap.
        /// </summary>
        /// <param name="heapIndex"></param>
        private void ShiftDown(int heapIndex)
        {
            int child1 = heapIndex * 2 + 1;
            if (child1 >= _count) return;
            int child2 = child1 + 1;

            int preferredChildIndex = (child2 >= _count || DoCompare(child1, child2) <= 0) ? child1 : child2;
            if (DoCompare(preferredChildIndex, heapIndex) > 0) return;
            Swap(heapIndex, preferredChildIndex);
            ShiftDown(preferredChildIndex);
        }

        /// <summary>
        /// Swap two items in the underlying array.
        /// </summary>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        private void Swap(int index1, int index2)
        {
            T temp = _heap[index1];
            _heap[index1] = _heap[index2];
            _heap[index2] = temp;
        }

        /// <summary>
        /// Perform a comparison between two elements of the heap.
        /// This method encapsulates the min/max behavior of the heap so the rest of the class can remain blissfully ignorant.
        /// </summary>
        /// <param name="initialIndex"></param>
        /// <param name="contenderIndex"></param>
        /// <returns></returns>
        private int DoCompare(int initialIndex, int contenderIndex)
        {
            T initial = _heap[initialIndex];
            T contender = _heap[contenderIndex];
            int value = initial.CompareTo(contender);
            if (_heapType == HeapType.Max) value = -value;
            return value;
        }

        /// <summary>
        /// Increase the size of the underlying storage.
        /// </summary>
        private void DoubleHeap()
        {
            var copy = new T[_heap.Length * 2];
            for (int i = 0; i < _heap.Length; i++)
            {
                copy[i] = _heap[i];
            }
            _heap = copy;
        }
    }
}

using System;

namespace InterviewPrep
{
    class CustomQueue
    {
        int[] arr;
        int head = 0;
        int tail = -1;
        int capacity = 10;

        public CustomQueue()
        {
            arr = new int[capacity];
        }

        public void Enqueue(int element)
        {
            EnsureExtraCapacity();
            tail++;
            arr[tail] = element;
        }

        public int Dequeue()
        {
            if (Size == 0)
                throw new Exception();

            int item = arr[head];

            // If Capacity is reduced the index of new head will be 0 since all elements would be transferred to a new array 
            if (ReduceCapacity())
                head = 0;
            else
                head++;

            return item;
        }

        private void Resize(int newCapacity)
        {
            int[] tempArr = new int[newCapacity];

            int pointer = 0;
            for (int i = head; i <= tail; i++)
            {
                tempArr[pointer] = arr[i];
                pointer++;
            }

            arr = tempArr;
        }

        private void EnsureExtraCapacity()
        {
            if (Size == capacity)
            {
                capacity *= 2;
                Resize(capacity);
            }
        }

        private bool ReduceCapacity()
        {
            if (Size == capacity / 3)
            {
                capacity /= 2;
                Resize(capacity);
                return true;
            }

            return false;
        }

        public int Size
        {
            get { return tail - head + 1; }
        }
    }
}

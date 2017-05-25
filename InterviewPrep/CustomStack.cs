using System;

namespace InterviewPrep
{
    // Create Stack Data Structure with an array
    // You may also accomplish this with a linked-list
    class CustomStack
    {
        int[] items = null;
        int capacity = 5;
        int size;

        public CustomStack()
        {
            items = new int[capacity];
        }

        private void Resize(int newCapacity)
        {
            int[] newArray = new int[capacity];

            for (int i = 0; i < size; i++)
            {
                newArray[i] = items[i];
            }

            items = newArray;
        }

        private void EnsureExtraCapacity()
        {
            if (size == capacity)
            {
                capacity *= 2;
                Resize(capacity);
            }      
        }

        private void ReduceCapacity()
        {
            if (size == capacity / 3)
            {
                capacity /= 2;
                Resize(capacity);
            }
        }
        
        public int Count()
        {
            return size;
        }

        public void Push(int value)
        {
            EnsureExtraCapacity();
            items[size] = value;
            size++;
        }

        public int Pop()
        {
            if (size == 0)
                throw new Exception();

            int item = items[size - 1];
            size--;
            ReduceCapacity();

            return item;
        }

    }
}

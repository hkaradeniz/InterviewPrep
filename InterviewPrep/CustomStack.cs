using System;

namespace InterviewPrep
{
    // Create Stack Data Structure with an array
    // You may also accomplish this with a linked-list
    class CustomStack
    {
        int[] items = null;
        int capacity;
        int size;

        public CustomStack(int cap)
        {
            capacity = cap;
            items = new int[capacity];
        }

        public void Push(int value)
        {
            if (size == capacity) Resize(capacity * 2);

            items[size++] = value;
        }

        public int Pop()
        {
            if (size == 0) throw new Exception();
            if (capacity == size / 3) Resize(capacity / 2);

            int item = items[--size];

            return item;
        }

        private void Resize(int newCapacity)
        {
            capacity = newCapacity;

            int[] newArray = new int[capacity];

            for (int i = 0; i < size; i++)
            {
                newArray[i] = items[i];
            }

            items = newArray;
        }

        public int Count()
        {
            return size;
        }
    }
}

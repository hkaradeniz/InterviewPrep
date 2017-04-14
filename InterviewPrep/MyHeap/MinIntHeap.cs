using System;

namespace InterviewPrep.MyHeap
{
    class MinIntHeap
    {
        private int capacity = 10;
        private int size;

        int[] items = null;

        public MinIntHeap()
        {
            items = new int[capacity];
        }

        private int getLeftChildIndex(int parentIndex)
        {
            return (parentIndex * 2) + 1;
        }

        private int getRightChildIndex(int parentIndex)
        {
            return (parentIndex * 2) + 2;
        }

        private int getParentIndex(int childIndex)
        {
            return (childIndex - 1)  / 2;
        }

        private bool hasLeftChild(int index)
        {
            return getLeftChildIndex(index) < size;
        }

        private bool hasRightChild(int index)
        {
            return getRightChildIndex(index) < size;
        }

        private bool hasParent(int index)
        {
            return getParentIndex(index) >= size;
        }

        private int leftChild(int index)
        {
            return items[getLeftChildIndex(index)];
        }

        private int rightChild(int index)
        {
            return items[getRightChildIndex(index)];
        }

        private int parent (int index)
        {
            return items[getParentIndex(index)];
        }

        private void swap(int indexOne, int indexTwo)
        {
            int temp = items[indexOne];
            items[indexOne] = items[indexTwo];
            items[indexTwo] = temp;
        }

        // Checks array. If the array is full, it doubles its size.
        private void ensureExtraCapacity()
        {
            if (size == capacity)
            {
                Array.Resize(ref items, capacity * 2);
                capacity *= 2;
            }
        }

        // Returns the root of the Heap which is the first element.
        public int Peek()
        {
            if (size == 0)
                throw new Exception();
            return items[0];
        }

        // Remove first element. In this case, you will move the last element to root
        // Then after we will have to readjust the heap (array) as needed
        public int Poll()
        {
            if (size == 0)
                throw new Exception();

            int item = items[0];
            items[0] = items[size - 1];
            size--;
            heapifyDown();
            return item;
        }

        // Adding an item, use the last index too add. Make sure about the capacity first
        // Then after we will have to readjust the heap (array) as needed
        public void Add(int item)
        {
            ensureExtraCapacity();
            items[size] = item;
            size++;
            heapifyUp();
        }

        public void heapifyUp()
        {
            int index = items[size - 1];

            while (hasParent(index) && parent(index) > items[index])
            {
                swap(getParentIndex(index), index);
                index = getParentIndex(index);
            }
        }

        public void heapifyDown()
        {
            int index = 0;
            // If there is no left child, that means there is no right child
            while (hasLeftChild(index))
            {
                int smallerChildIndex = getLeftChildIndex(index);
                if (hasRightChild(index) && rightChild(index) < leftChild(index))
                {
                    smallerChildIndex = getRightChildIndex(index);
                }

                if (items[index] < items[smallerChildIndex])
                    break;
                else
                    swap(index, smallerChildIndex);

                index = smallerChildIndex;
            }
        }

        // Complexity
        // Heapsort Ω(n log(n))	Θ(n log(n))	O(n log(n))	
    }
}

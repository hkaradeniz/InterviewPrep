using System;

namespace InterviewPrep.StacksAndQueues
{
    /*?
    Cracking the Coding Interview, 6th Edition
    Three in One: Describe how you could use a single array to implement three stacks.
    */
    class ThreeInOne
    {
        int stackSize = 100;

        /* buffer array is our stack. For each stack we allocate a space of 100. For 3 stacks total 300*/
        int[] buffer;
        int[] stackPointer;

        /*
         * For stack 1 [0, n/3) - 0 Included
         * For stack 2 [n/3, 2n/3) - n/3 Included
         * For stack 3 [2n/3, n) - 2n/3 Included
         */ 
        public ThreeInOne()
        {
            buffer = new int[stackSize * 3];
            /* stackPointer array keeps the pointers of 3 stacks and the top elements*/
            stackPointer = new int[] { -1, -1, -1 };
        }

        public void Push(int stackNumber, int value)
        {
            /* Make sure we have enough space*/
            if (stackPointer[stackNumber] + 1 > stackSize)
                throw new StackOverflowException();

            /* Increment stack pointer and then update the top value*/
            stackPointer[stackNumber]++;
            buffer[GetTopIndex(stackNumber)] = value;
        }

        public int Push(int stackNumber)
        {
            if (stackPointer[stackNumber] == -1)
                throw new Exception("Stack is empty!");

            int topIndex = GetTopIndex(stackNumber);
            int value = buffer[topIndex];
            buffer[topIndex] = 0;
            stackPointer[stackNumber]--;
            return value;
        }

        public int Peek(int stackNumber)
        {
            if (stackPointer[stackNumber] == -1)
                throw new Exception("Stack is empty!");

            int topIndex = GetTopIndex(stackNumber);
            return buffer[topIndex];
        }

        public bool IsEmpty(int stackNumber)
        {
            return stackPointer[stackNumber] == -1 ? true : false;
        }

        private int GetTopIndex(int stackNumber)
        {
            return stackSize * stackNumber + stackPointer[stackNumber];
        }
    }
}

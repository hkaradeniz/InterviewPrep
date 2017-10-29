using System;
using System.Collections.Generic;

namespace InterviewPrep.StacksAndQueues
{
    class StackNode
    {
        public int Value { get; }
        public int MinValue { get; set; }

        public StackNode(int value, int compare)
        {
            Value = value;
            SetMin(value, compare);
        }

        private void SetMin(int value, int compare)
        {
            MinValue = Math.Min(value, compare);
        }
    }

    class MinStackConstant
    {
        /*
            Design a stack with min(stack) operation in constant time.
            Keeping a min variable is a wrong approach. What if the min variable gets popped?
            
        Solution 1-) Keep another stack to keep track of the min values
        Stack-1         MinStack
            2
            5
            9               2
            5               5
            8               5
            7               7
        If you get the same number multiple times, add them to the stack since one of them gets popped 
        the second one is still in the min stack.
            1- 7: Push it to stack, push it to min stack since it is empty
            2- 8: Push it to stack, 8>7 so no push to minstack
            3- 5: Push it to stack, push it to min stack since 5<7 
            4- 9: Push it to stack, 9>5 so no push to minstack
            5- 5: Push it to stack, 5=5 push it to minstack
            6- 2: Push it to stack, 2<5 push it to minstack

        Solution 2-) Each time you push a number, save the min at that level too.

            STACK
            
            2 - 2
            5 - 5
            9 - 5
            5 - 5
            8 - 7
            7 - 7
            
            For this operation, we should create a StackNode Class. (Value - MinValue)
        */

        /*Solution 1*/
        Stack<int> stack = new Stack<int>();
        Stack<int> minStack = new Stack<int>();

        public void Push(int number)
        {
            stack.Push(number);

            if (minStack.Count == 0 || minStack.Peek() > number)
                minStack.Push(number);
        }

        public int Pop()
        {
            if (stack.Count == 0) return -1;

            int value = stack.Pop();

            if (minStack.Peek() == value)
                minStack.Pop();

            return value;
        }

        public int Min()
        {
            if (minStack.Count == 0) return -1;

            return minStack.Peek();
        }

        /*Solution 2*/
        Stack<StackNode> nodestack = new Stack<StackNode>();

        public void PushNodeStack(int number)
        {
            StackNode newNode = new StackNode(number, nodestack.Count == 0 ? number : nodestack.Peek().MinValue);
            nodestack.Push(newNode);
        }

        public int PopNodeStack()
        {
            if (nodestack.Count == 0) return -1;

            return nodestack.Pop().Value;
        }

        public int MinNodeStack()
        {
            if (nodestack.Count == 0) return -1;

            return nodestack.Peek().MinValue;
        }
    }
}

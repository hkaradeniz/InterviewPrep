using System.Collections.Generic;
using System;

namespace InterviewPrep.StacksAndQueues
{
    /* Cracking the Coding Interview, 6th Edition
     Stack of Plates: Imagine a (literal) stack of plates. If the stack gets too high, it might topple.
        Therefore, in real life, we would likely start a new stack when the previous stack exceeds some
        threshold. Implement a data structure SetOfStacks that mimics this. SetO-fStacks should be
        composed of several stacks and should create a new stack once the previous one exceeds capacity.
        SetOfStacks. push() and SetOfStacks. pop() should behave identically to a single stack
        (that is, pop () should return the same values as it would if there were just a single stack).
     */
    class SNode
    {
        private Stack<int> stack;
        private int capacity;
        private int size;

        public SNode()
        {
            stack = new Stack<int>();
            capacity = 5;
            size = 0;
        }

        public void Push(int num)
        {
            stack.Push(num);
            IncreaseSize();
        }

        public int Pop()
        {
            int n = stack.Pop();
            DecreaseSize();
            return n;
        }

        private void IncreaseSize()
        {
            size++;
        }

        private void DecreaseSize()
        {
            size--;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public bool IsFull()
        {
            return size == capacity;
        }
    }


    class SetOfStacks
    {
        private Stack<SNode> stackSet;
        private SNode current;

        public SetOfStacks()
        {
            stackSet = new Stack<SNode>();
            current = new SNode();
        }

        public void Push(int element)
        {
            if (current.IsFull())
            { PushStack(current); current = GetNewStackNode(); }

            current.Push(element);
        }

        public int Pop()
        {
            if (current.IsEmpty())
                current = PopStack();

            return current.Pop();
        }

        private SNode GetNewStackNode()
        {
            return new SNode();
        }

        private void PushStack(SNode node)
        {
            stackSet.Push(node);
        }

        private SNode PopStack()
        {
            if (!IsEmpty())
                return stackSet.Pop();

            throw new Exception("Empty Stackset...");
        }

        private bool IsEmpty()
        {
            return stackSet.Count == 0;
        }
    }
}

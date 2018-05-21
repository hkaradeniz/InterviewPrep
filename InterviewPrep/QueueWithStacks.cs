using System.Collections.Generic;

namespace InterviewPrep
{
    class QueueWithStacks
    {
        // Queue with Stacks
        Stack<int> incoming = new Stack<int>();
        Stack<int> outgoing = new Stack<int>();

        public void Push(int value)
        {
            while (outgoing.Count > 0)
                incoming.Push(outgoing.Pop());

            incoming.Push(value);
        }

        public int Pop()
        {
            while (incoming.Count > 0)
                outgoing.Push(incoming.Pop());

            if (outgoing.Count == 0) return -1;

            return outgoing.Pop();
        }
    }
}

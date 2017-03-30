using InterviewPrep.MyLinkedList;

namespace InterviewPrep
{
    class FloydsCycleFindingAlgorithm
    {
        /*
        Determine if linked list is circular.
        */

        // Floyd's cycle finding algorithm
        public bool HasLoop(Node first)
        {
            if (first == null) // List doesn't exist, so loop either
                return false;

            Node slow, fast;
            slow = fast = first;

            while (true)
            {
                slow = slow.Next; // 1 Hop
                if (fast.Next != null)
                    fast = fast.Next.Next; // 2 Hops
                else
                    return false; // Next node is null, no loop

                // If they hit null, no loop
                if (slow == null || fast == null)
                    return false;

                if (slow == fast)
                    return true; // The two meet, there is a loop

            }
        }
    }
}

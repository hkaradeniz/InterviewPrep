using InterviewPrep.MyLinkedList;

namespace InterviewPrep.Adobe
{
    /* Reverse a linked list */
    /* Change the pointers */
    /* 1 -> 2 -> 3 -> 4 */
    /*  null <- 1  */
    /*  null <- 1 <- 2 ...  */
    class ReverseLinkedList
    {
        public Node Reverse(Node head)
        {
            if (head == null)
                return null;

            Node current = head;
            Node next = null;
            Node previous = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            head = previous;
            return head;
        }
    }
}

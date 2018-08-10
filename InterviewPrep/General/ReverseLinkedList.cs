using InterviewPrep.MyLinkedList;

namespace InterviewPrep.General
{
    /* Reverse a Linked List Recursively */
    /*
     Test Data:
      MyLinkedList.MyLinkedList ml = new MyLinkedList.MyLinkedList();
            ml.AddLast(1);
            ml.AddLast(2);
            ml.AddLast(3);
            ml.AddLast(4);
            General.ReverseLinkedList rl = new General.ReverseLinkedList(ml);
            rl.ReverseList();
    */
    class ReverseLinkedList
    {
        // Reverse a Linked List - Iterative
        // Keep three pointers
        public Node ReverseLinkedListIteratively(Node head)
        {
            Node prev = null;
            Node current = null;
            Node next = head;

            while (next != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            return head;
        }
    }
}

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
        Node Head;
        Node Pointer;

        public ReverseLinkedList(MyLinkedList.MyLinkedList mList)
        {
            Head = mList.Head;
        }

        public void ReverseList()
        {
            ReverseLinkedListRecursively(Head);
        }

        private void ReverseLinkedListRecursively(Node node)
        {
            if (node == null)
                return;

            if (node.Next == null)
            {
                Head = Pointer = node; return;
            }

            ReverseLinkedListRecursively(node.Next);
            Pointer.Next = node;
            node.Next = null;
            Pointer = Pointer.Next;
        }

        // Reverse a Linked List - Iterative
        // Keep three pointers
        public void ReverseLinkedListIteratively()
        {
            Node prev = null;
            Node current = null;
            Node next = Head;

            while (next != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            Head = prev;
        }
    }
}

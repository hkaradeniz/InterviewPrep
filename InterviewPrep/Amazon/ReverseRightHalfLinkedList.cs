using System;
using InterviewPrep.MyLinkedList;

namespace InterviewPrep.Amazon
{
    /* Reverse right half of a linked list */
    class ReverseRightHalfLinkedList
    {
        public void Reverse(Node head)
        {
            if (head == null) return;

            int counter = 0;
            Node current = head;

            while (current != null)
            {
                counter++;
                current = current.Next;
            }

            int middle = counter / 2;

            current = head;
            Node tempHead = null;
            while (middle > 0)
            {
                tempHead = current;
                current = current.Next;
                middle--;
            }

            Node previous = null;
            while (current != null)
            {
                Node next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            tempHead.Next = previous;

            PrintList(head);
        }

        private void PrintList(Node node)
        {
            while (node != null)
            {
                Console.Write($" { node.Value } ");
                node = node.Next;
            }
        }
    }
}

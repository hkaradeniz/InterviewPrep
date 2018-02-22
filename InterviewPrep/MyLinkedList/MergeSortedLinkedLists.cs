using System;

namespace InterviewPrep.MyLinkedList
{
    /* Given two sorted Linked Lists. Merge the two linked lists to form a new sorted Linked List */
    class MergeSortedLinkedLists
    {
        public void Merge(Node node1, Node node2)
        {
            if (node1 == null && node2 == null) return;
            if (node1 == null) PrintList(node2);
            if (node2 == null) PrintList(node1);

            Node sorting = null;
            Node newHead = null;

            if (node1.Value < node2.Value)
            {
                sorting = node1;
                node1 = node1.Next;
            }
            else
            {
                sorting = node2;
                node2 = node2.Next;
            }

            newHead = sorting;

            /*
                sorting  node1
                   10 -> 50 -> 70 -> 90 -> 100

                  node2
                   20 -> 30 -> 40 -> 60 -> 80
             */

            while (node1 != null && node2 != null)
            {
                if (node1.Value > node2.Value)
                {
                    sorting = sorting.Next = node2;
                    node2 = node2.Next;
                }
                else
                {
                    sorting = sorting.Next = node1;
                    node1 = node1.Next;
                }
            }

            if (node1 == null) sorting.Next = node2;
            if (node2 == null) sorting.Next = node1;


            PrintList(newHead);
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

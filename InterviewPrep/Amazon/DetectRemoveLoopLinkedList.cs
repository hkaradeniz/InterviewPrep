using System;

namespace InterviewPrep.Amazon
{
    /* Remove loop in Linked List */
    /* Given a linked list, remove the loop in it if present */
    /* https://practice.geeksforgeeks.org/problems/remove-loop-in-linked-list/1 */
    /*      
            // Test code       
            MyLinkedList.MyLinkedList list = new MyLinkedList.MyLinkedList();
            MyLinkedList.Node node1 = new MyLinkedList.Node(1);
            MyLinkedList.Node node2 = new MyLinkedList.Node(2);
            MyLinkedList.Node node3 = new MyLinkedList.Node(3);
            MyLinkedList.Node node4 = new MyLinkedList.Node(4);
            MyLinkedList.Node node5 = new MyLinkedList.Node(5);
            MyLinkedList.Node node6 = new MyLinkedList.Node(6);
            MyLinkedList.Node node7 = new MyLinkedList.Node(7);
            MyLinkedList.Node node8 = new MyLinkedList.Node(8);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;
            node5.Next = node6;
            node6.Next = node7;
            node7.Next = node8;
            node8.Next = node5;

            Amazon.DetectRemoveLoopLinkedList dr = new Amazon.DetectRemoveLoopLinkedList();
            dr.DetectAndRemoveLoop(node1); 
     */
    class DetectRemoveLoopLinkedList
    {
        public void DetectAndRemoveLoop(MyLinkedList.Node head)
        {
            if (head == null) { Console.WriteLine("Empty list..."); return; }
            DetectLoop(head);
        }

        private void DetectLoop(MyLinkedList.Node head)
        {
            MyLinkedList.Node slow = head;
            MyLinkedList.Node fast = head;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == fast)
                {
                    Console.WriteLine("Loop is detected! Removing...");
                    RemoveLoop(slow, fast, head);
                }
            }

            Console.WriteLine("The list contains no loop!");
        }

        private void RemoveLoop(MyLinkedList.Node slow, MyLinkedList.Node fast, MyLinkedList.Node head)
        {
            slow = head;

            while (slow.Next != fast.Next)
            {
                slow = slow.Next;
                fast = fast.Next;
            }

            MyLinkedList.Node newNode = null;

            fast.Next = newNode;

            Console.WriteLine("Loop is removed...");
        }
    }
}
